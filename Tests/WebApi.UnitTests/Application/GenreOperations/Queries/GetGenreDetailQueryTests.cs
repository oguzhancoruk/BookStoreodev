using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.DBOperations;
using Xunit;

namespace Application.GenreOperations.Queries
{
    public class GetGenreDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        
        public GetGenreDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGenreIdIsValid_ParticularGenre_ShouldBeReturned()
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
            query.GenreId = 2;
            
            GenresDetailViewModel genre = new GenresDetailViewModel()
            {
                Id = 2,
                Name = "PersonalGrowth"
            };
            

            FluentActions.Invoking(() => query.Handle()).Invoke();
            var model = query.Handle();
            model.Should().NotBeNull();
            model.Id.Should().Be(genre.Id);
            model.Name.Should().Be(genre.Name);
            
            
        }
        
    }
}