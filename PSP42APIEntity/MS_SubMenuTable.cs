using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessEntities
{
    public class MS_SubMenuTable
    {
        [Key]
        public int SubMenuID { get; set; }
        public int MenuID { get; set; }
        public string SuubMenuName { get; set; }
        public string SubMenuUrl { get; set; }
        public bool IsActive { get; set; }
        public string SubIcon { get; set; }

        
    }
}
