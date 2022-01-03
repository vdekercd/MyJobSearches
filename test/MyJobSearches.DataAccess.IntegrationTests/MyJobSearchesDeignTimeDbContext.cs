namespace MyJobSearches.DataAccess.IntegrationTest;

public class MyJobSearchesDeignTimeDbContext : IDesignTimeDbContextFactory<MyJobSearchesDbContext>
{
    public MyJobSearchesDbContext Create()
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!;
        var basePath = AppContext.BaseDirectory;

        return Create(basePath, environmentName);
    }

    public MyJobSearchesDbContext CreateDbContext(string[] args)
    {
        return Create(
            Directory.GetCurrentDirectory(),
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!);
    }

    private MyJobSearchesDbContext Create(string basePath, string environmentName)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environmentName}.json", true)
            .AddEnvironmentVariables();

        var config = builder.Build();

        var connstr = config.GetConnectionString("default");

        if (string.IsNullOrWhiteSpace(connstr) == true)
        {
            throw new InvalidOperationException(
                "Could not find a connection string named 'default'.");
        }
        else
        {
            return Create(connstr);
        }
    }

    private MyJobSearchesDbContext Create(string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
            throw new ArgumentException(
               $"{nameof(connectionString)} is null or empty.",
               nameof(connectionString));

        var optionsBuilder =
          new DbContextOptionsBuilder<MyJobSearchesDbContext>();

        Console.WriteLine(
         "MyJobSearchesDesignTimeDbContextFactory.Create(string): Connection string: {0}",
         connectionString);

        optionsBuilder.UseSqlServer(connectionString);

        return new MyJobSearchesDbContext(optionsBuilder.Options);
    }
}

