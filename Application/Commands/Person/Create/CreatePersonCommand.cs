using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Application.Commands.Person.Create
{
    public class CreatePersonCommand : IRequest<int>
    {
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string LastName { get; set; }
    }
}