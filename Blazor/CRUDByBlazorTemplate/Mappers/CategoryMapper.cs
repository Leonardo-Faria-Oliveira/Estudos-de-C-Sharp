

using CRUDByBlazorTemplate.Dtos;
using CRUDByBlazorTemplate.Models;
using CRUDByBlazorTemplate.Request;
using CRUDByBlazorTemplate.Response;
using CRUDByBlazorTemplate.Utils;

namespace CRUDByBlazorTemplate.Mappers
{
    public class CategoryMapper : IBaseMapper<Category, CategoryDto, CategoryByIdResponse, CategoryResponse, CategoryRequest>
    {

        public Category ToModel(CategoryDto categoryDto)
        {
        
            return new Category
            {
               Title = categoryDto.Title,
               Description = categoryDto.Description
            };

        }

        public Category ToModel(CategoryRequest categoryRequest)
        {

            return new Category
            {
                Title = categoryRequest.Title,
               Description = categoryRequest.Description
            };

        }

        public CategoryDto ToDto(Category category)
        {

            return new CategoryDto
            {
                Id = category.Id,
                Title = category.Title,
                Description = category.Description,
                CreatedAt = category.CreatedAt,
                UpdatedAt = category.UpdatedAt
            };
            
        }

        
        
        
        public CategoryByIdResponse ToResponseById(Category category)
        {
            return new CategoryByIdResponse
            {

                CategoryDto = ToDto(category)

            };
        }

        public CategoryResponse ToResponse(Pagination<Category> pagination)
        {
            
            var categoryDtos = new List<CategoryDto>();
            foreach (var category in pagination.Content)
            {
                categoryDtos.Add(ToDto(category));
            }

            return new CategoryResponse
            {
                Skip = pagination.Skip,
                Take = pagination.Take,
                Total = pagination.Total,
                CategoryDtos = categoryDtos
            };
        }
    }
}
