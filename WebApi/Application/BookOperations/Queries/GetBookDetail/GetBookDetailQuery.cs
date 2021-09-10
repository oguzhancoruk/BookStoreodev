using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;


namespace WebApi.Application.BookOperations.Queries.GetBooksDetail
{

    public class GetBooksDetailQuery
    {
        private readonly IBookStoreDbContext _dbContext; 
        private readonly IMapper _maper;
        public int BookId{get;set;}
        public GetBooksDetailQuery(IBookStoreDbContext dbContext,IMapper mapper)
        {
            _maper=mapper;
            _dbContext=dbContext;
        }

        public BookDetailViewModel Handle()
        {
         var book=_dbContext.Books.Include(x=>x.Genre).Include(y=>y.Author).Where(book=>book.Id==BookId).SingleOrDefault();
         
        

        if(book is null)
        throw new InvalidOperationException("Kitap bulunamadı"); 
        BookDetailViewModel vm= _maper.Map<BookDetailViewModel>(book);
      
         return vm;
        }
    }
    public class BookDetailViewModel
    {
      
       public string Title{get;set;}
       public string Genre{get;set;}  
       public int PageCount{get;set;}
       public string Author{get;set;}
       public DateTime PublishDate {get;set;}

    }
}