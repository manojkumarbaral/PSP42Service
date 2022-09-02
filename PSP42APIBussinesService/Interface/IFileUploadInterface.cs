using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessService.Interface
{
    public interface IFileUploadInterface
    {
        void FileInfoSaveToDB(FileRecords FileRecords);
        void MemberFileSaveToDB(FileRecords FileRecords);
    }
}
