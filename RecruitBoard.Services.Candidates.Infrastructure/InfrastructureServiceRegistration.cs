using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;
using RecruitBoard.Services.Candidates.Infrastructure.External.Azure;
using RecruitBoard.Services.Candidates.Infrastructure.Repositories;

namespace RecruitBoard.Services.Candidates.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddSingleton<BlobServiceClient>(provider =>
        {
            var connectionString = configuration.GetConnectionString("BlobStorageConnection");
            return new BlobServiceClient(connectionString);
        });
        
        services.AddSingleton<ICloudStorageService, BlobStorageService>(provider =>
        {
            var blobServiceClient = provider.GetRequiredService<BlobServiceClient>();
            var containerName = configuration["AzureBlobStorageConfiguration:ContainerName"];
            return new BlobStorageService(blobServiceClient, containerName);
        });

        services.AddScoped(typeof(IAsyncRepository<>), 
            typeof(BaseRepository<>));
        services.AddScoped<ICandidateRepository, CandidateRepository>();

        return services;
    }
}