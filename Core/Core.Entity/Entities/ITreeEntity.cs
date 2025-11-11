namespace Core.Entity.Entities;

/// <summary>
/// 树形结构接口
/// </summary>
public interface ITreeEntity<TKey>
{
    /// <summary>
    /// 父节点ID
    /// </summary>
    TKey? ParentId { get; set; }
    
    /// <summary>
    /// 层级路径（如：1/2/3）
    /// </summary>
    string? Path { get; set; }
    
    /// <summary>
    /// 层级深度
    /// </summary>
    int Level { get; set; }
    
    /// <summary>
    /// 排序
    /// </summary>
    int Sort { get; set; }
}

