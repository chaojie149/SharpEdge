namespace Sys.Entity.Dtos;

/// <summary>
/// 菜单API关联DTO
/// </summary>
public class SysMenuApiDto
{
    public string Id { get; set; } = null!;
    public string MenuId { get; set; } = null!;
    public string ApiId { get; set; } = null!;
    public bool Required { get; set; }
    public int? Sort { get; set; }
    public string? Remark { get; set; }
    
    // 关联对象
    public SysApiDto? Api { get; set; }
}