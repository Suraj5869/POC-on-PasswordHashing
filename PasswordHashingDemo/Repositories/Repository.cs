
using Microsoft.EntityFrameworkCore;
using PasswordHashingDemo.Data;

namespace PasswordHashingDemo.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly UserContext _userContext;
        private readonly DbSet<T> _table;
        public Repository(UserContext context)
        {
            _userContext = context;
            _table = _userContext.Set<T>();
        }
        public void Add(T entity)
        {
            _table.Add(entity);
            _userContext.SaveChanges(); 
        }

        public IQueryable<T> GetAll()
        {
            var entity = _table.AsQueryable();
            return entity;
        }
    }
}
