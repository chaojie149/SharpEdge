namespace Core.Persistent.Entities;

public interface IAuditableEntity
{
    DateTime CreatedTime { get; set; }
    string? CreatedBy { get; set; }
    DateTime? ModifyTime { get; set; }
    string? ModifyBy { get; set; }
}
