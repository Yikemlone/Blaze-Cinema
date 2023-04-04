using Cinema.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DataAccess.Services.RepositoryServices
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        private readonly CinemaDBContext _context;
        internal DbSet<T> _dbSet;

        public Repository(CinemaDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T obj)
        {
            _dbSet.Add(obj);
        }

        public void Delete(T obj)
        {
            _dbSet.Remove(obj);
        }

        public T Get(int id)
        {
            if (id == 0) return null;
            else return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> list = _dbSet;
            return list.ToList();
        }

        public void Update(T obj)
        {
            _dbSet.Update(obj);
        }
    }
}
