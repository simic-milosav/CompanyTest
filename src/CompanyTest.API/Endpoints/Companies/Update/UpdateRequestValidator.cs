using CompanyTest.Application.Features.Companies.Commands.Update;
using FastEndpoints;
using FluentValidation;

namespace CompanyTest.API.Endpoints.Companies.Update;

public class UpdateRequestValidator : Validator<UpdateCommand>
{
    public UpdateRequestValidator()
    {
        RuleFor(r => r.Dto.Id)
            .NotEmpty()
            .WithMessage("Company Id is required!");

        RuleFor(r => r.Dto.CompanyName)
            .NotEmpty()
            .WithMessage("Company name is required!");

        RuleFor(r => r.Dto.Address)
            .NotEmpty()
            .WithMessage("Company address is required!");
    }
}
