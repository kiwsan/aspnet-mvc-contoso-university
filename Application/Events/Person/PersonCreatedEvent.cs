using MediatR;

namespace Application.Events.Person
{
    public class PersonCreatedEvent : INotification
    {
        public PersonCreatedEvent(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}