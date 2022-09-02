using BusinessEntities;
using BusinessEntities.LoginModel;
using BusinessEntities.Member;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATA.EF
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {}
        public DbSet<MS_Company> MS_Company { get; set; }

        public DbSet<MS_Customer> MS_Customer { get; set; }

        public DbSet<PMS_UserMaster> PMS_UserMaster { get; set; }

        public DbSet<MS_SubMenuTable> MS_SubMenuTable { get; set; }

        public DbSet<MS_MenuTable> MS_MenuTable { get; set; }

        public DbSet<tbl_TRN_FileDetails> tbl_TRN_FileDetails { get; set; }
        public DbSet<tbl_TRN_MemberFileDetails> tbl_TRN_MemberFileDetails { get; set; }

    }
}
