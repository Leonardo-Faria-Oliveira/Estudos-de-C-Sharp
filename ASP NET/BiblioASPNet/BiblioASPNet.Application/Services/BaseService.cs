﻿using AutoMapper;
using BiblioASPNet.Application.Exceptions;
using BiblioASPNet.Application.Models;
using BiblioASPNet.Application.Repositories;
using BiblioASPNet.Application.Requests;
using BiblioASPNet.Application.Responses;
using BiblioASPNet.Application.Utils.Validators;

namespace BiblioASPNet.Application.Services
{
    public abstract class BaseService<T, J, K, L, M> : IService<J, K>
        where J : BaseRequest
        where K : BaseRequest
        where T : BaseModel
    {

        private readonly IRepository<T> _repository;

        private readonly IMapper _mapper;


        protected BaseService(IRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<ServiceResponse> CreateAsync(J entity)
        {

            Validate(entity);

            var obj = _mapper.Map<T>(entity);

            await _repository.CreateAsync(obj);

            var res = _mapper.Map<L>(obj);

            return await Task.FromResult(
                new ServiceResponse(
                    System.Net.HttpStatusCode.OK,
                    ["Sucesso, cadastrado com sucesso!"],
                    res
                )
            );

        }

        public virtual async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
            {
                return await Task.FromResult(
                    new ServiceResponse(
                        System.Net.HttpStatusCode.NotFound,
                        ["Erro, não encontrado"],
                        null
                    )
                );
            }

            var res = await _repository.DeleteAsync(entity);

            if (res)
            {
                return await Task.FromResult(
                    new ServiceResponse(
                        System.Net.HttpStatusCode.OK,
                        ["Sucesso, excluído com sucesso!"],
                        null
                    )
                );
            }

            return await Task.FromResult(
                new ServiceResponse(
                    System.Net.HttpStatusCode.BadRequest,
                    ["Houve um ero, não foi possível excluir, tente novamente"],
                    null
                )
            );
        }

        public virtual async Task<ServiceResponse> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
            {
                return await Task.FromResult(
                    new ServiceResponse(
                        System.Net.HttpStatusCode.NotFound,
                        ["Erro, não encontrado"],
                        null
                    )
                );
            }

            var res = _mapper.Map<M>(entity);

            return await Task.FromResult(
                new ServiceResponse(
                    System.Net.HttpStatusCode.OK,
                    ["Sucesso!"],
                    res
                )
            );
        }

        public virtual async Task<ServiceResponse> ListAsync(int take, int skip, string? search)
        {
            var result = await _repository.ListAsync(take, skip, search);

            var mappedContent = result.Content.Select( x => _mapper.Map<L>(x)).ToList();

            var res = new
            {
                result.Take,
                result.Skip,
                result.Total,
                Content = mappedContent

            };

            return await Task.FromResult(
                new ServiceResponse(
                    System.Net.HttpStatusCode.OK,
                    ["Sucesso!"],
                    res
                )
            );

        }

        public virtual async Task<ServiceResponse> UpdateAsync(Guid id, K entity)
        {
            var obj = await _repository.GetByIdAsync(id);

            if (obj == null)
            {
                return await Task.FromResult(
                    new ServiceResponse(
                        System.Net.HttpStatusCode.NotFound,
                        ["Erro, não encontrado"],
                        null
                    )
                );
            }

            var jRequest = _mapper.Map<J>(entity);

            Validate(jRequest);

             _mapper.Map(entity, obj);

            var res = await _repository.UpdateAsync(obj);

            var mappedRes = _mapper.Map<L>(res);

            return await Task.FromResult(
                new ServiceResponse(
                    System.Net.HttpStatusCode.OK,
                    ["Alterado com sucesso"],
                    mappedRes
                )
            );
        }

        private void Validate(J entity)
        {
            var stringValidator = new StringValidator<J>();
            var stringValidation = stringValidator.Validate(entity);

            if (!stringValidation.IsValid)
            {
                var errorMessages = stringValidation.Errors.Select(error => error.ErrorMessage).ToList();
                throw new ValidationErrorException(errorMessages);
            }
        }
    }
}
