using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Events.Person
{
    public class PersonEventHandlers : INotificationHandler<PersonCreatedEvent>
    {
        public Task Handle(PersonCreatedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Hello Notification");

            return Task.CompletedTask;
        }
    }
}