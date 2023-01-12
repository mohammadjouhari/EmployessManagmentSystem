using Entities;
using System.Linq.Expressions;

namespace Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DBContext context;
        public Repository(DBContext context)
        {

            this.context = context;

        }
        public IEnumerable<T> GetAll()
        {
            context.Set<T>();
            return context.Set<T>();
        }
        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }
        public void Insert(T entity)
        {
            context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }
    }
}
