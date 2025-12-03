using Sys.Entity.Models;

namespace Sys.Entity.Base
{

    public class MenuTreeNode
    {
        // 先定义所有业务属性
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool Breadcrumbs { get; set; }
        public string Color { get; set; }
        public bool Disabled { get; set; }
        public bool External { get; set; }
        public bool IsDropdown { get; set; }
        public string? Icon { get; set; }
        public string Link { get; set; }
        public string Search { get; set; }
        public bool Target { get; set; }
        public string Type { get; set; }
        public string? Url { get; set; }
        public string? Caption { get; set; }
        public string PermissionCode { get; set; }
        public string Module { get; set; }
        public List<object> MenuApis { get; set; }
        public Guid? ParentId { get; set; }
        public string Path { get; set; }
        public int Level { get; set; }
        public int Sort { get; set; }
    
        // Children 放在最后 ✅
        public List<MenuTreeNode>? Children { get; set; }
    }
}