using Microsoft.EntityFrameworkCore;
using OneHelper.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<OneHelperContext>( options =>
{
    options.UseSqlServer("Server=FGT-08\\SQLEXPRESS03;Database=OneHelperDB;Trusted_Connection=True;TrustServerCertificate=True;");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
