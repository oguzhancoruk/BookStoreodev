using System.Linq;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.DBOperations;
using Xunit;

namespace Application.BookOperations.Commands.UpdateBook

{
  public class UpdateBookCommandTests:IClassFixture<CommonTestFixture>

  {
      private readonly BookStoreDbContext _context;
      public UpdateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;

        }
      
        [Theory]
        [InlineData("Deneme2",3)]
    public void  WhenValidInputsAreGiven_Book_ShouldBeUpdated(string title, int genreId)
    {
        UpdateBookCommand command=new UpdateBookCommand(_context);
        command.BookId=3; 
        command.Model = new UpdateBookModel();
        command.Model.GenreId=genreId;
        command.Model.Title=title;
        FluentActions.Invoking(()=> command.Handle()).Invoke(); 
        var book=_context.Books.SingleOrDefault(book=>book.Title==command.Model.Title);
        book.Should().NotBeNull(); 
        book.GenreId.Should().Be(command.Model.GenreId);
        book.Title.Should().Be(command.Model.Title);  
        }}}