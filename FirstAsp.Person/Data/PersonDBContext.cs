using FirstAsp.Person.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace Persons.Data
{
    public class PersonsDBContext : DbContext
    {
        public PersonsDBContext(DbContextOptions<PersonsDBContext> options) : base(options)
        {

        }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Person>()
                .HasKey(p => new { p.NationalCode });

            modelBuilder.Entity<Person>()
               .HasIndex(p => p.NationalCode)
               .IsUnique();

            modelBuilder.Entity<Image>()
                .HasOne(i => i.Person)
                .WithMany(p => p.Images)
                .HasForeignKey(i => i.PersonId);


            modelBuilder.Entity<Person>()
                .HasData(
                new Person
                {

                    Name = "Reza",
                    LastName = "Sadeqi",
                    NationalCode = 123456789
                },
                new Person
                {
                    Name = "Moana",
                    LastName = "Smith",
                    NationalCode = 987654321
                }
                );



        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Image> Images { get; set; }

    }
}
