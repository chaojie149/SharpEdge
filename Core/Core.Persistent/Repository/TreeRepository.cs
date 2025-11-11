using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Entity.Entities;
using Core.Persistent.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Persistent.Repository;

/// <summary>
/// 树形结构仓储实现
/// </summary>
public class TreeRepository<TEntity, TKey> : Repository<TEntity, TKey>, ITreeRepository<TEntity, TKey>
    where TEntity : BaseEntity<TKey>, ITreeEntity<TKey>
{
    public TreeRepository(DbContext context) : base(context)
    {
    }

    /// <summary>
    /// 获取所有根节点
    /// </summary>
    public virtual async Task<List<TEntity>> GetRootNodesAsync(CancellationToken cancellationToken = default)
    {
        return await Query()
            .Where(e => e.ParentId == null || e.ParentId.Equals(default(TKey)))
            .OrderBy(e => e.Sort)
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// 获取指定节点的所有子节点（仅一级）
    /// </summary>
    public virtual async Task<List<TEntity>> GetChildrenAsync(TKey parentId, CancellationToken cancellationToken = default)
    {
        return await Query()
            .Where(e => e.ParentId != null && e.ParentId.Equals(parentId))
            .OrderBy(e => e.Sort)
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// 获取指定节点的所有后代节点（递归）
    /// </summary>
    public virtual async Task<List<TEntity>> GetDescendantsAsync(TKey parentId, CancellationToken cancellationToken = default)
    {
        var parent = await GetByIdAsync(parentId, cancellationToken);
        if (parent == null)
            return new List<TEntity>();

        var path = parent.Path ?? parent.Id?.ToString() ?? string.Empty;
        
        return await Query()
            .Where(e => e.Path != null && e.Path.StartsWith(path + "/"))
            .OrderBy(e => e.Path)
            .ThenBy(e => e.Sort)
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// 获取指定节点的所有祖先节点
    /// </summary>
    public virtual async Task<List<TEntity>> GetAncestorsAsync(TKey id, CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity == null || string.IsNullOrEmpty(entity.Path))
            return new List<TEntity>();

        var ancestorIds = entity.Path.Split('/', StringSplitOptions.RemoveEmptyEntries);
        var ancestors = new List<TEntity>();

        foreach (var ancestorIdStr in ancestorIds)
        {
            if (TryConvertToKey(ancestorIdStr, out var ancestorId))
            {
                var ancestor = await GetByIdAsync(ancestorId, cancellationToken);
                if (ancestor != null)
                    ancestors.Add(ancestor);
            }
        }

        return ancestors;
    }

    /// <summary>
    /// 获取树形结构（返回嵌套的树）
    /// </summary>
    public virtual async Task<List<TreeNode<TEntity, TKey>>> GetTreeAsync(
        TKey? rootId = default,
        int? maxDepth = null,
        CancellationToken cancellationToken = default)
    {
        List<TEntity> entities;

        if (rootId == null || rootId.Equals(default(TKey)))
        {
            // 获取所有数据
            entities = await Query().OrderBy(e => e.Sort).ToListAsync(cancellationToken);
        }
        else
        {
            // 获取指定节点及其后代
            var root = await GetByIdAsync(rootId, cancellationToken);
            if (root == null)
                return new List<TreeNode<TEntity, TKey>>();

            entities = new List<TEntity> { root };
            entities.AddRange(await GetDescendantsAsync(rootId, cancellationToken));
        }

        return BuildTree(entities, rootId, maxDepth, 0);
    }

    /// <summary>
    /// 获取树形结构（扁平列表）
    /// </summary>
    public virtual async Task<List<TEntity>> GetTreeFlatAsync(
        TKey? rootId = default,
        int? maxDepth = null,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = Query();

        if (rootId != null && !rootId.Equals(default(TKey)))
        {
            var root = await GetByIdAsync(rootId, cancellationToken);
            if (root == null)
                return new List<TEntity>();

            var path = root.Path ?? root.Id?.ToString() ?? string.Empty;
            query = query.Where(e => e.Id!.Equals(rootId) || (e.Path != null && e.Path.StartsWith(path + "/")));
        }

        if (maxDepth.HasValue)
        {
            var rootLevel = rootId != null && !rootId.Equals(default(TKey)) 
                ? (await GetByIdAsync(rootId, cancellationToken))?.Level ?? 0 
                : 0;
            query = query.Where(e => e.Level <= rootLevel + maxDepth.Value);
        }

        return await query.OrderBy(e => e.Path).ThenBy(e => e.Sort).ToListAsync(cancellationToken);
    }

    /// <summary>
    /// 移动节点到新父节点下
    /// </summary>
    public virtual async Task MoveNodeAsync(TKey nodeId, TKey? newParentId, CancellationToken cancellationToken = default)
    {
        var node = await GetByIdAsync(nodeId, cancellationToken);
        if (node == null)
            throw new ArgumentException("Node not found", nameof(nodeId));

        // 检查是否移动到自己的子节点下（防止循环引用）
        if (newParentId != null && !newParentId.Equals(default(TKey)))
        {
            var descendants1 = await GetDescendantsAsync(nodeId, cancellationToken);
            if (descendants1.Any(d => d.Id!.Equals(newParentId)))
                throw new InvalidOperationException("Cannot move node to its own descendant");
        }

        var oldPath = node.Path;
        var oldLevel = node.Level;

        // 更新父节点和路径
        node.ParentId = newParentId;
        
        if (newParentId == null || newParentId.Equals(default(TKey)))
        {
            node.Path = node.Id?.ToString();
            node.Level = 0;
        }
        else
        {
            var newParent = await GetByIdAsync(newParentId, cancellationToken);
            if (newParent == null)
                throw new ArgumentException("New parent not found", nameof(newParentId));

            node.Path = $"{newParent.Path}/{node.Id}";
            node.Level = newParent.Level + 1;
        }

        Update(node);

        // 更新所有子孙节点的路径和层级
        var descendants = await Query()
            .Where(e => e.Path != null && e.Path.StartsWith(oldPath + "/"))
            .ToListAsync(cancellationToken);

        var levelDiff = node.Level - oldLevel;

        foreach (var descendant in descendants)
        {
            descendant.Path = descendant.Path!.Replace(oldPath!, node.Path!);
            descendant.Level += levelDiff;
            Update(descendant);
        }

        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// 判断是否有子节点
    /// </summary>
    public virtual async Task<bool> HasChildrenAsync(TKey parentId, CancellationToken cancellationToken = default)
    {
        return await Query()
            .AnyAsync(e => e.ParentId != null && e.ParentId.Equals(parentId), cancellationToken);
    }

    /// <summary>
    /// 构建树形结构（递归）
    /// </summary>
    private List<TreeNode<TEntity, TKey>> BuildTree(
        List<TEntity> allEntities,
        TKey? parentId,
        int? maxDepth,
        int currentDepth)
    {
        if (maxDepth.HasValue && currentDepth >= maxDepth.Value)
            return new List<TreeNode<TEntity, TKey>>();

        var children = allEntities
            .Where(e => (parentId == null || parentId.Equals(default(TKey)))
                ? (e.ParentId == null || e.ParentId.Equals(default(TKey)))
                : (e.ParentId != null && e.ParentId.Equals(parentId)))
            .OrderBy(e => e.Sort)
            .Select(e => new TreeNode<TEntity, TKey>
            {
                Data = e,
                Children = BuildTree(allEntities, e.Id, maxDepth, currentDepth + 1)
            })
            .ToList();

        return children;
    }

    /// <summary>
    /// 尝试将字符串转换为TKey类型
    /// </summary>
    private bool TryConvertToKey(string value, out TKey result)
    {
        try
        {
            result = (TKey)Convert.ChangeType(value, typeof(TKey));
            return true;
        }
        catch
        {
            result = default!;
            return false;
        }
    }
}