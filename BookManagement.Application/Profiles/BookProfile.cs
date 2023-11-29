using AutoMapper;
using BookManagement.Application.Dtos.Book;
using BookManagement.Domain.Entities;

namespace BookManagement.Application.Profiles;

internal class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<CreateBookDto, Book>();
        CreateMap<Book, CreateBookDto>();
        CreateMap<UpdateBookDto, Book>();
        CreateMap<Book, GetBookDto>();
    }
}
