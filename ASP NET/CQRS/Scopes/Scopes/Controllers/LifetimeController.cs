using Microsoft.AspNetCore.Mvc;
using Scopes.Services.Lifetime;

namespace Scopes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LifetimeController : ControllerBase
    {

        private readonly IScoped _scoped1;
        private readonly IScoped _scoped2;
        private readonly ISingleton _singleton1;
        private readonly ISingleton _singleton2;
        private readonly ITransient _transient1;
        private readonly ITransient _transient2;

        public LifetimeController(
             IScoped scoped1, IScoped scoped2,
             ISingleton singleton1, ISingleton singleton2,
             ITransient transient1, ITransient transient2
            )
        {
            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _singleton1 = singleton1;
            _singleton2 = singleton2;
            _transient1 = transient1;
            _transient2 = transient2;
        }

        [HttpGet]
        public string Get()
        {
            return  $"Scoped 1: {_scoped1.OperationId}\n" +
                    $"Scoped 2: {_scoped2.OperationId}\n" +
                    $"Transient 1: {_transient1.OperationId}\n" +
                    $"Transient 2: {_transient2.OperationId}\n" +
                    $"Singleton 1: {_singleton1.OperationId}\n" +
                    $"Singleton 2: {_singleton2.OperationId}";
        }


    }
}
