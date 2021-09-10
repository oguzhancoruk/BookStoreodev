using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {   
        public int GenreId { get; set; }
        public readonly IBookStoreDbContext _context;
        public readonly IMapper _mapper;
        public GetGenreDetailQuery(IBookStoreDbContext context, IMapper mapper)

        {
            _context = context;
            _mapper = mapper;
        }
        public GenresDetailViewModel Handle()
        {
            var genre= _context.Genres.SingleOrDefault(x=>x.IsActıve&& x.Id==GenreId); 
            if(genre is null)
            throw new InvalidOperationException("Kitap Türü Bulunamadı");
          
            return  _mapper.Map<GenresDetailViewModel>(genre);
        }
    }
    public class GenresDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
}