using PlaneHandler = Application.Planes.UseCases.Create.Handler;

using CreatePlaneCommand = Application.Planes.UseCases.Create.Command;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<PlaneHandler>();

var app = builder.Build();

app.MapPost("/v1/planes", async (PlaneHandler handler, CreatePlaneCommand command) => { 

   var result =  await handler.HandleAsync(command);

    return Results.Created("/v1/planes", result);
});

app.Run();
