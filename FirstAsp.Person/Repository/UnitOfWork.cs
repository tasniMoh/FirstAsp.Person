using Api.IRepository;
using FirstAsp.Person.IRepository;
using FirstAsp.Person.Models;
using Persons.Data;
using System.Diagnostics.Metrics;

namespace FirstAsp.Person.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersonsDBContext _context;
        private IGenericRepository<Image> _images;
        private IGenericRepository<Person> _persons;

        public UnitOfWork(PersonsDBContext context)
        {
            _context = context;
        }

        public IGenericRepository<Image> Images=>_images ??=new Generic_Repository<Image>(_context)

        public IGenericRepository<Person> _persons => new Generic_Repository<Person>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }


}
