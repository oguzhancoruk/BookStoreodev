using System;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperation.Command.CreateAuthor;
using Xunit;

namespace Application.AuthorOperations.Commands.CreateCommand
{
    public class AuthorCommandValidatorTests: IClassFixture<CommonTestFixture>
    {
        
        [Theory]
        [InlineData("Ad", "Soyad")]
        [InlineData("Adımız", "Soy")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surname){
            
            // arrange
           CreateAuthor command = new CreateAuthor(null, null);
           command.newAuthorModel = new CreateAuthorModel()
           {
                Name = name,
                Surname = surname,
           };

            // act
            CreateAuthorValidator validator = new CreateAuthorValidator();
            var result = validator.Validate(command);

            
            // assert
            result.Errors.Count.Should().BeGreaterThan(0);
         
        }


        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            CreateAuthor command = new CreateAuthor(null, null);
            command.newAuthorModel = new CreateAuthorModel()
            {
                Name = "Orhan",
                Surname = "Pamuk",
                Date = DateTime.Now.Date
            };

            CreateAuthorValidator validator = new CreateAuthorValidator();
            var error = validator.Validate(command);

            error.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateAuthor command = new CreateAuthor(null, null);
            command.newAuthorModel = new CreateAuthorModel()
            {
                Name = "Orhan",
                Surname = "Pamuk",
                Date = DateTime.Now.Date.AddYears(-2)
            };

            CreateAuthorValidator validator = new CreateAuthorValidator();
            var error = validator.Validate(command);

            error.Errors.Count.Should().Equals(0);
        }

        
    }
}