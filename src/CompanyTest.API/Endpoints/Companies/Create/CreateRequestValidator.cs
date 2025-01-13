using CompanyTest.Application.Features.Companies.Commands.Create;
using FastEndpoints;
using FluentValidation;

namespace CompanyTest.API.Endpoints.Companies.Create;

public class CreateRequestValidator : Validator<CreateCommand>
{
    public CreateRequestValidator()
    {
        RuleFor(r => r.Dto.CompanyName)
            .NotEmpty()
            .WithMessage("Company name is required!");

        RuleFor(r => r.Dto.Address)
            .NotEmpty()
            .WithMessage("Company address is required!");
    }
}
