using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class tbl_TRN_FileDetails
    {
        [Key]
        public int FileDetailsID { get; set; }

        public string FilePath { get; set; }

        public string FileName { get; set; }

        public string MimeType { get; set; }
    }
}
