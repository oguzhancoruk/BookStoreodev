using System;
using FluentValidation;


namespace WebApi.Application.AuthorOperation.Command.UpdateAuthor
{
    public class UpdateAuthorValidator:AbstractValidator<UpdateAuthor>
    {
        public UpdateAuthorValidator()
        {
            RuleFor(A=>A.AuthorId).NotEmpty().GreaterThan(0);
            RuleFor(A=>A.updatedAuthor.Name).NotEmpty().MinimumLength(3);
            RuleFor(A=>A.updatedAuthor.Surname).NotEmpty().MinimumLength(2);
            RuleFor(A=>A.updatedAuthor.Date).NotEmpty().LessThan(DateTime.Now);
        }

    }
}