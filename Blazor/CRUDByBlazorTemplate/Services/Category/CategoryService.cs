﻿using CRUDByBlazorTemplate.Dtos;
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

        public CategoryService(ICategoryRepository repository, IBaseMapper<Category, CategoryDto, CategoryByIdResponse, CategoryResponse, CategoryRequest> categoryMapper)
        {
            _repository = repository;
            _mapper = categoryMapper;
        }

        public async Task<ServiceResponse> Delete(Guid id)
        {
            var category = await _repository.GetById(id);
            if(category == null)
            {
                return ServiceResponse.Factory
                (
                    HttpStatusCode.NotFound,
                    "Categoria não encontrada"
                );
                
                
            }
            await _repository.Delete(category);

            return ServiceResponse.Factory
            (
                HttpStatusCode.OK,
                "Categoria deletada com sucesso"
            );
        }

        public async Task<ServiceResponse> Get(int take, int skip, string? search)
        {
            var categories = await _repository.Get(take, skip, search);

            var response = _mapper.ToResponse(categories);

            return ServiceResponse.Factory
            (
                HttpStatusCode.OK,
                "Categorias encontradas com sucesso",
                response
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

            category.Title = entity.Title;
            category.Description = entity.Description;   

            await _repository.Patch(category);

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
