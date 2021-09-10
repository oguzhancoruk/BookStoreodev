using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.BookOperations.Queries.Getbooks

{
    public class GetBookQuery

     {
         private readonly IBookStoreDbContext _dbcontext;
         private readonly IMapper _mapper;

         public GetBookQuery(IBookStoreDbContext dbContext, IMapper mapper)
         {   
             _mapper=mapper;
            _dbcontext=dbContext;

         }
         public List<BookViewModel> Handle()
         {
          var booklist=_dbcontext.Books.Include(x=>x.Genre).Include(x=>x.Author).OrderBy(x=>x.Id).ToList<Book>();
          
          List<BookViewModel> vn= _mapper.Map<List<BookViewModel>>(booklist);
         
           
          return vn;
         }
         
     }

     public class  BookViewModel
     {
       public string Title{get;set;}
       public string Genre{get;set;}  
       public int PageCount{get;set;}
       public string Author{get;set;}
       public string PublishDate {get;set;}
     }
}