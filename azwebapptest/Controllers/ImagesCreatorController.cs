using ImageCreator.ExternalServices;
using ImageCreator.Logic;
using Microsoft.AspNetCore.Mvc;

namespace azwebapptest.Controllers;

[ApiController]
[Route("[controller]")]
public class ImagesCreatorController : ControllerBase
{
    private readonly ILogger<ImagesCreatorController> _logger;
    private readonly IBlobStorageService _blobService;
    private readonly IConfiguration _configuration;

    public ImagesCreatorController(ILogger<ImagesCreatorController> logger, IBlobStorageService service, 
                                    IConfiguration configuration)
    {
        _logger = logger;
        _blobService = service;
        _configuration = configuration;
    }

    [HttpPost("{imageName}", Name = "CreateImageFromText")]
    public async Task<IActionResult> Post(string imageName, [FromBody] EllipseDimensions dimensions)
    {
        var bitmapStream = ImageCreator.Logic.ImageCreator.Create(dimensions);
        var containerClient = _blobService.GetBlobContainerClient(_configuration["Values:BlobStorageConnectionString"],_configuration["Values:ImageContainerName"]);

        var uri = await _blobService.UploadStream(containerClient, bitmapStream, $"{imageName}.jpg");

        return Ok(new { url = uri.AbsoluteUri });
    }
}
