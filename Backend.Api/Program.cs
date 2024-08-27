using Backend.Infra.Database.Db;
using Backend.Infra.Repository.User;
using Backend.Service.Repositories;
using Backend.Service.Services;
using Backend.Service.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddDbContext<Context>(options =>
    options.UseInMemoryDatabase("Database")
);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICreateUserService, CreateUserService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
