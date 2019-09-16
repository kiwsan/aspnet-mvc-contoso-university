using Application.Commands.Person.Create;
using Application.Events.Person;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Person
{
    public class PersonCommandHandlersAsync : IRequestHandler<CreatePersonCommand, int>
    {

        private readonly IPersonRepository _personRepository;
        private readonly IMediator _mediator;

        public PersonCommandHandlersAsync(IPersonRepository personRepository, IMediator mediator)
        {
            _personRepository = personRepository;
            _mediator = mediator;
        }

        public Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            _mediator.Publish(new PersonCreatedEvent(request.FirstName, request.LastName));

            return Task.FromResult(1);
        }

    }
}