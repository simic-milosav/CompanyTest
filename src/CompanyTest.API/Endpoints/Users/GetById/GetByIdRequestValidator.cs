using CompanyTest.Application.Features.Users.Queries.GetById;
using FastEndpoints;
using FluentValidation;

namespace CompanyTest.API.Endpoints.Users.GetById;

public class GetByIdRequestValidator : Validator<GetByIdQuery>
{
    public GetByIdRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty()
            .WithMessage("Company Id is required!");
    }
}
