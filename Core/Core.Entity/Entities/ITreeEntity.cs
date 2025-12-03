namespace Core.Entity.Entities;

/// <summary>
/// 树形结构接口
/// </summary>
public interface ITreeEntity<TKey, TSelf>
    where TKey : struct
    where TSelf : ITreeEntity<TKey, TSelf>
{
    TKey? ParentId { get; set; }

    string? Path { get; set; }

    int Level { get; set; }

    int Sort { get; set; }

    ICollection<TSelf> Children { get; set; }
}

