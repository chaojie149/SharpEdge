using System.ComponentModel.DataAnnotations.Schema;
using Core.Entity.Entities;

namespace Core.Persistent.Entities;

public abstract class AuditableEntity<TKey> : BaseEntity<TKey>, IAuditableEntity
{
    [Column("created_time")]

    public DateTime CreatedTime { get; set; }
    
    
    [Column("created_by")]
    public string? CreatedBy { get; set; }
    
    [Column("modify_time")]

    public DateTime? ModifyTime { get; set; }
    
    [Column("modify_by")]
    public string? ModifyBy { get; set; }
    protected AuditableEntity() : base()
    {
    }

}