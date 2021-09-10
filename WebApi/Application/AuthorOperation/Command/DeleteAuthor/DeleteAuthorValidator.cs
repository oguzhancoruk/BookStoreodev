  
using FluentValidation;

namespace WebApi.Application.AuthorOperation.Command.DeleteAuthor
{
    public class DeleteAuthorValidator:AbstractValidator<DeleteAuthor>
    {
        public DeleteAuthorValidator()
        {
            RuleFor(x=>x.AuthorId).NotEmpty().GreaterThan(0);
        }
        
    }
}