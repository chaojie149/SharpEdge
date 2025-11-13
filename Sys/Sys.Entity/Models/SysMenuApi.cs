using System.ComponentModel.DataAnnotations.Schema;
using Core.Entity.Entities;

namespace Sys.Entity.Models;

/// <summary>
/// 菜单与API关联表
/// </summary>
[Table("sys_menu_api")]
public class SysMenuApi:BaseEntity<Guid>
{
   

    /// <summary>
    /// 菜单权限ID
    /// </summary>
    [Column("menu_id")]
    public Guid MenuId { get; set; }

    /// <summary>
    /// API ID
    /// </summary>
    [Column("api_id")]
    public Guid ApiId { get; set; }

    /// <summary>
    /// 是否必需（true=访问菜单必须有此API权限，false=可选）
    /// </summary>
    [Column("required")]
    public bool Required { get; set; } = true;

    /// <summary>
    /// 排序
    /// </summary>
    [Column("sort")]
    public int? Sort { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [Column("created_time")]
    public DateTime? CreatedTime { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [Column("remark")]
    public string? Remark { get; set; }

    // 导航属性
    public virtual SysMenuPermission? Menu { get; set; }
    public virtual SysApi? Api { get; set; }
}