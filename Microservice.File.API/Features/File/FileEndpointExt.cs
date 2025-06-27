using Asp.Versioning.Builder;
using Microservice.File.API.Features.File.Delete;
using Microservice.File.API.Features.File.Upload;

namespace Microservice.File.API.Features.File;

public static class FileEndpointExt
{
    public static void AddFileEndpointGroupExt(this WebApplication app, ApiVersionSet apiVersionSet)
    {
        app.MapGroup("/api/v{version:apiVersion}/files")
            .WithApiVersionSet(apiVersionSet)
            .UploadFileCommandGroupItemEndpoint()
            .DeleteFileCommandGroupItemEndpoint()
            .MapToApiVersion(1,0)
            .WithTags("Files");
    }
}