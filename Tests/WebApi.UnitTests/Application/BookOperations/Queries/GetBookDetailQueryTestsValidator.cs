using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Queries.GetBooksDetail;
using WebApi.DBOperations;
using Xunit;

namespace Application.BookOperations.Queries
{
    public class GetBookDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        
        public GetBookDetailQueryValidatorTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

       [Fact]
       public void WhenIDIsInvalidNotGreaterThanZero_InvalidOperationException_ShouldBeReturned()
        {
            GetBooksDetailQuery query = new GetBooksDetailQuery(null, null);
            query.BookId = -1;

            GetBooksDetailQueryValidator validator = new GetBooksDetailQueryValidator();

            var result = validator.Validate(query);
            result.Errors.Count.Should().BeGreaterThan(0);

            
        }
        
    }
}