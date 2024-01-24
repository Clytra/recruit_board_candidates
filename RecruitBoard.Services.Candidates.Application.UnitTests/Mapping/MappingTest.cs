using AutoMapper;

namespace RecruitBoard.Services.Candidates.Application.UnitTests.Mapping;

public class MappingTest(MappingTestFixture fixture) : IClassFixture<MappingTestFixture>
{
    private readonly IConfigurationProvider _configuration = fixture.ConfigurationProvider;
    private readonly IMapper _mapper = fixture.Mapper;

    [Fact]
    public void ShouldHaveValidConfiguration()
        => _configuration.AssertConfigurationIsValid();
}