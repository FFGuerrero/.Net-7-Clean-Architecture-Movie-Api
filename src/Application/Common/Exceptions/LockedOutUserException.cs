using FluentValidation.Results;

namespace MovieApi.Application.Common.Exceptions;
public class LockedOutUserException : ValidationException
{
    public LockedOutUserException(string fieldName, string errorMessage = "This user is locked out, please contact your administrator.") : base(new List<ValidationFailure>
    {
         new ValidationFailure {
            PropertyName = fieldName,
            ErrorMessage = errorMessage
        }
    })
    {

    }
}