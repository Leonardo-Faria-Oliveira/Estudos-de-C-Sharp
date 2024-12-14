using CRUDByBlazorTemplate.Dtos;
using CRUDByBlazorTemplate.Mappers;
using CRUDByBlazorTemplate.Models;
using CRUDByBlazorTemplate.Repository;
using CRUDByBlazorTemplate.Request;
using CRUDByBlazorTemplate.Response;
using CRUDByBlazorTemplate.Services;
using CRUDByBlazorTemplate.Utils;
using System.Net;

namespace CRUDByBlazorTemplate.Service
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _repository;
        private readonly IBaseMapper<Category, CategoryDto, CategoryByIdResponse, CategoryResponse, CategoryRequest> _mapper;

        public async Task<ServiceResponse> Delete(Guid id)
        {
            var category = await _repository.GetById(id);
            if(category == null)
            {
                return ServiceResponse.Factory
                (
                    HttpStatusCode.NotFound,
                    "Categoria não encontrada",
                     null
                );
                
                
            }
            await _repository.Delete(category);

            return ServiceResponse.Factory
            (
                HttpStatusCode.OK,
                "Categoria deletada com sucesso",
                 null
            );
        }

        public async Task<ServiceResponse> Get(int skip, int take, string? search)
        {
            var categories = await _repository.Get(skip, take, search);

            var response = _mapper.ToResponse(categories);

            return ServiceResponse.Factory
            (
                HttpStatusCode.OK,
                "Categorias encontradas com sucesso",
                categories
            );
        }

        public async Task<ServiceResponse> GetById(Guid id)
        {
            var category = await _repository.GetById(id);

            if (category == null)
            {
                return ServiceResponse.Factory
                (
                    HttpStatusCode.NotFound,
                    "Categoria não encontrada",
                     null
                );
            }

            var categoryResponse = _mapper.ToResponseById(category);

            return ServiceResponse.Factory
            (
                HttpStatusCode.OK,
                "Categoria encontrada com sucesso",
                categoryResponse
            );
        }

        public async Task<ServiceResponse> Patch(Guid id, CategoryRequest entity)
        {
            var category = _repository.GetById(id);

            if(category == null)
            {
                return ServiceResponse.Factory
                (
                    HttpStatusCode.NotFound,
                    "Categoria não encontrada",
                     null
                );
            }

            var mappedCategory = _mapper.ToModel(entity);

            await _repository.Patch(mappedCategory);

            return ServiceResponse.Factory
            (
                HttpStatusCode.OK,
                "Categoria atualizada com sucesso",
                 entity
            );
        }

        public async Task<ServiceResponse> Post(CategoryRequest entity)
        {
            var mappedCategory = _mapper.ToModel(entity);

            await _repository.Post(mappedCategory);

            return ServiceResponse.Factory
            (
                HttpStatusCode.OK,
                "Categoria atualizada com sucesso",
                 entity
            );
        }
    }
}
