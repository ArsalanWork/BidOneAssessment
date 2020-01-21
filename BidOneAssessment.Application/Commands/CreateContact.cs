using System;

namespace BidOneAssessment.Application.Commands
{
    public class CreateContact
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
