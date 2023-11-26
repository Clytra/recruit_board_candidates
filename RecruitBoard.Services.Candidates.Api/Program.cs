using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using RecruitBoard.Services.Candidates.Application.Features.Candidates.Commands.CreateCandidate;
using RecruitBoard.Services.Candidates.Application.Features.Candidates.Commands.DeleteCandidate;
using RecruitBoard.Services.Candidates.Application.Features.Candidates.Commands.UpdateCandidate;
using RecruitBoard.Services.Candidates.Application.Features.Candidates.Queries.GetCandidate;
using RecruitBoard.Services.Candidates.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(cfg =>
{
    cfg.SwaggerDoc("v1", new OpenApiInfo { Title = "RecruitBoard", Version = "v1" });
});

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region Endpoints

app.MapGet("/candidates", async (IMediator mediator) 
    => await mediator.Send(new GetCandidateQuery()));

app.MapGet("/candidates/{id}", async (Guid id, IMediator mediator) 
    => await mediator.Send(new GetCandidateQuery { Id = id }));

app.MapPost("/candidates", async (
    [FromBody] CreateCandidateCommand command, IMediator mediator) =>
{
    var candidateId = await mediator.Send(command);
    return Results.Created($"/candidates/{candidateId}", command);
});

app.MapPut("/candidates/{id}", async (
    [FromQuery] Guid id, [FromBody] UpdateCandidateCommand command, IMediator mediator) =>
{
    command.CandidateId = id;
    return Results.Ok();
});

app.MapDelete("/candidates/{id}", async (Guid id, IMediator mediator) =>
{
    await mediator.Send(new DeleteCandidateCommand { CandidateId = id });
    return Results.Ok();
});

#endregion

app.Run();