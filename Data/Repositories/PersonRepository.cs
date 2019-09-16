using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;
        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Person person, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> BrowsAsync(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<Person> FindByIdAsync(Guid id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetAsync(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Person person, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

    }
}
