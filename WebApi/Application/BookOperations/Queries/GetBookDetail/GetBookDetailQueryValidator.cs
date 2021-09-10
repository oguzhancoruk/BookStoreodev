using FluentValidation;
namespace WebApi.Application.BookOperations.Queries.GetBooksDetail
{
    public class GetBooksDetailQueryValidator:AbstractValidator<GetBooksDetailQuery>
    {
      public  GetBooksDetailQueryValidator()
      {
RuleFor(query=> query.BookId ).GreaterThan(0);
      }
    }
}