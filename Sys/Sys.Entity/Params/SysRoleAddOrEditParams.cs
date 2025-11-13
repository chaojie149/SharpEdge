namespace Sys.Entity.Params;

public class SysRoleAddOrEditParams
{
    public string? Id { get; set; }
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public sbyte Enable { get; set; }
}