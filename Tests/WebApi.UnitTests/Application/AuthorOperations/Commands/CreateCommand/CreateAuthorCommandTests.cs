using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperation.Command.CreateAuthor;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace Application.AuthorOperations.Commands.CreateCommand
{
    public class CreateAuthorCommandTests: IClassFixture<CommonTestFixture>
    {
        
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        
        public CreateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;


        }
        [Fact]
        public void WhenAlreadyExistAuthorNameGiven_InvalidOperationException_ShouldBeReturn(){
           

            var author = new Author(){Name="WhenAlreadyExistAuthorNameGiven_InvalidOperationException_ShouldBeReturn", Surname="", Date=new DateTime(1990,01,10)};
            _context.Authors.Add(author);
            _context.SaveChanges();


            CreateAuthor command = new CreateAuthor(_context, _mapper);
            command.newAuthorModel = new CreateAuthorModel(){Name="WhenAlreadyExistAuthorNameGiven_InvalidOperationException_ShouldBeReturn", Surname=""};



            

            FluentActions
                    .Invoking(() => command.Handle())
                    .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar zaten mevcut");

        }

        [Fact]
        public void WhenValidInputsAreGiven_Author_ShouldBeCreated()
        {
            
            CreateAuthor command = new CreateAuthor(_context, _mapper);
            CreateAuthorModel model = new CreateAuthorModel()
            {
                Name = "Yeni Yazar",
                Surname = "Soyisim",
                Date = new DateTime(1990,01,10)
            };
            command.newAuthorModel = model;

          
            FluentActions.Invoking(() => command.Handle()).Invoke();


           
            var author = _context.Authors.SingleOrDefault(author => author.Name == model.Name && author.Surname == model.Surname);
            author.Should().NotBeNull();
           
            author.Date.Should().Be(model.Date);
        }
    }
}