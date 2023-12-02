using AutoMapper;

using BookManagement.Domain.Entities;
using BookManagement.Application.Dtos.User;

namespace BookManagement.Application.Profiles;

internal class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();
        CreateMap<User, GetUserDto>();
        CreateMap<User, GetUserAndBorrowsDto>();
    }
}
