using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperation.Queries.GetAuthorDetail

{
    public class GetAuthorDetail

    {
        public int AuthorId { get; set; }
         public readonly IBookStoreDbContext _context;
           public readonly IMapper _mapper;
        public GetAuthorDetail(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle()
        {
            var author= _context.Authors.SingleOrDefault(x=> x.Id==AuthorId); 
            if(author is null)
            throw new InvalidOperationException("Yazar Bulunamadı");
          
            return  _mapper.Map<AuthorDetailViewModel>(author);
        } 


    }

    public class  AuthorDetailViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Date{get;set;}
        
    }
    
}