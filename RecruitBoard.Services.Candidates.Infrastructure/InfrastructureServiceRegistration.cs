using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;
using RecruitBoard.Services.Candidates.Infrastructure.Repositories;

namespace RecruitBoard.Services.Candidates.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("")));

        services.AddScoped(typeof(IAsyncRepository<>), 
            typeof(BaseRepository<>));

        services.AddScoped<ICandidateRepository, CandidateRepository>();

        return services;
    }
}