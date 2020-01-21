using MediatR;
using System;

namespace BidOneAssessment.Core
{
    public class Command : IRequest
    {
        public Command()
        {
            this.CommandId = Guid.NewGuid();
            this.TriggeredAt = DateTime.UtcNow;
        }
        public Guid CommandId { get; private set; }
        public DateTime TriggeredAt { get; private set; }

        // Command is triggered by WebAPI during HTTP request handling while the TriggeredBy is set in the WebAPI method using user identity
        public Guid TriggeredBy { get; set; }
    }
}
