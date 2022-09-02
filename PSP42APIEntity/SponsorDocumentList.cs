using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class SponsorDocumentList
    {
        public int slno { get; set; }
        public string fileName { get; set; }
        public int FileDetailsID { get; set; }
        public string FilePath { get; set; }
        public string MimeType { get; set; }
    }
}
