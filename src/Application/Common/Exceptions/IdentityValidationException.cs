using FluentValidation.Results;

namespace MovieApi.Application.Common.Exceptions;
public class IdentityValidationException : ValidationException
{
    public IdentityValidationException(string propertyName, List<string> errors)
         : base(errors.Select(error => new ValidationFailure
         {
             PropertyName = propertyName,
             ErrorMessage = error
         }).ToList())
    {

    }
}