using FluentValidation.Results;

namespace MovieApi.Application.Common.Exceptions;
public class RoleAlreadyAssignedException : ValidationException
{
    public RoleAlreadyAssignedException(string fieldName, string errorMessage = "This role is already assigned to this user") : base(new List<ValidationFailure>
    {
        new ValidationFailure {
            PropertyName = fieldName,
            ErrorMessage = errorMessage
        }
    })
    {

    }
}