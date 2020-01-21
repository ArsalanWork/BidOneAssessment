using BidOneAssessment.Application.Commands;
using BidOneAssessment.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BidOneAssessment.Application.CommandHandlers
{
    public class UpdateContactHandler : IRequestHandler<UpdateContact, bool>
    {
        private readonly IContactRepository _repository;

        public UpdateContactHandler(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateContact request, CancellationToken cancellationToken)
        {
            var contact = await _repository.GetAsync(request.ContactId);
            if (contact == null)
            {
                // throw not found exception
            }

            contact.Update(request.FirstName, request.LastName, request.Email);

            _repository.Update(contact);

            return await _repository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
