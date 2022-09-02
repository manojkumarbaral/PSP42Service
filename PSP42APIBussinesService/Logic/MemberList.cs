using BusinessEntities;
using BusinessEntities.Member;
using BusinessService.Interface;
using DAL;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BusinessService.Logic
{
    public class MemberList: IMember
    {
        public DataLayer dl;
        public MemberList()
        {
            dl = new DataLayer();
        }
        public async Task<IEnumerable<MemberListModel>> getMemberList(MemberSearchModel MemberSearch)
        {
            try { 
                using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@UIDNumber", MemberSearch.uid);
                    param.Add("@EIDNumber", MemberSearch.eid);
                    param.Add("@sponsorTID", MemberSearch.sponsorTID);
                    string sp = "USP_getMemberList";
                    var result = await db.QueryAsync<MemberListModel>(sp, param, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex) {
                return null;
                
            }
        }
        public async Task<IEnumerable<MemberSuccess>> SubmitMemberCreation(SubmitFormMember MemberSubmit)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@DOB", MemberSubmit.DOB);
                    param.Add("@EIDApplicationNumber", MemberSubmit.EIDApplicationNumber);
                    param.Add("@EmiratesID", MemberSubmit.EmiratesID);
                    param.Add("@FirstName", MemberSubmit.FirstName);
                    param.Add("@Gender", MemberSubmit.Gender);
                    param.Add("@Height", MemberSubmit.Height);
                    param.Add("@MiddleName", MemberSubmit.MiddleName);

                    param.Add("@MaritalStatus", MemberSubmit.MaritalStatus);
                    param.Add("@LastName", MemberSubmit.LastName);

                    param.Add("@Nationality", MemberSubmit.Nationality);
                    param.Add("@Occupation", MemberSubmit.Occupation);
                    param.Add("@PassportNumber", MemberSubmit.PassportNumber);
                    param.Add("@PolicyDate", MemberSubmit.PolicyDate);
                    param.Add("@RelationshiptotheSponsor", MemberSubmit.RelationshiptotheSponsor);
                    param.Add("@ResidentialEmirate", MemberSubmit.ResidentialEmirate);
                    param.Add("@Salary", MemberSubmit.Salary);

                    param.Add("@Type", MemberSubmit.Type);
                    param.Add("@UIDNumber", MemberSubmit.UIDNumber);
                    param.Add("@VisaEmirate", MemberSubmit.VisaEmirate);
                    param.Add("@VisaTypeof", MemberSubmit.VisaTypeof);
                    param.Add("@Weight", MemberSubmit.Weight);
                    param.Add("@CreatedBy", MemberSubmit.CreatedBy);
                    param.Add("@sponsorTID", MemberSubmit.sponsorTID);
                    param.Add("@tpaPlanID", MemberSubmit.tpaPlanID);
                    param.Add("@action", MemberSubmit.action);
                    param.Add("@memberID", MemberSubmit.memberID);
                    string sp = "USP_SubmitMemberCreation";
                    var result = await db.QueryAsync<MemberSuccess>(sp, param, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public async Task<IEnumerable<MemberDetailsModel>> getMemberDetailsByID(int MemberID)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@MemberID", MemberID);
                    string sp = "USP_getMemberDetailsById";
                    var result = await db.QueryAsync<MemberDetailsModel>(sp, param, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public async Task<IEnumerable<MemberSuccess>> DeleteMember(int MemberID)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@MemberID", MemberID);
                    string sp = "USP_DeleteMember";
                    var result = await db.QueryAsync<MemberSuccess>(sp, param, commandType: CommandType.StoredProcedure);
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
