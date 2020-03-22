using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Models
{
    public class SeedData
    {
        private PersonContext _context;

        public SeedData(PersonContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (!_context.Person.Any())
            {
                var obj1 = new Person()
                {
                    FullName = "Ram Krishna",
                    Address = "15C Cornelia ct",
                    Age = 25,
                    Interests = "Cars, Bikes",
                };
                _context.Person.Add(obj1);

                var obj2 = new Person()
                {
                    FullName = "Rohith",
                    Address = "5C Cornelia ct",
                    Age = 24,
                    Interests = "Technology and Finance",
                };
                _context.Person.Add(obj2);

                var obj3 = new Person()
                {
                    FullName = "Satya",
                    Address = "5A Smith st",
                    Age = 28,
                    Interests = "Food",
                };
                _context.Person.Add(obj3);

                await _context.SaveChangesAsync();
            }
        }
    }
}
