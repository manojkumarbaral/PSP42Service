using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class FileRecords
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string MimeType { get; set; }
        public string SponsorEID { get; set; }
        public double SponsorTID { get; set; }
        public double FileSize { get; set; }
        public string FileExtension { get; set; }
        public int member_ID { get; set; }
        public string TypeOfFile { get; set; }
        public string action { get; set; }
        public int userid { get; set; }

    }
}
