using CompanyTest.Application.Features.Users.Commands.Delete;
using FastEndpoints;
using FluentValidation;

namespace CompanyTest.API.Endpoints.Users.Delete;

public class DeleteRequestValidatior : Validator<DeleteCommand>
{
    public DeleteRequestValidatior()
    {
        RuleFor(r => r.Id)
            .NotEmpty()
            .WithMessage("Company Id is required!");
    }
}
