using CompanyTest.Application.Features.Companies.Queries.GetById;
using FastEndpoints;
using FluentValidation;

namespace CompanyTest.API.Endpoints.Companies.GetById;

public class GetByIdRequestValidator : Validator<GetByIdQuery>
{
    public GetByIdRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty()
            .WithMessage("Company Id is required!");
    }
}
