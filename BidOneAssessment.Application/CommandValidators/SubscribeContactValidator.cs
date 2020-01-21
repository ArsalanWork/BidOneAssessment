using BidOneAssessment.Application.Commands;
using FluentValidation;
using System;

namespace BidOneAssessment.Application.CommandValidators
{
    public class SubscribeContactValidator : AbstractValidator<SubscribeContact>
    {
        public SubscribeContactValidator()
        {
            RuleFor(cmd => cmd.ContactId).NotEqual(default(Guid));
        }
    }
}
