using CompanyTest.Application.Dtos;
using CompanyTest.Application.Features.Users.Queries.GetById;
using FastEndpoints;
using MediatR;

namespace CompanyTest.API.Endpoints.Users.GetById;

public class GetByIdRequest(ISender sender) : Endpoint<GetByIdQuery, UserDto>
{
    public override void Configure()
    {
        Get(ApiRoutes.UserRoutes.GetById);
        AllowAnonymous();
        Description(x => x.WithTags(RouteTags.Users));
    }

    public override async Task HandleAsync(GetByIdQuery query, CancellationToken token)
    {
        var result = await sender.Send(query, token);

        await SendAsync(result);
    }
}
