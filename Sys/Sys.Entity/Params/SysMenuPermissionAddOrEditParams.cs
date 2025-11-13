namespace Sys.Entity.Params
{
    /// <summary>
    /// 菜单新增或修改参数
    /// </summary>
    public class SysMenuPermissionAddOrEditParams
    {
        /// <summary>
        /// 菜单ID（新增可为空）
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// 父节点ID
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 菜单标题
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// 菜单类型
        /// </summary>
        public string Type { get; set; } = null!;

        /// <summary>
        /// 前端路由路径
        /// </summary>
        public string? RoutePath { get; set; }

        /// <summary>
        /// 前端组件路径
        /// </summary>
        public string? ComponentPath { get; set; }

        /// <summary>
        /// 权限标识
        /// </summary>
        public string? PermissionCode { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string? Icon { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 是否可见（1=显示,0=隐藏）
        /// </summary>
        public sbyte Visible { get; set; }
    }
}