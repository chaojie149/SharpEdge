namespace Sys.Entity.Dtos;

public class SysMenuPermissionDto
{
    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }
    public string Title { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string? RoutePath { get; set; }
    public string? ComponentPath { get; set; }
    public string? PermissionCode { get; set; }
    public string? Icon { get; set; }
    public sbyte Visible { get; set; }
    public int Sort { get; set; }
    public List<SysMenuPermissionDto>? Children { get; set; }
}