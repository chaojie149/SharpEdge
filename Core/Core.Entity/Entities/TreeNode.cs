namespace Core.Entity.Entities;

/// <summary>
/// 树形节点（用于返回树形结构）
/// </summary>
public class TreeNode<T, TKey> where T : class
{
    public T Data { get; set; } = default!;
    public List<TreeNode<T, TKey>> Children { get; set; } = new();
    public bool HasChildren => Children.Any();
    public int ChildCount => Children.Count;
}