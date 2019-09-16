using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Entities
{
    [Table("tb_person")]
    public class Person : EntityBase
    {

        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public class PersonConfiguration : EntityTypeConfiguration<Person>
        {
            public PersonConfiguration()
            {

                Property(x => x.FirstName)
                    .HasColumnName("first_name");

                Property(x => x.LastName)
                    .HasColumnName("last_name");

                Property(x => x.BirthDate)
                    .HasColumnName("birth_date");

                Property(x => x.CreatedDate)
                    .HasColumnName("created_date");

            }
        }

    }
}