using Microsoft.AspNetCore.Http;

namespace RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;

public interface ICloudStorageService
{
    Task UploadFileAsync(IFormFile file, string identifier);
}