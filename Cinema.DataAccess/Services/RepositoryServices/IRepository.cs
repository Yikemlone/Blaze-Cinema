namespace Cinema.DataAccess.Services.RepositoryServices
{
    public interface IRepository<T> where T : class
    {
        public Task AddAsync(T obj);
        public Task UpdateAsync(T obj);
        public Task DeleteAsync(T obj);
        public Task<List<T>> GetAllAsync();
        public Task<T> GetAsync(int id);
    }
}
