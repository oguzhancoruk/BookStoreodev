using System;
using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperation.Command.UpdateAuthor;
using Xunit;
using static WebApi.Application.AuthorOperation.Command.UpdateAuthor.UpdateAuthor;

namespace Application.AuthorOperations.Commands.UpdateCommand
{
    public class UpdateAuthorCommandValidatorTests: IClassFixture<CommonTestFixture>
    {
        
       [Theory]
       [InlineData("Yazar İsim 1","So")]
       [InlineData("Yaz","Yazar Soyisim 2")]
       public void WhenUpdateAuthorParametersAreInvalid_InvalidOperationException_ShouldBeReturned(string name, string surname)
       {
            UpdateAuthor command = new UpdateAuthor(null);
            command.updatedAuthor = new UpdatedAuthorModel()
            {
                Name = name,
                Surname = surname
            };
        


            UpdateAuthorValidator validator = new UpdateAuthorValidator();
            var error = validator.Validate(command);

            error.Errors.Count.Should().BeGreaterThan(0);

       }

       [Theory]
       [InlineData("Deneme İsim 1","Deneme Soyisim 1")]
       [InlineData("Valid İsim","Valid Soyisim")]
       public void WhenUpdateAuthorParametersValid_AuthorShouldBeUpdated(string name, string surname)
       {
            UpdateAuthor command = new UpdateAuthor(null);
            command.updatedAuthor = new UpdatedAuthorModel()
            {
                Name = name,
                Surname = surname
            };
         


            UpdateAuthorValidator validator = new UpdateAuthorValidator();
            var error = validator.Validate(command);

            error.Errors.Count.Should().Equals(0);

       }


        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            UpdateAuthor command = new UpdateAuthor(null);
            command.updatedAuthor = new UpdatedAuthorModel()
            {
                Name = "Geçerli İsim",
                Surname = "Geçerli Soyisim",
                Date = DateTime.Now.Date
            };

            UpdateAuthorValidator validator = new UpdateAuthorValidator();
            var error = validator.Validate(command);

            error.Errors.Count.Should().BeGreaterThan(0);
        }
       

        
    }
}