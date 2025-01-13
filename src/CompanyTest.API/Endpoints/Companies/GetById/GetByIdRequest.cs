using CompanyTest.Application.Dtos;
using CompanyTest.Application.Features.Companies.Queries.GetById;
using FastEndpoints;
using MediatR;

namespace CompanyTest.API.Endpoints.Companies.GetById;

public class GetByIdRequest(ISender sender) : Endpoint<GetByIdQuery, CompanyDto>
{
    public override void Configure()
    {
        Get(ApiRoutes.CompanyRoutes.GetById);
        AllowAnonymous();
        Description(x => x.WithTags(RouteTags.Companies));
    }

    public override async Task HandleAsync(GetByIdQuery query, CancellationToken token)
    {
        var result = await sender.Send(query, token);

        await SendAsync(result);
    }
}
