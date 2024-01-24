using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;
using RecruitBoard.Services.Candidates.Application.Features.Candidates.Commands.CreateCandidate;
using RecruitBoard.Services.Candidates.Application.Features.Candidates.Commands.DeleteCandidate;
using RecruitBoard.Services.Candidates.Application.Features.Candidates.Commands.UpdateCandidate;
using RecruitBoard.Services.Candidates.Application.Features.Candidates.Queries.GetCandidate;
using RecruitBoard.Services.Candidates.Application.Features.Candidates.Queries.GetCandidates;

namespace RecruitBoard.Services.Candidates.Api.Endpoints;

public static class CandidateEndpoints
{
    public static void MapCandidateEndpoints(this WebApplication app)
    {
        app.MapGet("/candidates", async (IMediator mediator) 
            => await mediator.Send(new GetCandidatesQuery()));

        app.MapGet("/candidates/{id:guid}", async (Guid id, IMediator mediator) 
            => await mediator.Send(new GetCandidateQuery { Id = id }));

        app.MapPost("/candidates", async (
            IFormFile file, 
            [FromForm] CreateCandidateCommand command, 
            IMediator mediator, 
            ICloudStorageService cloudStorageService) =>
        {
            var response = await mediator.Send(command);

            if (file.Length > 0)
                await cloudStorageService.UploadFileAsync(file, response.CandidateId.ToString());
            
            return Results.Created($"/candidates/{response.CandidateId}", command);
        }).DisableAntiforgery();

        app.MapPut("/candidates/{id:guid}", async (
            Guid id, [FromBody] UpdateCandidateCommand command, IMediator mediator) =>
        {
            command.CandidateId = id;
            await mediator.Send(command);
            return Results.Ok(new { Message = "Candidate updated successfully." });
        });

        app.MapDelete("/candidates/{id:guid}", async (Guid id, IMediator mediator) =>
        {
            await mediator.Send(new DeleteCandidateCommand { CandidateId = id });
            return Results.Ok(new { Message = "Candidate removed successfully." });
        });
    }
}