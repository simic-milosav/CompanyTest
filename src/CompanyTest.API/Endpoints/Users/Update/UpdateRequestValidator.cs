using CompanyTest.Application.Features.Users.Commands.Update;
using FastEndpoints;
using FluentValidation;

namespace CompanyTest.API.Endpoints.Users.Update;

public class UpdateRequestValidator : Validator<UpdateCommand>
{
    public UpdateRequestValidator()
    {
        RuleFor(r => r.Dto.Id)
            .NotEmpty()
            .WithMessage("Company Id is required!");

        RuleFor(r => r.Dto.Name)
            .NotEmpty()
            .WithMessage("Company name is required!");

        RuleFor(r => r.Dto.Surname)
            .NotEmpty()
            .WithMessage("Company address is required!");
    }
}
