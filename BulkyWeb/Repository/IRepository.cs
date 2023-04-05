using System.Linq.Expressions;

namespace BulkyWeb.Repository
{
    public interface IRepository <T> where T : class
    {
        IEnumerable<T> GetAll ();
        T Get(Expression<Func<T,bool>> Filter);

        void Add(T entity);  
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);


    }
}
