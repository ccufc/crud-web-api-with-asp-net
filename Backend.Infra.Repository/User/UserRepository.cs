using Backend.Infra.Database.Db;
using Backend.Service.Repositories;
using Microsoft.EntityFrameworkCore;
using Entities = Backend.Infra.Database.Entities;

namespace Backend.Infra.Repository.User;

public class UserRepository(Context context) : IUserRepository
{
    public async Task Create(string name, string email, string password)
    {
        var user = new Entities.User()
        {
            Name = name,
            Email = email,
            Password = password,
        };

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public Task<bool> EmailExists(string email)
        => context.Users.AnyAsync(x => x.Email == email);
}
