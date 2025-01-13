using CompanyTest.Contracts.UnitOfWork;
using CompanyTest.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CompanyTest.Application.Features.Companies.Commands.Create;
internal sealed class CreateCommandHandler(
    IUnitOfWork unitOfWork,
    ILogger<CreateCommandHandler> logger) : IRequestHandler<CreateCommand, bool>
{
    public async Task<bool> Handle(CreateCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var repo = unitOfWork.GetRepository<Company>();

            var resut = await repo.CreateAsync(new()
            {
                Id = Guid.NewGuid(),
                CompanyName = command.Dto.CompanyName,
                Address = command.Dto.Address,
            });

            await unitOfWork.SaveChangesAsync();

            return resut;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while creating new company");
            return false;
        }      
    }
}
