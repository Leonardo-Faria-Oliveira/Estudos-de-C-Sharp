using CRUDByBlazorTemplate.Dtos;
using CRUDByBlazorTemplate.Models;
using CRUDByBlazorTemplate.Request;
using CRUDByBlazorTemplate.Response;
using CRUDByBlazorTemplate.Response.Post;
using CRUDByBlazorTemplate.Utils;

namespace CRUDByBlazorTemplate.Mappers
{
    public class PostMapper : IBaseMapper<Post, PostDto, PostByIdResponse, PostResponse, PostRequest>
    {
        public PostDto ToDto(Post model)
        {
            return new PostDto
            {
                Id = model.Id,
                Title = model.Title,
                Content = new ContentDto
                {
                    Id = model.Content.Id,
                    Text = model.Content.Text,
                    Image = model.Content.Image,
                    Video = model.Content.Video,
                    CreatedAt = model.Content.CreatedAt,    
                    UpdatedAt = model.Content.UpdatedAt,
                },
                PublishDateTime = model.PublishDateTime,
                User = new UserDto
                {
                    Id = model.User.Id,
                    Username = model.User.Username,
                    Password = model.User.Password,
                    FullName = model.User.FullName,
                    Avatar = model.User.Avatar,
                    Email = model.User.Email,
                    Role = model.User.Role,
                    CreatedAt = model.User.CreatedAt,
                    UpdatedAt = model.User.UpdatedAt,
                },
                Category = new CategoryDto
                {
                    Id=model.Category.Id,
                    Title=model.Category.Title,
                    Description=model.Category.Description,
                    CreatedAt=model.Category.CreatedAt,
                    UpdatedAt=model.Category.UpdatedAt, 
                }
            };
        }

        public Post ToModel(PostDto dto)
        {
            return new Post
            {
                Id = dto.Id,
                Title = dto.Title,
                Content = new Content
                {
                    Text = dto.Content.Text,
                    Image = dto.Content.Image,
                    Video = dto.Content.Video,
                },
                PublishDateTime = dto.PublishDateTime,
                UserId = dto.User.Id,
                CategoryId = dto.Category.Id,
            };
        }

        public Post ToModel(PostRequest request)
        {

            return new Post
            {
                Title = request.Title,
                Content = new Content
                {
                    Text = request.Content.Text,
                    Image = request.Content.Image,
                    Video = request.Content.Video,
                },
                PublishDateTime = request.PublishDateTime,
                UserId = request.UserId,
                CategoryId = request.CategoryId

            };

        }

        public PostResponse ToResponse(Pagination<Post> pagination)
        {

        var postDtos = new List<PostDto>();

            foreach (var post in pagination.Content) {
                postDtos.Add(new PostDto
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = new ContentDto
                    {
                        Id = post.Content.Id,
                        Text = post.Content.Text,
                        Image = post.Content.Image,
                        Video = post.Content.Video,
                        CreatedAt = post.Content.CreatedAt,
                        UpdatedAt = post.Content.UpdatedAt,
                    },
                    PublishDateTime = post.PublishDateTime,
                    User = new UserDto
                    {
                        Id = post.User.Id,
                        Username = post.User.Username,
                        Password = post.User.Password,
                        FullName = post.User.FullName,
                        Avatar = post.User.Avatar,
                        Email = post.User.Email,
                        Role = post.User.Role,
                        CreatedAt = post.User.CreatedAt,
                        UpdatedAt = post.User.UpdatedAt,
                    },
                    Category = new CategoryDto
                    {
                        Id = post.Category.Id,
                        Title = post.Category.Title,
                        Description = post.Category.Description,
                        CreatedAt = post.Category.CreatedAt,
                        UpdatedAt = post.Category.UpdatedAt,
                    }
                });

            }
            return new PostResponse
            {

                Skip = pagination.Skip,
                Take = pagination.Take,
                Total = pagination.Total,
                Dtos = postDtos

            };
        }

        public PostByIdResponse ToResponseById(Post model)
        {
            throw new NotImplementedException();
        }
    }
}
