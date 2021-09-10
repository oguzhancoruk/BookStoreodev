using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperation.Queries.GetAuthorDetail;
using WebApi.DBOperations;
using Xunit;

namespace Application.AuthorOperations.Queries
{
    public class GetAuthorDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        
        public GetAuthorDetailQueryValidatorTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

       [Fact]
       public void WhenIDIsInvalidNotGreaterThanZero_InvalidOperationException_ShouldBeReturned()
        {
            GetAuthorDetail query = new GetAuthorDetail(null, null);
            query.AuthorId = -2;

            GetAuthorDetailValidator validator = new GetAuthorDetailValidator();

            var result = validator.Validate(query);
            result.Errors.Count.Should().BeGreaterThan(0);

            
        }
        
    }
}