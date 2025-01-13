using CompanyTest.Application.Features.Users.Commands.Update;
using FastEndpoints;
using MediatR;

namespace CompanyTest.API.Endpoints.Users.Update;

public class UpdateRequest(ISender sender) : Endpoint<UpdateCommand, bool>
{
    public override void Configure()
    {
        Put(ApiRoutes.UserRoutes.Update);
        AllowAnonymous();
        Description(x => x.WithTags(RouteTags.Users));
    }

    public override async Task HandleAsync(UpdateCommand command, CancellationToken token)
    {
        var result = await sender.Send(command, token);

        await SendAsync(result);
    }
}
