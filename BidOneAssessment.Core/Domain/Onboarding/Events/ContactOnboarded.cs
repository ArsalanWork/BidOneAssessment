using MediatR;
using System;

namespace BidOneAssessment.Core.Domain.Onboarding.Events
{
    public class ContactOnboarded : DomainEvent, INotification
    {
        public ContactOnboarded(Guid contactId, Guid membershipId)
        {
            this.ContactId = contactId;
            this.MembershipId = membershipId;
        }

        public Guid ContactId { get; private set; }

        public Guid MembershipId { get; private set; }
    }
}
