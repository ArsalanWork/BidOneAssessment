﻿using BidOneAssessment.Core;
using System;

namespace BidOneAssessment.QuerySide
{
    public class ContactViewModel
    {
        public Guid ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ContactStatus Status { get; set; }
        public bool InterestedInCommunications { get; set; }
    }
}
