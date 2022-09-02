using BusinessEntities;
using BusinessEntities.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessService.Interface
{
    public interface IMember
    {
        Task<IEnumerable<MemberListModel>> getMemberList(MemberSearchModel MemberSearch);
        Task<IEnumerable<MemberSuccess>> SubmitMemberCreation(SubmitFormMember submitMember);
        Task<IEnumerable<MemberDetailsModel>> getMemberDetailsByID(int MemberID);
        Task<IEnumerable<MemberSuccess>> DeleteMember(int MemberID);
    }
}
