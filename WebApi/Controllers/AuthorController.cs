using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperation.Command.CreateAuthor;
using WebApi.Application.AuthorOperation.Command.DeleteAuthor;
using WebApi.Application.AuthorOperation.Command.UpdateAuthor;
using WebApi.Application.AuthorOperation.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperation.Queries.GetAuthor;
using WebApi.DBOperations;
using static WebApi.Application.AuthorOperation.Command.UpdateAuthor.UpdateAuthor;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[Controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public AuthorController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthor query = new GetAuthor(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthors(int id)
        {
            GetAuthorDetail query = new GetAuthorDetail(_context,_mapper);
            query.AuthorId = id;
            GetAuthorDetailValidator validator = new GetAuthorDetailValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthor query = new DeleteAuthor(_context);
            query.AuthorId = id;
            DeleteAuthorValidator validator = new DeleteAuthorValidator();
            validator.ValidateAndThrow(query);
            query.Handle();
            return Ok();
        }
        [HttpPost]
        public IActionResult CreateAuthor([FromBody] CreateAuthorModel newAuthor)
        {
            CreateAuthor query = new CreateAuthor(_context,_mapper);
            query.newAuthorModel = newAuthor;
            CreateAuthorValidator validator = new CreateAuthorValidator();
            validator.ValidateAndThrow(query);
            query.Handle();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor([FromBody] UpdatedAuthorModel updateAuthor,int id)
        {
            UpdateAuthor query = new UpdateAuthor(_context);
            query.AuthorId = id;
            query.updatedAuthor= updateAuthor;
            UpdateAuthorValidator validator = new UpdateAuthorValidator();
            validator.ValidateAndThrow(query);
            query.Handle();
            return Ok();
        }
    }
}