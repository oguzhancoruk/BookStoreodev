using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.DeleteBook;
using WebApi.DBOperations;
using Xunit;

namespace Application.BookOperations.Commands.DeleteBook
{
    public class DeleteCommandTestsValidator:IClassFixture<CommonTestFixture>
    {  
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-4)]
        public void WhenIDIsInvalidNotGreaterThanZero_InvalidOperationException_ShouldBeReturned(int bookId)
        {
            DeleteBookCommand command= new DeleteBookCommand(null);
            command.BookId=bookId;
            DeleteBookCommandValidator validator =new DeleteBookCommandValidator();
            var result =validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
} 