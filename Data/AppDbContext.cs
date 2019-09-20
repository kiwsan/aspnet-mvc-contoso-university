using Domain.Entities;
using System.Data.Entity;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=mvc-contoso;Integrated Security=SSPI;") { }

        public DbSet<Person> TablePersons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new Person.PersonConfiguration());
        }
    }
}