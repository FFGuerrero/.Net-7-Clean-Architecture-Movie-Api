using FluentValidation.Results;

namespace MovieApi.Application.Common.Exceptions;
public class UnavailableMovieForSaleException : ValidationException
{
    public UnavailableMovieForSaleException(string fieldName, string errorMessage = "This movie is not available for sale") : base(new List<ValidationFailure>
    {
        new ValidationFailure {
            PropertyName = fieldName,
            ErrorMessage = errorMessage
        }
    })
    {

    }
}