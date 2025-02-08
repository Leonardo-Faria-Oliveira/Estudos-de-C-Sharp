using CRUDByBlazorTemplate.Models;
using CRUDByBlazorTemplate.Repositories;
using CRUDByBlazorTemplate.Request;

namespace CRUDByBlazorTemplate.Services
{
    public interface IPostService : IBaseService<ServiceResponse, PostRequest>
    {
    }
}
