using CompanyTest.Application.Dtos;
using CompanyTest.Application.Features.Companies.Queries.GetAll;
using FastEndpoints;
using MediatR;

namespace CompanyTest.API.Endpoints.Companies.GetAll;

public class GetAllRequest(ISender sender) : EndpointWithoutRequest<IEnumerable<CompanyDto>>
{
    public override void Configure()
    {
        Get(ApiRoutes.CompanyRoutes.Get);
        AllowAnonymous();
        Description(x => x.WithTags(RouteTags.Companies));
    }

    public override async Task HandleAsync(CancellationToken token)
    {
        var result = await sender.Send(new GetAllQuery(), token);

        await SendAsync(result);
    }
}
