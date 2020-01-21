using BidOneAssessment.Core;
using BidOneAssessment.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BidOneAssessment.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly BidOneAssessmentContext _context;

        public ContactRepository(BidOneAssessmentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Add(Contact toSave)
        {
            _context.Contacts.Add(toSave);
        }

        public async Task<bool> CheckIfExistsAsync(Guid contactId)
        {
            return _context.Contacts.Any(c => c.Id == contactId);
        }

        public async Task<Contact> GetAsync(Guid contactId)
        {
            var contact = await _context.Contacts
                .Where(c => c.Id == contactId)
                .SingleOrDefaultAsync();

            return contact;
        }

        public void Update(Contact toUpdate)
        {
            _context.Contacts.Update(toUpdate);
        }
    }
}
