using BiblioASPNet.Application.Controllers.Authors;
using BiblioASPNet.Application.Controllers.Books;
using BiblioASPNet.Application.Data.Context;
using BiblioASPNet.Application.Filters;
using BiblioASPNet.Application.Repositories.Authors;
using BiblioASPNet.Application.Repositories.Books;
using BiblioASPNet.Application.Requests.Authors;
using BiblioASPNet.Application.Requests.Books;
using BiblioASPNet.Application.Services;
using BiblioASPNet.Application.Services.Authors;
using BiblioASPNet.Application.Services.Books;
using BiblioASPNet.Application.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



var environment = builder.Configuration.GetValue<string>("Environment");

if (environment == "Dev")
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
}
else if (environment == "Test")
{
    var provider = builder.Services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
    builder.Services.AddDbContext<AppDbContext>(config =>
    {
        config.UseInMemoryDatabase("InMemoryDbTest");
        config.UseInternalServiceProvider(provider);
    });
}

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IAuthorController, AuthorController>();
builder.Services.AddScoped<IService<CreateAuthorRequest, UpdateAuthorRequest>, AuthorService>();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookController, BookController>();
builder.Services.AddScoped<IService<CreateBookRequest, UpdateBookRequest>, BookService>();


builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));


builder.Services.AddControllers();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Main()
{

}