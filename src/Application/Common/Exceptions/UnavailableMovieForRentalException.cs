using FluentValidation.Results;

namespace MovieApi.Application.Common.Exceptions;
public class UnavailableMovieForRentalException : ValidationException
{
    public UnavailableMovieForRentalException(string fieldName, string errorMessage = "This movie is not available for rental") : base(new List<ValidationFailure>
    {
        new ValidationFailure {
            PropertyName = fieldName,
            ErrorMessage = errorMessage
        }
    })
    {

    }
}