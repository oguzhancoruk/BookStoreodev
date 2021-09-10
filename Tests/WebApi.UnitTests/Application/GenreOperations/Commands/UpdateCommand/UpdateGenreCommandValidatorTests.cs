using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.UpdateBook;
using Xunit;

namespace Application.GenreOperations.Commands.UpdateCommand
{
    public class UpdateGenreValidatorTests: IClassFixture<CommonTestFixture>
    {
        
       [Theory]
       [InlineData("L")]
       [InlineData("L2")]
       [InlineData("De")]
       public void WhenUpdateGenreParametersInvalid_InvalidOperationException_ShouldBeReturned(string name)
       {
            UpdateGenreCommand command = new UpdateGenreCommand(null);
            command.Model = new UpdateGenreModel()
            {
                Name = name
            };
           
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var error = validator.Validate(command);

            error.Errors.Count.Should().BeGreaterThan(0);

       }

       [Theory]
       [InlineData("Deneme")]
       [InlineData("ValidName")]
       public void WhenUpdateGenreParametersValid_GenreShouldBeUpdated(string name)
       {
            UpdateGenreCommand command = new UpdateGenreCommand(null);
            command.Model = new UpdateGenreModel()
            {
                Name = name
            };


            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var error = validator.Validate(command);

            error.Errors.Count.Should().Equals(0);

       }

        
    }
}