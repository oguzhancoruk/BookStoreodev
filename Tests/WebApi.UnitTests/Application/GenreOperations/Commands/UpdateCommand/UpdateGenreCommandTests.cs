using System.Linq;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.UpdateBook;
using WebApi.DBOperations;
using Xunit;

namespace Application.GenreOperations.Commands.UpdateCommand
{
    public class UpdateGenreCommandTests: IClassFixture<CommonTestFixture>
    {
        
        private readonly BookStoreDbContext _context;
        
        public UpdateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;

        }

        [Theory]
        [InlineData("Sience Fiction")]
        public void WhenValidInputsAreGiven_Genre_ShouldBeUpdated(string name)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = 2; 

            command.Model = new UpdateGenreModel(){
                Name=name,
                IsActive = false
            };
           
            

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var genre = _context.Genres.SingleOrDefault(genre => genre.Name == command.Model.Name );

            genre.IsActıve.Should().Be(command.Model.IsActive);
            

            
        }
       
        
    }
}