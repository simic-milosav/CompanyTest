using CompanyTest.Application.Features.Companies.Commands.Update;
using FastEndpoints;
using MediatR;

namespace CompanyTest.API.Endpoints.Companies.Update;

public class UpdateRequest(ISender sender) : Endpoint<UpdateCommand, bool>
{
    public override void Configure()
    {
        Put(ApiRoutes.CompanyRoutes.Update);
        AllowAnonymous();
        Description(x => x.WithTags(RouteTags.Companies));
    }

    public override async Task HandleAsync(UpdateCommand command, CancellationToken token)
    {
        var result = await sender.Send(command, token);

        await SendAsync(result);
    }
}
