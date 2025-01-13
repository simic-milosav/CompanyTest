using CompanyTest.Contracts.UnitOfWork;
using CompanyTest.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CompanyTest.Application.Features.Users.Commands.Create;
internal sealed class CreateCommandHandler(
    IUnitOfWork unitOfWork,
    ILogger<CreateCommandHandler> logger) : IRequestHandler<CreateCommand, bool>
{
    public async Task<bool> Handle(CreateCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var repo = unitOfWork.GetRepository<User>();

            var resut = await repo.CreateAsync(new()
            {
                Id = Guid.NewGuid(),
                Name = command.Dto.Name,
                Surname = command.Dto.Surname,
            });

            await unitOfWork.SaveChangesAsync();

            return resut;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while creating new user");
            return false;
        }      
    }
}
