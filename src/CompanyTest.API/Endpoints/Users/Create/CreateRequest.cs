using CompanyTest.Application.Features.Users.Commands.Create;
using FastEndpoints;
using MediatR;

namespace CompanyTest.API.Endpoints.Users.Create;

public class CreateRequest(ISender sender) : Endpoint<CreateCommand, bool>
{
    public override void Configure()
    {
        Post(ApiRoutes.UserRoutes.Create);
        AllowAnonymous();
        Description(x => x.WithTags(RouteTags.Users));
        Summary(s =>
        {
            s.ExampleRequest = new CreateCommand(new("Example User", "Example Surname", Guid.Empty));
        });
    }

    public override async Task HandleAsync(CreateCommand command, CancellationToken token)
    {
        var result = await sender.Send(command, token);

        await SendAsync(result);
    }
}
