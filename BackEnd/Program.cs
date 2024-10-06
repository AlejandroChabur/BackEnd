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
builder.Services.AddScoped<AuthorsServices, AuthorsServices>();

// Agregar repositorios y servicios para Edition
builder.Services.AddScoped<EditionRepository, EditionRepository>();
builder.Services.AddScoped<EditionService, EditionService>();

builder.Services.AddScoped<EditorialsRepository, EditorialsRepository>();
builder.Services.AddScoped<EditorialsService, EditorialsService>();

builder.Services.AddScoped<FormatsRepository, FormatsRepository>();
builder.Services.AddScoped<FormatsService, FormatsService > ();

builder.Services.AddScoped<IdentificationTypeRepository, IdentificationTypeRepository>();
builder.Services.AddScoped<IdentificationTypeService, IdentificationTypeService>();

builder.Services.AddScoped<LoansRepository, LoansRepository>();
builder.Services.AddScoped<LoansService, LoansService>();

builder.Services.AddScoped<PeopleRepository, PeopleRepository>();
builder.Services.AddScoped<PeopleService, PeopleService>();

builder.Services.AddScoped<ReportsRepository, ReportsRepository>();
builder.Services.AddScoped<ReportsService, ReportsService>();

builder.Services.AddScoped<UserRepository, UserRepository>();
builder.Services.AddScoped<UserService, UserService>();

builder.Services.AddScoped<TopicsRepository, TopicsRepository>();
builder.Services.AddScoped<TopicsService, TopicsService>();


builder.Services.AddScoped<UserTypeRepository, UserTypeRepository>();
builder.Services.AddScoped<UserTypeService, UserTypeService>();





builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();

// Configure the HTTP request pipeline.
    app.Environment.IsDevelopment();
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
//aaa