using BidOneAssessment.Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BidOneAssessment.Application.CommandValidators
{
    public class UnsubscribeContactValidator : AbstractValidator<UnsubscribeContact>
    {
        public UnsubscribeContactValidator()
        {
            RuleFor(cmd => cmd.ContactId).NotEqual(default(Guid));
        }
    }
}
