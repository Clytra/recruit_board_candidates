using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecruitBoard.Services.Candidates.Application.Features.Educations.Commands.CreateEducation;
using RecruitBoard.Services.Candidates.Application.Features.Educations.Commands.DeleteEducation;

namespace RecruitBoard.Services.Candidates.Api.Endpoints;

public static class EducationEndpoints
{
    public static void MapEducationEndpoints(this WebApplication app)
    {
        app.MapPost("/educations", async (
            [FromBody] CreateEducationCommand command, IMediator mediator) =>
        {
            var educationId = await mediator.Send(command);
            return Results.Created($"/educations/{educationId}", command);
        });
        
        app.MapDelete("/educations/{id:guid}", async (Guid id, IMediator mediator) =>
        {
            await mediator.Send(new DeleteEducationCommand() { EducationId = id });
            return Results.Ok(new { Message = "Education removed successfully." });
        });
    }
}