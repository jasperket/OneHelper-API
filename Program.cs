using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OneHelper.Mapper;
using OneHelper.Models;
using OneHelper.Repository.Interfaces;
using OneHelper.Repository.UserRepository;
using OneHelper.Services.ToDoService;
using OneHelper.Validators;
using Microsoft.AspNetCore.HttpOverrides;
using OneHelper.Middleware;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;


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
builder.Services.AddValidatorsFromAssemblyContaining<ToDoDtoValidator>();


builder.Services.AddAutoMapper(i => i.AddProfile<ToDoProfile>());

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<OneHelperContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(i =>
{
    i.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    i.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    i.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(i =>
{
    i.Cookie.Name = "TestCookie";
    i.Cookie.HttpOnly = true;
    i.Cookie.SameSite = SameSiteMode.Strict;
    i.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    i.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    i.SlidingExpiration = true;

    i.Events = new CookieAuthenticationEvents
    {
        OnRedirectToLogin = context =>
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        },
        OnRedirectToAccessDenied = context =>
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            return Task.CompletedTask;
        }
    };
});

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

var app = builder.Build();

app.UseForwardedHeaders();
app.UseMiddleware<HttpOnlyMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(ViteDevelopmentName);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

