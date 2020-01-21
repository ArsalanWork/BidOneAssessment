using MediatR;
using System;

namespace BidOneAssessment.Core.Domain.Marketing.Events
{
    public class ContactStatusUpdated : DomainEvent, INotification
    {
        public ContactStatusUpdated(Guid contactId, ContactStatus status)
        {
            ContactId = contactId;
            Status = status;
        }

        public Guid ContactId { get; private set; }
        public ContactStatus Status { get; private set; }
    }
}
