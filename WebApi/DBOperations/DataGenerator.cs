using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator

    {
       public static void Initialize(IServiceProvider serviceProvider)
       {
           using (var context=new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
           {
               if(context.Books.Any())
               {
                   return;
               }

               context.Authors.AddRange(
                   new Author{
                       Name="Ray ",
                       Surname="Bradbury",
                       Date=new DateTime(1920,08,22)
                   }
                  
               );

               
               context.Genres.AddRange(
                   new Genre
                   {
                       Name="Personal Growt"

                   },
                   new Genre
                   {
                       Name="Sience Fiction"
                   },
                   new Genre
                   {
                       Name="Romance"
                   }
                    
               );
               context.Books.AddRange(new Book {
       //Id=1,
       Title="Lean Startup",
       GenreId=1,
       PageCount=200,
       AuthorId=1,
       PublishDate= new DateTime(2001,06,12)

    },
     new Book{
     //  Id=2,
       Title="Herland",
       GenreId=2,
       PageCount=258,
       AuthorId=0,
       PublishDate= new DateTime(2010,05,23)

    },
     new Book{
       //Id=3,
       Title="Dune",
       GenreId=2,
       PageCount=540,
       AuthorId=0,
       PublishDate= new DateTime(2001,12,21)

    }
    );
    context.SaveChanges();
           }
       }
    }
}