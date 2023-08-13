/*using FirstAsp.Person.Models;
using Persons.Data;

namespace Persons
{
    public class Seed
    {
        private readonly PersonsDBContext dbContext;

        public Seed(PersonsDBContext context)
        {
            this.dbContext = context;
        }

        public void SeedDataContext()
        {
            // Check if the database is already seeded
            if (!dbContext.Persons.Any())
            {
                return;
            }
            // Add initial data here
            var person1 = new Person
            {
                Name = "Reza",
                LastName = "Sadeqi",
                NationalCode = 123456789

            };

            var person2 = new Person
            {
                Name = "Moana",
                LastName = "Smith",
                NationalCode = 987654321
            };


            dbContext.Persons.AddRange(person1, person2);
            dbContext.SaveChanges();

        }


    }
}*/