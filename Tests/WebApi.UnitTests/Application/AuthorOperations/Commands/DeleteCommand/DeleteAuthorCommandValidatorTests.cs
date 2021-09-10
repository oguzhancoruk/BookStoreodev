using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperation.Command.DeleteAuthor;
using Xunit;

namespace Application.AuthorOperations.Commands.DeleteCommand
{
    public class DeleteAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        
        [Theory]
        [InlineData(-2)]
        [InlineData(0)]
        [InlineData(-3)]
        public void WhenIDIsInvalidNotGreaterThanZero_InvalidOperationException_ShouldBeReturned(int authorId)
        {
            DeleteAuthor command = new DeleteAuthor(null);
            command.AuthorId = authorId;

            DeleteAuthorValidator validator = new DeleteAuthorValidator();

            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);

            
        }

        
    }
}