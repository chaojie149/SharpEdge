using Core.Entity.Entities;

namespace Core.Persistent.Repository;

/// <summary>
/// 树形结构仓储接口
/// </summary>
public interface ITreeRepository<TEntity, TKey> : IRepository<TEntity, TKey> 
    where TEntity : BaseEntity<TKey>, ITreeEntity<TKey> where TKey : struct 
{
    /// <summary>
    /// 获取所有根节点
    /// </summary>
    Task<List<TEntity>> GetRootNodesAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// 获取指定节点的所有子节点（仅一级）
    /// </summary>
    Task<List<TEntity>> GetChildrenAsync(TKey parentId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// 获取指定节点的所有后代节点（递归）
    /// </summary>
    Task<List<TEntity>> GetDescendantsAsync(TKey parentId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// 获取指定节点的所有祖先节点
    /// </summary>
    Task<List<TEntity>> GetAncestorsAsync(TKey id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// 获取树形结构（返回嵌套的树）
    /// </summary>
    Task<List<TreeNode<TEntity, TKey>>> GetTreeAsync(
        TKey? rootId = default, 
        int? maxDepth = null,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// 获取树形结构（扁平列表）
    /// </summary>
    Task<List<TEntity>> GetTreeFlatAsync(
        TKey? rootId = default, 
        int? maxDepth = null,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// 移动节点到新父节点下
    /// </summary>
    Task MoveNodeAsync(TKey nodeId, TKey? newParentId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// 判断是否有子节点
    /// </summary>
    Task<bool> HasChildrenAsync(TKey parentId, CancellationToken cancellationToken = default);
}