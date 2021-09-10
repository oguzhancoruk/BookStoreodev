using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperation.Command.DeleteAuthor;
using WebApi.DBOperations;
using Xunit;

namespace Application.AuthorOperations.Commands.DeleteCommand
{
    public class DeleteAuthorCommandTests: IClassFixture<CommonTestFixture>
    {
        
        private readonly BookStoreDbContext _context;
        
        public DeleteAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            


        }

        [Theory]
        [InlineData(1)]
        
        public void WhenIdIsValid_Author_ShouldBeDeleted(int authorId)
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == authorId);
            _context.Authors.Remove(author);
            _context.SaveChanges();

            DeleteAuthor command = new DeleteAuthor(_context);
            command.AuthorId = authorId;
            FluentActions
                    .Invoking(() => command.Handle())
                    .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar bulunamadı");


            
        }
        
    }
}