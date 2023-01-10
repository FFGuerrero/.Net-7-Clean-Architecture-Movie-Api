using FluentValidation.Results;

namespace MovieApi.Application.Common.Exceptions;
public class InvalidUserCredentialsException : ValidationException
{
    public InvalidUserCredentialsException(string fieldName, string errorMessage = "Invalid credentials, please confirm your userName or password.") : base(new List<ValidationFailure>
    {
        new ValidationFailure {
            PropertyName = fieldName,
            ErrorMessage = errorMessage
        }
    })
    {

    }
}