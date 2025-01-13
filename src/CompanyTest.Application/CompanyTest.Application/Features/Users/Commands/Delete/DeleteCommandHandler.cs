using CompanyTest.Contracts.UnitOfWork;
using CompanyTest.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CompanyTest.Application.Features.Users.Commands.Delete;
internal sealed class DeleteCommandHandler(
    IUnitOfWork unitOfWork,
    ILogger<DeleteCommandHandler> logger) : IRequestHandler<DeleteCommand, bool>
{
    public async Task<bool> Handle(DeleteCommand command, CancellationToken cancellationToken)
    {
		try
		{
            var repo = unitOfWork.GetRepository<User>();

            var result = await repo.DeleteAsync(command.Id);

            await unitOfWork.SaveChangesAsync();

            return result;
        }
        catch (Exception ex)
		{
            logger.LogError(ex, "Error while delete the user with Id = {id}", command.Id);
            return false;
        }
    }
}
