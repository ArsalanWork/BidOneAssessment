using MediatR;
using System;

namespace BidOneAssessment.Core.Events
{
    public class ContactUpdated : DomainEvent, INotification
    {
        public ContactUpdated(Guid contactId, string fname, string lname, string email)
        {
            this.ContactId = contactId;
            this.FirstName = fname;
            this.LastName = lname;
            this.Email = email;
        }

        public Guid ContactId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
    }
}