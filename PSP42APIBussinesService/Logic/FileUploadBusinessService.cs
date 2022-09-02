using BusinessEntities;
using BusinessService.Interface;
using DAL;
using Dapper;
using DATA.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessService.Logic
{
    public class FileUploadBusinessService: IFileUploadInterface
    {
        public DataLayer DL;
        private readonly ApplicationDBContext ApplicationDBContext;
        public FileUploadBusinessService(ApplicationDBContext _ApplicationDBContext)
        {
            this.ApplicationDBContext = _ApplicationDBContext;
            DL = new DataLayer();
        }

        public async void FileInfoSaveToDB(FileRecords FileRecords)
        {
            using (IDbConnection db = new SqlConnection(DL.GetConnectionString()))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@SponsorTID", FileRecords.SponsorTID);
                param.Add("@SponsorEID", FileRecords.SponsorEID);
                param.Add("@FilePath", FileRecords.FilePath);
                param.Add("@FileName", FileRecords.FileName);
                param.Add("@FileSize", FileRecords.FileSize);
                param.Add("@MimeType", FileRecords.MimeType);
                param.Add("@FileExtension", FileRecords.FileExtension);
                string sp = "USP_FileInfoSaveToDB";
                await db.QueryAsync(sp, param, commandType: CommandType.StoredProcedure);
                
            }


        }
        public async void MemberFileSaveToDB(FileRecords FileRecords)
        {
            using (IDbConnection db = new SqlConnection(DL.GetConnectionString()))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@member_ID", FileRecords.member_ID);
                param.Add("@FilePath", FileRecords.FilePath);
                param.Add("@FileName", FileRecords.FileName);
                param.Add("@FileSize", FileRecords.FileSize);
                param.Add("@MimeType", FileRecords.MimeType);
                param.Add("@FileExtension", FileRecords.FileExtension);
                param.Add("@TypeOfFile", FileRecords.TypeOfFile);
                param.Add("@action", FileRecords.action);
                param.Add("@userid", FileRecords.userid);
                string sp = "USP_MemberFileSaveToDB";
                await db.QueryAsync(sp, param, commandType: CommandType.StoredProcedure);

            }


        }
    }
}
