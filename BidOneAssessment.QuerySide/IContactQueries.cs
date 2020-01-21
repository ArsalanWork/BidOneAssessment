using System.Collections.Generic;
using System.Threading.Tasks;

namespace BidOneAssessment.QuerySide
{
    public interface IContactQueries
    {
        Task<IEnumerable<ContactViewModel>> GetContactsAsync(int page, int pageSize);
    }
}
