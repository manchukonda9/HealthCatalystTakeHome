using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PeopleSearch.Models
{
    public class PersonContext : DbContext
    {
        public PersonContext() { }

        public PersonContext(DbContextOptions<PersonContext> options)
            : base(options) 
        { }

        public virtual DbSet<Person> Person { get; set; }
    }

    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        public string Address { get; set; }

        public int Age { get; set; }

        public string Interests { get; set; }
    }
}
