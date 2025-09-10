using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OneHelper.Mapper;
using OneHelper.Models;
using OneHelper.Repository.Interfaces;
using OneHelper.Repository.UserRepository;
using OneHelper.Services.SleepLogService;
using OneHelper.Services.ToDoService;
using OneHelper.Validators;

string ViteDevelopmentName = "Onehelper Frontend Development";
string ViteDevelopmentOrigin = "http://localhost:5173";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: ViteDevelopmentName,
                      policy =>
                      {
                          policy.WithOrigins(ViteDevelopmentOrigin).AllowAnyHeader().AllowAnyMethod();
                      });
});

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
builder.Services.AddScoped<ISleepLogService, SleepLogService>();
builder.Services.AddValidatorsFromAssemblyContaining<ToDoDtoValidator>();

builder.Services.AddAutoMapper(i => { 
    i.AddProfile<ToDoProfile>(); 
    i.AddProfile<SleepLogProfile>(); 
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(ViteDevelopmentName);

app.UseAuthorization();

app.MapControllers();

app.Run();

