using BiblioASPNet.Application.Controllers.Authors;
using BiblioASPNet.Application.Controllers.Books;
using BiblioASPNet.Application.Data.Context;
using BiblioASPNet.Application.Filters;
using BiblioASPNet.Application.Repositories.Authors;
using BiblioASPNet.Application.Repositories.Books;
using BiblioASPNet.Application.Requests.Authors;
using BiblioASPNet.Application.Requests.Books;
using BiblioASPNet.Application.Responses;
using BiblioASPNet.Application.Services;
using BiblioASPNet.Application.Services.Authors;
using BiblioASPNet.Application.Services.Books;
using BiblioASPNet.Application.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IAuthorController, AuthorController>();
builder.Services.AddScoped<IService<ServiceResponse, CreateAuthorRequest, UpdateAuthorRequest>, AuthorService>();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookController, BookController>();
builder.Services.AddScoped<IService<ServiceResponse, CreateBookRequest, UpdateBookRequest>, BookService>();


//builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

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
