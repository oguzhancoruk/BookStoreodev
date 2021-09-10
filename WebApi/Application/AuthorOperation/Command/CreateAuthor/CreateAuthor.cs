using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperation.Command.CreateAuthor
{
    public class CreateAuthor
    {
        public CreateAuthorModel newAuthorModel { get; set; }
        public readonly IMapper _mapper;
        private readonly IBookStoreDbContext _context;
        public CreateAuthor(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var author=_context.Authors.SingleOrDefault(x=>x.Name==newAuthorModel.Name);
            if(author is  not null)
            throw new InvalidOperationException("Yazar Zaten Mevcut");
            author=new Author();
            author.Name=newAuthorModel.Name;
            author.Surname=newAuthorModel.Surname;
            author.Date=newAuthorModel.Date;
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
    }
    public class CreateAuthorModel
        {
            public string Name { get; set; }
            public string Surname {get;set;}
            public DateTime Date { get; set; }
        }
}