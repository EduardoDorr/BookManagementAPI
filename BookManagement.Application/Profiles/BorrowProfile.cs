using AutoMapper;

using BookManagement.Domain.Entities;
using BookManagement.Application.Dtos.Borrow;

namespace BookManagement.Application.Profiles;

internal class BorrowProfile : Profile
{
    public BorrowProfile()
    {
        CreateMap<CreateBorrowDto, Borrow>();
        CreateMap<UpdateBorrowDto, Borrow>();
        CreateMap<Borrow, GetBorrowDto>();
        CreateMap<Borrow, GetBorrowWithoutUser>();
    }
}
