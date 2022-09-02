using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessEntities.Member
{
    public class tbl_TRN_MemberFileDetails
    {
        [Key]
        public int MemberFileDetailsID { get; set; }
        public int Member_ID { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public Int64 FileSize { get; set; }
        public string MimeType { get; set; }
        public string FileExtension { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
