using Microsoft.OpenApi.Models;
using RecruitBoard.Services.Candidates.Api.Endpoints;
using RecruitBoard.Services.Candidates.Application;
using RecruitBoard.Services.Candidates.Infrastructure;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(cfg =>
        {
            cfg.SwaggerDoc("v1", new OpenApiInfo { Title = "RecruitBoard", Version = "v1" });
        });

        builder.Services.AddApplicationServices();
        builder.Services.AddAntiforgery();
        builder.Services.AddInfrastructure(builder.Configuration);

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAntiforgery();

        app.MapCandidateEndpoints();
        app.MapEducationEndpoints();
        app.MapExperienceEndpoints();

        app.Run();
    }
}