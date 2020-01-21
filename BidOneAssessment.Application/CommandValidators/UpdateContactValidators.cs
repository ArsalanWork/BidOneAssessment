using System;
using BidOneAssessment.Application.Commands;
using BidOneAssessment.Core;
using FluentValidation;

namespace BidOneAssessment.Application.CommandValidators
{
    public class UpdateContactValidators : AbstractValidator<UpdateContact>
    {
        public UpdateContactValidators()
        {
            RuleFor(cmd => cmd.ContactId).NotEqual(default(Guid));
            RuleFor(cmd => cmd.FirstName).NotEmpty().NotExecutableScript();
            RuleFor(cmd => cmd.LastName).NotEmpty().NotExecutableScript();
            RuleFor(cmd => cmd.Email).NotEmpty().NotExecutableScript().EmailAddress();
        }
    }
}
