using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BulkyWeb.Repository
{
    public class Repository <T> : IRepository <T> where T : class
    {

        private readonly AppDbContext _db;
        private DbSet<T> _dbSet;

        public Repository(AppDbContext db)
        {
            _db = db;
            this._dbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
            
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public T Get(Expression<Func<T, bool>> Filter)
        {
            IQueryable <T> query = _dbSet;
             query= query.Where(Filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbSet;
            return query.OrderBy(a=>a).ToList();

        }
    }
}
