using BidOneAssessment.Core;
using MediatR;
using System;

namespace BidOneAssessment.Application.Commands
{
    public class UpdateContact : Command, IRequest<bool>
    {
        public Guid ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
