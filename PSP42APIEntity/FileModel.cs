using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BusinessEntities
{
    public class FileModel
    {
        public IFormFile MyFile { get; set; }
        //public string TypeDoc { get; set; }
        //public string name { get; set; }
        //public int size { get; set; }
        //public string type { get; set; }
    }
}
