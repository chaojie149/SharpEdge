using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity.Entities;

public abstract class BaseEntity<TKey>
{
    
    [Key]
    [Column("id")]
    public TKey Id { get; set; } = default!;
}