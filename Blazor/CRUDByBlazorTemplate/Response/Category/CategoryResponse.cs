using CRUDByBlazorTemplate.Dtos;

namespace CRUDByBlazorTemplate.Response
{
    public class CategoryResponse
    {

        public int Skip { get; set; }

        public int Take { get; set; }

        public int Total { get; set; }

        public List<CategoryDto>? CategoryDtos { get; set; }

    }
}
