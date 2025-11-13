namespace Sys.Entity.Dtos;


/// <summary>
/// 菜单及其关联的API列表
/// </summary>
public class MenuWithApisDto : SysMenuPermissionDto
{
    /// <summary>
    /// 关联的API列表
    /// </summary>
    public List<SysMenuApiDto> RelatedApis { get; set; } = new();
}