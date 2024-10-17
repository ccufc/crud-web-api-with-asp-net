using Api.Repositories.Interfaces;

namespace Api.Services.Users;

public class RemoveUserService(IUserRepository repository)
{
    private readonly IUserRepository _repository = repository;

    public async Task Execute(int id)
    {
        var user = await _repository.Get(id)
            ?? throw new ArgumentException("User not found");

        await _repository.Remove(user);
    }
}
