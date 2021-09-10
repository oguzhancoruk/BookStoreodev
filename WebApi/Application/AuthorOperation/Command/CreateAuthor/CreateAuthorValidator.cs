using System;
using FluentValidation;
namespace WebApi.Application.AuthorOperation.Command.CreateAuthor
{
    public class CreateAuthorValidator:AbstractValidator<CreateAuthor>
    {
        public CreateAuthorValidator()
        {
            RuleFor(A=>A.newAuthorModel.Name).NotEmpty().MinimumLength(3);
            RuleFor(A=>A.newAuthorModel.Surname).NotEmpty().MinimumLength(2);
            RuleFor(A=>A.newAuthorModel.Date).NotEmpty().LessThan(DateTime.Now);
        }

    }
}