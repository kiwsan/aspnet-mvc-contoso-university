using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Events.Person
{
    public class PersonEventHandlersAsync : INotificationHandler<PersonCreatedEvent>
    {
        public Task Handle(PersonCreatedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Hello Notification");

            return Task.CompletedTask;
        }
    }
}