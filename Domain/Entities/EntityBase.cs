using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/handling-concurrency-with-the-entity-framework-in-an-asp-net-mvc-application
namespace Domain.Entities
{
    public abstract class EntityBase
    {

        [Key]
        [Column("id")]
        public Guid Id { get; protected set; }

        [Timestamp]
        [Column("row_version")]
        public byte[] RowVersion { get; set; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
        }

    }
}
