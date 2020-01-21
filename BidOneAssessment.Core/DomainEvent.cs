using MediatR;
using System;

namespace BidOneAssessment.Core
{
    public class DomainEvent
    {
        public DomainEvent()
        {
            this.EventId = Guid.NewGuid();
            this.OccurredAt = DateTime.UtcNow;
        }
        public Guid EventId { get; private set; }
        public Guid CommandCoorelationId { get; set; }
        public DateTime OccurredAt { get; private set; }
    }
}
