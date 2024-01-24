using System.Data.Common;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using RecruitBoard.Services.Candidates.Infrastructure;

namespace RecruitBoard.Services.Candidates.Api.IntegrationTests.Common;

public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<DataContext>));

            if (dbContextDescriptor != null) services.Remove(dbContextDescriptor);

            var dbConnectionDescriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbConnection));

            if (dbConnectionDescriptor != null) services.Remove(dbConnectionDescriptor);

            var serviceProvder = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            services.AddDbContext<DataContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDatabase");
                options.UseInternalServiceProvider(serviceProvder);
            });

            var sp = services.BuildServiceProvider();

            using var scope = sp.CreateScope();
            var scopedService = scope.ServiceProvider;
            var context = scopedService.GetRequiredService<DataContext>();
            var logger = scopedService.GetRequiredService<ILogger<CustomWebApplicationFactory<TProgram>>>();

            context.Database.EnsureCreated();

            try
            {
                Utilities.InitializeDbForTests(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred seeding the database with test messages." +
                                    $"Error: {ex.Message}");
            } 
        }).UseEnvironment("Test");
    }
}