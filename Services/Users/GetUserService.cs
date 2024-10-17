using Api.Entities;
using Api.Repositories.Interfaces;

namespace Api.Services.Users;

public class GetUserService(IUserRepository repository)
{
    private readonly IUserRepository _repository = repository;

    public async Task<User?> Execute(int id)
        => await _repository.Get(id)
        ?? throw new ArgumentException("User not found");
}
