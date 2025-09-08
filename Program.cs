using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OneHelper.Mapper;
using OneHelper.Models;
using OneHelper.Repository.Interfaces;
using OneHelper.Repository.UserRepository;
using OneHelper.Services.ToDoService;
using OneHelper.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddDbContext<OneHelperContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<ITodoRepository, ToDoRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISleepLogRepository, SleepLogRepository>();
builder.Services.AddScoped<IToDoService, ToDoService>();
builder.Services.AddValidatorsFromAssemblyContaining<ToDoDtoValidator>();
builder.Services.AddAutoMapper(i => i.AddProfile<ToDoProfile>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

