using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperation.Command.UpdateAuthor
{
    public class UpdateAuthor
    {
        private readonly IBookStoreDbContext _context;
        public UpdatedAuthorModel updatedAuthor { get; set; }
        public int AuthorId { get; set; }

        public UpdateAuthor(IBookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=>x.Id == AuthorId);
            if(author is null)
                throw new InvalidOperationException("Yazar Bulunamadı");

            author.Name = updatedAuthor.Name.Trim() == default? author.Name: updatedAuthor.Name;
            author.Surname = updatedAuthor.Surname.Trim() == default? author.Surname: updatedAuthor.Surname;
            author.Date = updatedAuthor.Date == default? author.Date: updatedAuthor.Date;
            _context.SaveChanges();

        }
        public class UpdatedAuthorModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime Date { get; set; }

        }
    }
}