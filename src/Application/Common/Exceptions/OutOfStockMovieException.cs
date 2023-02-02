using FluentValidation.Results;

namespace MovieApi.Application.Common.Exceptions;
public class OutOfStockMovieException : ValidationException
{
    public OutOfStockMovieException(string fieldName, string errorMessage = "This movie is out of the stock") : base(new List<ValidationFailure>
    {
        new ValidationFailure {
            PropertyName = fieldName,
            ErrorMessage = errorMessage
        }
    })
    {

    }
}