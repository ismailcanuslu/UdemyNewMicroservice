using Microservice.Catalog.API.Features.Categories.Dtos;

namespace Microservice.Catalog.API.Features.Categories.GetById;

public class GetCategoryByIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, ServiceResult<CategoryDto>>
{
    public async Task<ServiceResult<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var existingCategory = await context.Categories.FindAsync(request.Id, cancellationToken);

        if (existingCategory is null)
        {
            return ServiceResult<CategoryDto>.Error("Category not found", $"The category with Id{{{request.Id}}} does not exist",HttpStatusCode.NotFound);
        }
        
        var categoryAsDto = mapper.Map<CategoryDto>(existingCategory);
        return ServiceResult<CategoryDto>.SuccessAsOk(categoryAsDto);
    }
}