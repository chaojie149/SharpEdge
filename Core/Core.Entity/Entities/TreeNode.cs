namespace Core.Entity.Entities;

/// <summary>
/// 树形节点（用于返回树形结构）
/// </summary>
public class TreeNode<T, TKey> where T : class
{
    public List<T> Children { get; set; } = new();
}