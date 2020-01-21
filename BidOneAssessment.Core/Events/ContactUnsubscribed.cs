using MediatR;
using System;

namespace BidOneAssessment.Core.Events
{
    public class ContactUnsubscribed : DomainEvent, INotification
    {
        public ContactUnsubscribed(Guid contactId)
        {
            this.ContactId = contactId;
        }

        public Guid ContactId { get; private set; }
    }
}
