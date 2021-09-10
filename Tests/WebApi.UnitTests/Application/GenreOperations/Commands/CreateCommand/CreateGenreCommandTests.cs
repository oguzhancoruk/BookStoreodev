using System;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace Application.GenreOperations.Commands.CreateCommand
{
    public class CreateGenreCommandTests:IClassFixture<CommonTestFixture>
    {
       private readonly BookStoreDbContext _context;
       

       public CreateGenreCommandTests(CommonTestFixture commonTestFixture)
       {
           _context=commonTestFixture.Context;
          
       }
       [Fact]
        
        public void WhenAlreadyExistGenreNameGiven_InvalidOperationException_ShouldBeReturn()
        {
            var genre=new Genre() {Name="deneme"};
            _context.Genres.Add(genre);
            _context.SaveChanges();

            CreateGenreCommand command=new CreateGenreCommand(_context);
            command.Model=new CreateGenreModel(){Name=genre.Name};
            FluentActions
            .Invoking(()=>command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Türü Mevcut.");
        }

    }
}