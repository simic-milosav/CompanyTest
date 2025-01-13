using CompanyTest.Application.Features.Companies.Commands.Delete;
using FastEndpoints;
using FluentValidation;

namespace CompanyTest.API.Endpoints.Companies.Delete;

public class DeleteRequestValidatior : Validator<DeleteCommand>
{
    public DeleteRequestValidatior()
    {
        RuleFor(r => r.Id)
            .NotEmpty()
            .WithMessage("Company Id is required!");
    }
}
