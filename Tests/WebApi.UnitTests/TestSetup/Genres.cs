using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup

{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDbContext context)
        {
            context.Genres.AddRange(
                new Genre{Name="Personal Growt"},
                new Genre{Name="Sience Fiction"},
                new Genre{Name="Romance"});

                    
        }
    }
    
}