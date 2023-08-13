using Api.IRepository;
using FirstAsp.Person.Models;
using System.Diagnostics.Metrics;
using Persons.Data;

namespace FirstAsp.Person.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
      
        IGenericRepository<Image> Images { get; }

        IGenericRepository<Person> Persons { get; }

        Task Save();

    }
}
