﻿using FirstAspPerson.IRepository;
using FirstASpPerson.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FirstAspPerson.Repository
{
    public class Generic_Repository<T> : IGenericRepository<T> where T : class
    {


        private readonly PersonsDBContext _context;
        private readonly DbSet<T> _db;

        public Generic_Repository(PersonsDBContext context)
        {
            _context = context;
            _db=_context.Set<T>();
        }
        public async Task Delete(int id)
        {

            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            //it has not async
            _db.RemoveRange(entities);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _db;

            if (includes != null)
            {
                foreach (var includePropperty in includes)
                {
                    query = query.Include(includePropperty);
                }
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query = _db;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                foreach (var includePropperty in includes)
                {
                    query = query.Include(includePropperty);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
