using BidOneAssessment.Core;
using MediatR;
using System;

namespace BidOneAssessment.Application.Commands
{
    public class SubscribeContact : Command, IRequest<bool>
    {
        public Guid ContactId { get; set; }
    }
}
