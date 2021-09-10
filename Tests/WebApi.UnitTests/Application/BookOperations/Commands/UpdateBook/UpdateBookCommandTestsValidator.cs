using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using Xunit;

namespace Application.BookOperations.Commands.UpdateBook
{
    public class UpdateCommandValidatorTests: IClassFixture<CommonTestFixture>
    {
        
       [Theory]
       [InlineData("oğuzhan",0)]
       [InlineData("çoruk",1)]
      
       public void WhenUpdateBookParametersInvalid_InvalidOperationException_ShouldBeReturned(string title, int genreId)
       {
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.Model = new UpdateBookModel();
            command.Model.Title = title;
            command.Model.GenreId = genreId;
          


            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var error = validator.Validate(command);

            error.Errors.Count.Should().BeGreaterThan(0);

       }

       [Theory]
       [InlineData("oğuzhan",2)]
       [InlineData("çoruk",1)]
       public void WhenUpdateBookParametersValid_BookShouldBeUpdated(string title, int genreId)
       {
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.Model = new UpdateBookModel();
            command.Model.Title = title;
            command.Model.GenreId = genreId;
        


            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var error = validator.Validate(command);

            error.Errors.Count.Should().Equals(0);

       }

        
    }
}