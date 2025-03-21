using CRUDByBlazorTemplate.Components;
using CRUDByBlazorTemplate.Components.UI.DataTable;
using CRUDByBlazorTemplate.Config;
using CRUDByBlazorTemplate.Data.Context;
using CRUDByBlazorTemplate.Models.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Obtém a string de conexão do appsettings.json ou User Secrets
var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");

builder.Services.AddDbContext<SecurityDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<SecurityDbContext>();
        
builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddAuthentication();

builder.Services.AddAuthorization();

builder.Services.AddServerSideBlazor();

builder.Services.AddMudBlazorSnackbar();

builder.Services.AddMudBlazorDialog();

builder.Services.AddMudServices();
builder.Services.AddMudServices(options => { 
    options.PopoverOptions.CheckForPopoverProvider = false;

});

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
    app.MapSwagger();

}

app.UseHttpsRedirection();





app.UseStaticFiles();
app.UseAntiforgery();

app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapIdentityApi<ApplicationUser>();

app.Run();
