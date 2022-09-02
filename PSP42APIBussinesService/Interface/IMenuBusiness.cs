using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessService.Interface
{
    public interface IMenuBusiness
    {
        Task<IEnumerable<MS_MenuTable>> getMenuItems();
        Task<IEnumerable<MS_SubMenuTable>> getSubMenuItems();
    }
}
