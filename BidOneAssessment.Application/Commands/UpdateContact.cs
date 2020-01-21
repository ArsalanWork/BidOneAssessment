using System;
using System.Collections.Generic;
using System.Text;

namespace BidOneAssessment.Application.Commands
{
    public class UpdateContact
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
