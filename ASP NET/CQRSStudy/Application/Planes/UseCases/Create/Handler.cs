using Application.Shared.UseCases.Abstracts;

namespace Application.Planes.UseCases.Create
{
    public class Handler : IHandler<Command, Response>
    {
        public async Task<Response> HandleAsync(Command command)
        {
            await Task.Delay(10);
            return new Response("Plane created");
        }
    }
}
