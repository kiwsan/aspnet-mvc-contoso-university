using System.Threading;
using System.Threading.Tasks;
using Application.Commands.Person.Create;
using Application.Events.Person;
using MediatR;

namespace Application.Commands.Person
{
    public class PersonCommandHandlersAsync : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IMediator _mediator;

        public PersonCommandHandlersAsync(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            _mediator.Publish(new PersonCreatedEvent(request.FirstName, request.LastName));

            return Task.FromResult(1);
        }
    }
}