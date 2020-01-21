using MediatR;
using System;

namespace BidOneAssessment.Core.Domain.Marketing.Events
{
    public class ContactSubscribed : DomainEvent, INotification
    {
        public ContactSubscribed(Guid contactId)
        {
            this.ContactId = contactId;
        }

        public Guid ContactId { get; private set; }
    }
}
