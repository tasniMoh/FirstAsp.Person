using FirstAspPerson.IRepository;
using FirstAspPerson.Models;
using System.Diagnostics.Metrics;


namespace FirstAspPerson.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
      
        IGenericRepository<Image> Images { get; }

        IGenericRepository<Person> Persons { get; }

        Task Save();

    }
}
