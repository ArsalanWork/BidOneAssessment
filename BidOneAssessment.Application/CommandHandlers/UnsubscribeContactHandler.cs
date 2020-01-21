using BidOneAssessment.Application.Commands;
using BidOneAssessment.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BidOneAssessment.Application.CommandHandlers
{
    public class UnsubscribeContactHandler : IRequestHandler<UnsubscribeContact, bool>
    {
        private readonly IContactRepository _repository;

        public UnsubscribeContactHandler(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UnsubscribeContact request, CancellationToken cancellationToken)
        {
            var contact = await _repository.GetAsync(request.ContactId);
            if (contact == null)
            {
                // throw not found exception
            }

            contact.Unsubscribe();

            _repository.Update(contact);

            return await _repository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
