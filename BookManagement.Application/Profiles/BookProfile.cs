using AutoMapper;
using BookManagement.Domain.Entities;
using BookManagement.Application.Dtos.Book;

namespace BookManagement.Application.Profiles;

internal class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<CreateBookDto, Book>();
        CreateMap<UpdateBookDto, Book>();
        CreateMap<Book, GetBookDto>();
    }
}
