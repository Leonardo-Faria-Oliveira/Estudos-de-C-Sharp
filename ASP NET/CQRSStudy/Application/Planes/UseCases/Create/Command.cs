using Application.Shared.UseCases.Abstracts;


namespace Application.Planes.UseCases.Create
{
    public record Command(string Name) : ICommand;

}
