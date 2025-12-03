namespace Sys.Entity.Params
{
    /// <summary>
    /// 菜单新增或修改参数
    /// </summary>
    public class SysMenuPermissionAddOrEditParams
    {
        /// <summary>
        /// Id
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// 面包屑导航
        /// </summary>
        public bool Breadcrumbs { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string? Color { get; set; }

        /// <summary>
        /// 禁用
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 外部
        /// </summary>
        public bool External { get; set; }

        /// <summary>
        /// 下拉
        /// </summary>
        public bool IsDropdown { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string? Icon { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        public string? Link { get; set; }

        /// <summary>
        /// 搜索
        /// </summary>
        public string? Search { get; set; }

        /// <summary>
        /// 目标
        /// </summary>
        public bool Target { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; } = null!;

        /// <summary>
        /// 链接
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string? Caption { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public string? Path { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public string? Level { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public string? Sort { get; set; }

        /// <summary>
        /// 模块
        /// </summary>
        public string? Module { get; set; }
        
        public string PermissionCode { get; set; } = null!;

    }
}