using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperation.Queries.GetAuthor

{
    public class GetAuthor

    {
         public readonly IBookStoreDbContext _context;
           public readonly IMapper _mapper;
        public GetAuthor(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorViewModel> Handle()
        {
            var author=_context.Authors.OrderBy(x=>x.Id);
            List<AuthorViewModel> Obj=_mapper.Map<List<AuthorViewModel>>(author);
            return Obj;
        } 


    }

    public class  AuthorViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Date{get;set;}
        
    }
    
}