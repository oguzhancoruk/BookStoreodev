using System;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperation.Queries.GetAuthorDetail;
using WebApi.DBOperations;
using Xunit;

namespace Application.AuthorOperations.Queries
{
    public class GetAuthorDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        
        public GetAuthorDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenBookIdIsValid_ParticularBook_ShouldBeReturned()
        {
            GetAuthorDetail query = new GetAuthorDetail(_context, _mapper);
            query.AuthorId = 2;
            
            AuthorDetailViewModel author = new AuthorDetailViewModel()
            {
               Name = "İsim Test 2",
               Surname = "Soyisim Test 2",
               Date = new DateTime(2002,06,12)
               };
            

            FluentActions.Invoking(() => query.Handle()).Invoke();
            var model = query.Handle();
            model.Should().NotBeNull();
            model.Name.Should().Be(author.Name);
            model.Surname.Should().Be(author.Surname);
            
        }
        
    }
}