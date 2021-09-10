using FluentValidation;

namespace WebApi.Application.AuthorOperation.Queries.GetAuthorDetail
{
    public class GetAuthorDetailValidator:AbstractValidator<GetAuthorDetail>
    {
        
        public GetAuthorDetailValidator()
        {
            RuleFor(query=> query.AuthorId).NotEmpty().GreaterThan(0);
        }
    }
}