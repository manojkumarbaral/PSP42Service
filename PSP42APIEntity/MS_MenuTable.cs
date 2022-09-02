using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class MS_MenuTable
    {
        [Key]
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
        public bool IsSubmenu { get; set; }
        public bool IsActive { get; set; }
        public string Icon { get; set; }
        public List<MS_SubMenuTable> MenuTable { get; set; } = new List<MS_SubMenuTable>();
    }
}
