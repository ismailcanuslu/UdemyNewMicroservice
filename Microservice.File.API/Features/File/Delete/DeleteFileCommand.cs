using Microservice.Shared;

namespace Microservice.File.API.Features.File.Delete;

public record DeleteFileCommand(string FileName) : IRequestByServiceResult;
