using CRUDByBlazorTemplate.Components;
using CRUDByBlazorTemplate.Components.UI.DataTable;
using CRUDByBlazorTemplate.Config;
using CRUDByBlazorTemplate.Data.Context;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<AppDbContext>(options => options.UseInMemoryDatabase("app"));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddServerSideBlazor();

builder.Services.AddMudServices();
builder.Services.AddMudServices(options => { options.PopoverOptions.CheckForPopoverProvider = false; });


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddCors();

builder.Services.ResolveDependecies();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
