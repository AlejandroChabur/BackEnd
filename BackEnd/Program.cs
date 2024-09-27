using BackEnd.Context;
using BackEnd.Repositories;
using BackEnd.Repository;
using BackEnd.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var cttString = builder.Configuration.GetConnectionString("Conexion");
builder.Services.AddDbContext<TestDbContext>(options => options.UseSqlServer(cttString));

//Repositorios y servicios Books
builder.Services.AddScoped<IBooksRepository, BooksRepository>();
builder.Services.AddScoped<IBooksServices, BooksServices>();

// Agregar repositorios y servicios para Authors
builder.Services.AddScoped<AuthorsRepository, AuthorsRepository>();
builder.Services.AddScoped<IAuthorsServices, AuthorsServices>();

// Agregar repositorios y servicios para Edition
builder.Services.AddScoped<EditionRepository, EditionRepository>();
builder.Services.AddScoped<EditionService, EditionService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationInsightsTelemetry();

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
//aaa