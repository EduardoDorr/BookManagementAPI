using BookManagement.Domain.Entities;
using BookManagement.Domain.Interfaces;

namespace BookManagement.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> CreateUser(User user)
    {
        await _repository.CreateUser(user);

        return user.Id;
    }        

    public async Task<IEnumerable<User>> GetUsers(int skip = 0, int take = 50)
    {
        return await _repository.GetUsers(skip, take);
    }

    public async Task<User?> GetUserById(int id)
    {
        return await _repository.GetUserById(id);            
    }

    public async Task<bool> UpdateUser(User user)
    {
        var userToUpdate = await _repository.GetUserById(user.Id);

        if (userToUpdate is null)
            return false;

        userToUpdate.Update(user.Name, user.Email);

        return await _repository.UpdateUser(userToUpdate);
    }

    public async Task<bool> DeleteUser(int id)
    {
        var userToDelete = await _repository.GetUserById(id);

        if (userToDelete is null)
            return false;

        return await _repository.DeleteUser(userToDelete);
    }
}
