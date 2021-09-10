using System;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Queries.GetBooksDetail;
using WebApi.DBOperations;
using Xunit;

namespace Application.BookOperations.Queries
{
    public class GetBookDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        
        public GetBookDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        
        public void WhenBookIdIsValid_ParticularBook_ShouldBeReturned()
        {
            GetBooksDetailQuery query = new GetBooksDetailQuery(_context, _mapper);
            query.BookId = 3;
            
            BookDetailViewModel book = new BookDetailViewModel()
            {
                Title = "Lean Startup",
                PageCount = 250,
                Genre = "Personal Growt",
                Author = "İsim Test 1 Soyisim Test 1"
              
                };
            FluentActions.Invoking(() => query.Handle()).Invoke();
            var model = query.Handle();
            model.Should().NotBeNull();
            model.PageCount.Should().Be(book.PageCount);
            model.Genre.Should().Be(book.Genre);
            book.Title.Should().Be(model.Title);
            model.Author.Should().Be(book.Author);
            
         

            
        }
        
    }
}