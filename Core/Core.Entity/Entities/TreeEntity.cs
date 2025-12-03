namespace Core.Entity.Entities;


public abstract class TreeEntity<TKey, TSelf> 
    : BaseEntity<TKey>, ITreeEntity<TKey, TSelf>
    where TKey : struct
    where TSelf : TreeEntity<TKey, TSelf>
{
    public virtual TKey? ParentId { get; set; }

    public virtual string? Path { get; set; }

    public virtual int Level { get; set; }

    public virtual int Sort { get; set; }

    public virtual ICollection<TSelf> Children { get; set; } = new List<TSelf>();
}