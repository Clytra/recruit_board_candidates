using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using RecruitBoard.Services.Candidates.Api.IntegrationTests.Common;
using RecruitBoard.Services.Candidates.Application.Features.Candidates.Queries.GetCandidates;

namespace RecruitBoard.Services.Candidates.Api.IntegrationTests.Endpoints;

public class CandidateEndpointsTests(CustomWebApplicationFactory<Program> factory)
    : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient(new WebApplicationFactoryClientOptions
    {
        AllowAutoRedirect = false
    });

    [Fact]
    public async Task Get_GetCandidates_ReturnsCandidatesList()
    {
        var response = await _client.GetAsync("/candidates");
        response.EnsureSuccessStatusCode();
        
        var responseString = await response.Content.ReadAsStringAsync();
        var candidates = JsonConvert.DeserializeObject<List<CandidatesVm>>(responseString);

        candidates.Should().NotBeNull();
    }
}