using System;
using System.Linq;
using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperation.Command.UpdateAuthor;
using WebApi.DBOperations;
using Xunit;
using static WebApi.Application.AuthorOperation.Command.UpdateAuthor.UpdateAuthor;

namespace Application.AuthorOperations.Commands.UpdateCommand
{
    public class UpdateAuthorCommandTests: IClassFixture<CommonTestFixture>
    {
        
        private readonly BookStoreDbContext _context;
        
        public UpdateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;

        }

        [Theory]
        [InlineData("Yeni Yazar İsim 1","Yeni Yazar Soyisim 1")]
        [InlineData("Yeni Yazar İsim 2","Yeni Yazar Soyisim 2")]
        public void WhenValidInputsAreGiven_Author_ShouldBeUpdated(string name, string surname)
        {
            UpdateAuthor command = new UpdateAuthor(_context);
            command.AuthorId = 3;

            command.updatedAuthor = new UpdatedAuthorModel()
            {
                Name = name,
                Surname = surname,
                Date = DateTime.Now.Date.AddYears(-4)
            };
           
            

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var author = _context.Authors.SingleOrDefault(author => author.Name == command.updatedAuthor.Name && author.Surname == command.updatedAuthor.Surname );
            author.Should().NotBeNull();
            author.Date.Should().Be(command.updatedAuthor.Date);

            
        }
        
       
        
    }
}