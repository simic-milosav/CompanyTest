using CompanyTest.Application.Features.Users.Commands.Delete;
using FastEndpoints;
using MediatR;

namespace CompanyTest.API.Endpoints.Users.Delete;

public class DeleteRequest(ISender sender) : Endpoint<DeleteCommand, bool>
{
    public override void Configure()
    {
        Delete(ApiRoutes.UserRoutes.Delete);
        AllowAnonymous();
        Description(x => x.WithTags(RouteTags.Users));
        Summary(s =>
        {
            s.ExampleRequest = new DeleteCommand(Guid.Empty);
        });
    }

    public override async Task HandleAsync(DeleteCommand command, CancellationToken token)
    {
        var result = await sender.Send(command, token);

        await SendAsync(result);
    }
}
