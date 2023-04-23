namespace Cinema.UnitTests {
    public class ScreeningTests
    {
        private readonly DbContextOptions<CinemaDBContext> _options = new DbContextOptionsBuilder<CinemaDBContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        // Test all methods for screenings service

    }
}