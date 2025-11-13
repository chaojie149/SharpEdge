namespace Core.Entity.Entities;

/// <summary>
/// 树形结构基类，统一树形公共字段定义
/// </summary>
public class TreeEntity<TKey> : BaseEntity<TKey>, ITreeEntity<TKey> where TKey : struct 
{
    /// <summary>
    /// 父节点ID，可为空表示根节点
    /// </summary>
    public virtual TKey? ParentId { get; set; }

    /// <summary>
    /// 层级路径（如：1/2/3）
    /// </summary>
    public virtual string? Path { get; set; }

    /// <summary>
    /// 层级深度
    /// </summary>
    public virtual int Level { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public virtual int Sort { get; set; }
}