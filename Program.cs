using Api.Data;
using Api.Repositories;
using Api.Repositories.Interfaces;
using Api.Services.Users;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddDbContext<Context>(
    options => options.UseInMemoryDatabase("Database")
);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<CreateUserService>();
builder.Services.AddScoped<GetUsersService>();
builder.Services.AddScoped<GetUserService>();
builder.Services.AddScoped<UpdateUserService>();
builder.Services.AddScoped<RemoveUserService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
