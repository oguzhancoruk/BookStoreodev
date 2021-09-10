using AutoMapper;
using WebApi.Application.AuthorOperation.Command.CreateAuthor;
using WebApi.Application.AuthorOperation.Queries.GetAuthor;
using WebApi.Application.AuthorOperation.Queries.GetAuthorDetail;
using WebApi.Application.BookOperations.Queries.Getbooks;
using WebApi.Application.BookOperations.Queries.GetBooksDetail;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Entities;
using static WebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;

namespace WebApi.Common
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel,Book>();
            CreateMap<Book,BookDetailViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>src.Genre.Name)).ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name +" "+ src.Author.Surname));
            CreateMap<Book,BookViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>src.Genre.Name)).ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name +" "+src.Author.Surname));
            
            
            
            CreateMap<Genre,GenresViewModel>();
            CreateMap<Genre,GenresDetailViewModel>();
            CreateMap<Author,AuthorViewModel>();
            CreateMap<Author,AuthorDetailViewModel>();
            CreateMap<CreateAuthorModel,Author>();
        }

    }
}