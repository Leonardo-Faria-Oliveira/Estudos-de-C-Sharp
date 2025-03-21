using CRUDByBlazorTemplate.Dtos;
using CRUDByBlazorTemplate.Mappers;
using CRUDByBlazorTemplate.Models;
using CRUDByBlazorTemplate.Repositories;
using CRUDByBlazorTemplate.Request;
using CRUDByBlazorTemplate.Response.Post;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace CRUDByBlazorTemplate.Services
{
    public class PostService : IPostService
    {

        private readonly IPostRepository _postRepository;

        private readonly IBaseMapper<Post, PostDto, PostByIdResponse, PostResponse, PostRequest> _mapper;

        public PostService(IPostRepository postRepository, IBaseMapper<Post, PostDto, PostByIdResponse, PostResponse, PostRequest> mapper) 
        { 
            _postRepository = postRepository;
            _mapper = mapper;
        }


        public async Task<ServiceResponse> Delete(Guid id)
        {
         
            var post = await _postRepository.GetById(id);

            if (post == null)
            {

                return ServiceResponse.Factory(
                    System.Net.HttpStatusCode.NotFound,
                    "Post não encontrado"
                );
                    
            }

            await _postRepository.Delete(post);

            return ServiceResponse.Factory(
                System.Net.HttpStatusCode.OK,
                "Post excluído com sucesso"
            );
            
        }

        public async Task<ServiceResponse> Get(int take, int skip, string? search)
        {
            var posts = await _postRepository.Get(take, skip, search);

            var response = _mapper.ToResponse(posts);

            return ServiceResponse.Factory(
                System.Net.HttpStatusCode.OK,
                null,
                response
            );

        }

        public async Task<ServiceResponse> GetById(Guid Id)
        {
            
            var post = await _postRepository.GetById(Id);

            if (post == null)
            {
                return ServiceResponse.Factory(
                    System.Net.HttpStatusCode.NotFound,
                    "Post não encontrado"
                );

            }

            var response = _mapper.ToResponseById(post);

            return ServiceResponse.Factory(
                System.Net.HttpStatusCode.OK,
                null,
                response
            );

        }

        public async Task<ServiceResponse> Patch(Guid id, PostRequest entity)
        {
            var post = await _postRepository.GetById(id);

            if (post == null)
            {
                return ServiceResponse.Factory(
                    System.Net.HttpStatusCode.NotFound,
                    "Post não encontrado"
                );

            }

            var postModel = _mapper.ToModel(entity);

            post.Title = postModel.Title;
            post.Content = postModel.Content;
            post.PublishDateTime = postModel.PublishDateTime;

            var updatedPost = await _postRepository.Patch(post);

            return ServiceResponse.Factory(
                System.Net.HttpStatusCode.OK,
                "Post atualizado com sucesso",
                updatedPost
            );

        }

        public async Task<ServiceResponse> Post(PostRequest entity)
        {
            var post = _mapper.ToModel(entity);

            await _postRepository.Post(post);

            return ServiceResponse.Factory(
                System.Net.HttpStatusCode.OK,
                "Post atualizado com sucesso",
                null
            );
        }


    }
}
