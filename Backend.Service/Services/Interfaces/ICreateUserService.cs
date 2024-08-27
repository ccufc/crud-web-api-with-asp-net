namespace Backend.Service.Services.Interfaces;

public interface ICreateUserService
{
    public Task Execute(string name, string email, string password);
}
