using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;

namespace RecruitBoard.Services.Candidates.Infrastructure.External.Azure;

public class BlobStorageService : ICloudStorageService
{
    private readonly BlobServiceClient _blobServiceClient;
    private string _containerName;

    public BlobStorageService(
        BlobServiceClient blobServiceClient,
        string containerName)
    {
        _blobServiceClient = blobServiceClient;
        _containerName = containerName;
    }
    
    public async Task UploadFileAsync(IFormFile file, string candidateId)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
        await containerClient.CreateIfNotExistsAsync();

        var blobClient = containerClient.GetBlobClient($"{candidateId}/{file.FileName}");

        await using var stream = file.OpenReadStream();
        await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = file.ContentType });
    }
}