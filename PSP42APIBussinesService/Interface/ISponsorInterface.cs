using BusinessEntities;
using BusinessEntities.Sponsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessService.Interface
{
    public interface ISponsorInterface
    {
        Task<IEnumerable<SponsorSuccess>> SubmitSponsorCreation(SponsorSubmit Logincred);
        Task<IEnumerable<SponsorDocumentList>> getSponsorDocumentList(string sponsorTID);
        Task<IEnumerable<SponsorSuccess>> getSponsorCheck(string UID);
    }
}
