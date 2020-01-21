using BidOneAssessment.Application.Commands;
using BidOneAssessment.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BidOneAssessment.Application.CommandHandlers
{
    public class CreateContactHandler : IRequestHandler<CreateContact, bool>
    {
        private readonly IContactRepository _repository;

        public CreateContactHandler(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateContact request, CancellationToken cancellationToken)
        {
            if (await _repository.CheckIfExistsAsync(request.ContactId))
            {
                // throw already exists exception
            }

            var contact = new Contact(request.ContactId, request.FirstName, request.LastName, request.Email);
            
            _repository.Add(contact);

            return await _repository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
