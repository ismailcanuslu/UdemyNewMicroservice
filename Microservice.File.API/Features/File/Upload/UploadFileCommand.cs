using Microservice.Shared;

namespace Microservice.File.API.Features.File.Upload;

public record UploadFileCommand(IFormFile File) : IRequestByServiceResult<UploadFileCommandResponse>;