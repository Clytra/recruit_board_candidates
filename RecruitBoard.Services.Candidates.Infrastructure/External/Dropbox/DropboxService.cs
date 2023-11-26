using Dropbox.Api;
using Dropbox.Api.Files;

namespace RecruitBoard.Services.Candidates.Infrastructure.External.Dropbox;

public class DropboxService
{
    private readonly string _accessToken;

    public DropboxService(string accessToken)
    {
        _accessToken = accessToken;
    }

    public async Task UploadAsync(string path, Stream stream)
    {
        using var client = new DropboxClient(_accessToken);
        await client.Files.UploadAsync(path, WriteMode.Overwrite.Instance, body: stream);
    }

    public async Task<Stream> DownloadAsync(string path)
    {
        using var client = new DropboxClient(_accessToken);
        var response = await client.Files.DownloadAsync(path);
        return await response.GetContentAsStreamAsync();
    }
}