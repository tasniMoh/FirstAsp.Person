
using FirstAspPerson.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace FirstASpPerson.Data
{
    public class PersonsDBContext : DbContext
    {
        public PersonsDBContext(DbContextOptions<PersonsDBContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Image> Images { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Person>()
                .HasKey(p => new { p.NationalCode });

            modelBuilder.Entity<Person>()
               .HasIndex(p => p.NationalCode)
               .IsUnique();

            modelBuilder.Entity<Image>()
                .HasOne(i => i.Person)
                .WithMany(p =>p.Images)
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

       

    }
}
