using EmployeeManagementAPI.Requests;
using FluentValidation;

namespace EmployeeManagementApi.Validators;

public class UpdateEmployeeRequestValidator : AbstractValidator<UpdateEmployeeRequest>
{
    public UpdateEmployeeRequestValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Email).EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.Email));
        RuleFor(x => x.Phone)
            .Matches(@"^\+?[0-9\s\-()]{7,20}$")
            .WithMessage("Phone number is not valid.")
            .When(x => !string.IsNullOrWhiteSpace(x.Phone));
        RuleFor(x => x.DepartmentId).GreaterThan(0);
    }
}