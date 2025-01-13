using CompanyTest.Application.Dtos;
using CompanyTest.Application.Features.Users.Queries.GetAll;
using FastEndpoints;
using MediatR;

namespace CompanyTest.API.Endpoints.Users.GetAll;

public class GetAllRequest(ISender sender) : EndpointWithoutRequest<IEnumerable<UserDto>>
{
    public override void Configure()
    {
        Get(ApiRoutes.UserRoutes.Get);
        AllowAnonymous();
        Description(x => x.WithTags(RouteTags.Users));
    }

    public override async Task HandleAsync(CancellationToken token)
    {
        var result = await sender.Send(new GetAllQuery(), token);

        await SendAsync(result);
    }
}
