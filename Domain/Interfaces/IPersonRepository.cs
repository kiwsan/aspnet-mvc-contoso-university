using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPersonRepository
    {

        Task<Person> GetAsync(CancellationToken cancellation);
        Task<IEnumerable<Person>> BrowsAsync(CancellationToken cancellation);
        Task<Person> FindByIdAsync(Guid id, CancellationToken cancellation);
        Task AddAsync(Person person, CancellationToken cancellation);
        Task UpdateAsync(Person person, CancellationToken cancellation);
        Task RemoveAsync(Guid id, CancellationToken cancellation);

    }
}
