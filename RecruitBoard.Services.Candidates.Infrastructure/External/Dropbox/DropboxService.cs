using Dropbox.Api;
using Dropbox.Api.Files;
using Microsoft.AspNetCore.Http;
using RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;

namespace RecruitBoard.Services.Candidates.Infrastructure.External.Dropbox;

public class DropboxService(string accessToken) : ICloudStorageService
{
    public async Task UploadFileAsync(IFormFile file, string candidateId)
    {
        var path = $"/{candidateId}/{file.FileName}";

        await using var stream = file.OpenReadStream();
        using var client = new DropboxClient(accessToken);
        await client.Files.UploadAsync(path, WriteMode.Overwrite.Instance, body: stream);
    }

    public async Task<Stream> DownloadAsync(string path)
    {
        using var client = new DropboxClient(accessToken);
        var response = await client.Files.DownloadAsync(path);
        return await response.GetContentAsStreamAsync();
    }
}