using MediatR;
using System;

namespace BidOneAssessment.Core.Domain.Marketing.Events
{
    public class ContactCreated : DomainEvent, INotification
    {
        public ContactCreated(Guid contactId, string fname, string lname, string email)
        {
            ContactId = contactId;
            FirstName = fname;
            LastName = lname;
            Email = email;
        }

        public Guid ContactId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
    }
}
