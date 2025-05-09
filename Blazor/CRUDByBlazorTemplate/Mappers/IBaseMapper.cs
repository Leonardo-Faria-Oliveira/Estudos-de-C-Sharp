﻿using CRUDByBlazorTemplate.Dtos;
using CRUDByBlazorTemplate.Models;
using CRUDByBlazorTemplate.Response;
using CRUDByBlazorTemplate.Utils;

namespace CRUDByBlazorTemplate.Mappers
{
    public interface IBaseMapper<T, J, U, V, R> where T : BaseModel where J : BaseDto where V : PaginateResponse<J> 
    {

        public T ToModel(J dto);

        public T ToModel(R dto);

        public J ToDto(T model);

        public U ToResponseById(T model);

        public V ToResponse(Pagination<T> pagination );

    }
}
