using BidOneAssessment.Application.Commands;
using BidOneAssessment.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BidOneAssessment.Application.CommandHandlers
{
    public class SubscribeContactHandler : IRequestHandler<SubscribeContact, bool>
    {
        private readonly IContactRepository _repository;

        public SubscribeContactHandler(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(SubscribeContact request, CancellationToken cancellationToken)
        {
            var contact = await _repository.GetAsync(request.ContactId);
            if (contact == null)
            {
                // throw not found exception
            }

            contact.Subscribe();

            _repository.Update(contact);

            return await _repository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
