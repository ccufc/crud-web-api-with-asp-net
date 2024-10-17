using Api.Entities;
using Api.Repositories.Interfaces;

namespace Api.Services.Users;

public class GetUsersService(IUserRepository repository)
{
    private readonly IUserRepository _repository = repository;

    public async Task<List<User>> Execute()
        => await _repository.All();
}
