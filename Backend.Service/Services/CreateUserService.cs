using Backend.Service.Repositories;
using Backend.Service.Services.Interfaces;

namespace Backend.Service.Services;

public class CreateUserService(IUserRepository repository) : ICreateUserService
{
    public async Task Execute(string name, string email, string password)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < 4)
            throw new ArgumentException("User name needs to have at least 4 characters");

        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            throw new ArgumentException("Invalid email");

        if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            throw new ArgumentException("Password needs to have at least 8 characters");

        if (await repository.EmailExists(email))
            throw new InvalidOperationException("Email already exists");

        await repository.Create(name, email, password);
    }
}
