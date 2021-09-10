using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.DeleteBook;
using WebApi.DBOperations;
using Xunit;

namespace Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
      

        public DeleteBookCommandTests(CommonTestFixture testFixture)
        {
            _context=testFixture.Context;
           
        }
        [Theory]
        [InlineData(1)]
        public void WhenIdIsValid_Book_ShouldBeDeleted(int bookId)
        {
            var book=_context.Books.SingleOrDefault(X=>X.Id==bookId);
            _context.Books.Remove(book);
            _context.SaveChanges();

            DeleteBookCommand command =new DeleteBookCommand(_context);
            command.BookId=bookId;
           FluentActions
           .Invoking(()=> command.Handle())
           .Should().Throw<InvalidOperationException>().And.Message.Should().Be("silinecek kitap bulunamadı");

        }
    }
}