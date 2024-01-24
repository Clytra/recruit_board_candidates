using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecruitBoard.Services.Candidates.Application.Features.Experiences.Commands.CreateExperience;
using RecruitBoard.Services.Candidates.Application.Features.Experiences.Commands.DeleteExperience;

namespace RecruitBoard.Services.Candidates.Api.Endpoints;

public static class ExperienceEndpoints
{
    public static void MapExperienceEndpoints(this WebApplication app)
    {
        app.MapPost("/experiences", async (
            [FromBody] CreateExperienceCommand command, IMediator mediator) =>
        {
            var experienceId = await mediator.Send(command);
            return Results.Created($"/experiences/{experienceId}", command);
        });
        
        app.MapDelete("/experiences/{id:guid}", async (Guid id, IMediator mediator) =>
        {
            await mediator.Send(new DeleteExperienceCommand() { ExperienceId = id });
            return Results.Ok(new { Message = "Experience removed successfully." });
        });
    }
}