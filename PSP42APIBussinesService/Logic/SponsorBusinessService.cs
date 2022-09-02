using BusinessEntities;
using BusinessEntities.Sponsor;
using BusinessService.Interface;
using DAL;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessService.Logic
{
    public class SponsorBusinessService : ISponsorInterface
    {
        public DataLayer DL;
        public SponsorBusinessService()
        {
            DL = new DataLayer();
        }
        public async Task<IEnumerable<SponsorSuccess>> SubmitSponsorCreation(SponsorSubmit SponsorSubmit)
        {
            using (IDbConnection db = new SqlConnection(DL.GetConnectionString()))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@SponsorEmail", SponsorSubmit.SponsorEmail);
                param.Add("@Code", SponsorSubmit.Code);
                param.Add("@SponsorMobile", SponsorSubmit.SponsorMobile);
                param.Add("@FullName", SponsorSubmit.FullName);
                param.Add("@EIDNumber", SponsorSubmit.EIDNumber);
                param.Add("@UIDNumber", SponsorSubmit.UIDNumber);
                param.Add("@CreatedBy_UID", SponsorSubmit.CreatedBy_UID);
                string sp = "USP_SubmitSponsorCreation";
                var result = await db.QueryAsync<SponsorSuccess>(sp, param, commandType: CommandType.StoredProcedure);
                return result;
            }

        }

        public async Task<IEnumerable<SponsorDocumentList>> getSponsorDocumentList(string sponsorTID)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(DL.GetConnectionString()))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@sponsorTID", sponsorTID);
                    string sp = "USP_getSponsorDocumentList";
                    var result = await db.QueryAsync<SponsorDocumentList>(sp, param, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public async Task<IEnumerable<SponsorSuccess>> getSponsorCheck(string UID)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(DL.GetConnectionString()))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@UID", UID);
                    string sp = "USP_getSponsorCheck";
                    var result = await db.QueryAsync<SponsorSuccess>(sp, param, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }

    }
}
