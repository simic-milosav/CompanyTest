using CompanyTest.Application.Features.Companies.Commands.Create;
using FastEndpoints;
using MediatR;

namespace CompanyTest.API.Endpoints.Companies.Create;

public class CreateRequest(ISender sender) : Endpoint<CreateCommand, bool>
{
    public override void Configure()
    {
        Post(ApiRoutes.CompanyRoutes.Create);
        AllowAnonymous();
        Description(x => x.WithTags(RouteTags.Companies));
        Summary(s =>
        {
            s.ExampleRequest = new CreateCommand(new("Example Company", "Example Address", Guid.Empty));
        });
    }

    public override async Task HandleAsync(CreateCommand command, CancellationToken token)
    {
        var result = await sender.Send(command, token);

        await SendAsync(result);
    }
}
