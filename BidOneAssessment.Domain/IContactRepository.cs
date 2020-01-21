using BidOneAssessment.Core;
using System;
using System.Threading.Tasks;

namespace BidOneAssessment.Domain
{
    public interface IContactRepository : IRepository<Contact>
    {
        void Add(Contact toSave);
        void Update(Contact toUpdate);
        Task<Contact> GetAsync(Guid contactId);
        Task<bool> CheckIfExistsAsync(Guid contactId);
    }
}
