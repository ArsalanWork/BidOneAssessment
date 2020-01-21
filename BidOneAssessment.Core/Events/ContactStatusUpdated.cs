using MediatR;
using System;

namespace BidOneAssessment.Core.Events
{
    public class ContactStatusUpdated : DomainEvent, INotification
    {
        public ContactStatusUpdated(Guid contactId, ContactStatus status)
        {
            this.ContactId = contactId;
            this.Status = status;
        }

        public Guid ContactId { get; private set; }
        public ContactStatus Status { get; private set; }
    }
}
