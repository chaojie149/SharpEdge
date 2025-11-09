using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity.Entities;

public abstract class BaseEntity<TKey>
{
    
    [Key]
    [Column("id")]
    public TKey Id { get; set; } = default!;
    
    
    protected BaseEntity()
    {
        // 如果是 Guid 类型,在构造时自动生成
        if (typeof(TKey) == typeof(Guid) && EqualityComparer<TKey>.Default.Equals(Id, default))
        {
            Id = (TKey)(object)Guid.NewGuid();
        }
    }
}