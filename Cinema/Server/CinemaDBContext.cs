using Microsoft.EntityFrameworkCore;

namespace Cinema.Server
{
    public class CinemaDBContext : DbContext 
    {
        public CinemaDBContext(DbContextOptions options) : base(options) 
        {
        }

        //DbSet<>
    }
}
