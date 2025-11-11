namespace Sys.Entity.Dtos;

public class SysRoleDto
{
    public string Id { get; set; }

    /// <summary>
    /// 角色代码
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 启用状态
    /// </summary>
    public sbyte Enable { get; set; }

}