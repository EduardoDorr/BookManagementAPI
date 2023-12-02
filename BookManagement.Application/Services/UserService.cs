using AutoMapper;

using BookManagement.Domain.Entities;
using BookManagement.Domain.Interfaces;
using BookManagement.Application.Dtos.User;

namespace BookManagement.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repository, IMapper mapper)
    {
        _userRepository = repository;
        _mapper = mapper;
    }

    public async Task<int> CreateUserAsync(CreateUserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);

        await _userRepository.CreateUserAsync(user);

        var created = await _userRepository.SaveAsync();

        if (!created)
            throw new Exception("User could not be created");

        return user.Id;
    }        

    public async Task<IEnumerable<GetUserDto>> GetUsersAsync(int skip = 0, int take = 50)
    {
        var users = await _userRepository.GetUsersAsync(skip, take);

        return _mapper.Map<IEnumerable<GetUserDto>>(users);
    }

    public async Task<GetUserDto?> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);

        return _mapper.Map<GetUserDto>(user);
    }

    public async Task<GetUserAndBorrowsDto?> GetUserAndBorrowByIdAsync(int id)
    {
        var userAndBorrows = await _userRepository.GetUserAndBorrowsByIdAsync(id);

        return _mapper.Map<GetUserAndBorrowsDto>(userAndBorrows);
    }

    public async Task<bool> UpdateUserAsync(UpdateUserDto userDto)
    {
        var UserToUpdate = await _userRepository.GetUserByIdAsync(userDto.Id);

        if (UserToUpdate is null)
            return false;

        UserToUpdate.Update(userDto.Name, userDto.Email, userDto.IsActive);

        _userRepository.UpdateUser(UserToUpdate);

        return await _userRepository.SaveAsync();
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var userToDelete = await _userRepository.GetUserByIdAsync(id);

        if (userToDelete is null)
            return false;

        _userRepository.DeleteUser(userToDelete);

        return await _userRepository.SaveAsync();
    }    
}
