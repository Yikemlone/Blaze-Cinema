namespace Cinema.UnitTests
{
    public class MovieService
    {
        private readonly DbContextOptions<CinemaDBContext> _options = new DbContextOptionsBuilder<CinemaDBContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        // Test all the methods in the movie service
    }
}
