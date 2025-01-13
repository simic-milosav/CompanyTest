using CompanyTest.Application.Features.Users.Commands.Create;
using FastEndpoints;
using FluentValidation;

namespace CompanyTest.API.Endpoints.Users.Create;

public class CreateRequestValidator : Validator<CreateCommand>
{
    public CreateRequestValidator()
    {
        RuleFor(r => r.Dto.Name)
            .NotEmpty()
            .WithMessage("Company name is required!");

        RuleFor(r => r.Dto.Surname)
            .NotEmpty()
            .WithMessage("Company address is required!");
    }
}
