using MediatR;
using System;

namespace BidOneAssessment.Core.Domain.CustomerService
{
    public class MembershipClosed : DomainEvent, INotification
    {
        public MembershipClosed(Guid membershipId)
        {
            this.MembershipId = membershipId;
        }
        
        public Guid MembershipId { get; private set; }
    }
}
