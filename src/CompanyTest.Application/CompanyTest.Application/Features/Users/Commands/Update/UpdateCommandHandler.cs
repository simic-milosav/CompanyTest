using CompanyTest.Contracts.UnitOfWork;
using CompanyTest.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CompanyTest.Application.Features.Users.Commands.Update;
internal sealed class UpdateCommandHandler(
    IUnitOfWork unitOfWork,
    ILogger<UpdateCommandHandler> logger) : IRequestHandler<UpdateCommand, bool>
{
    public async Task<bool> Handle(UpdateCommand command, CancellationToken cancellationToken)
    {
		try
		{
            var repo = unitOfWork.GetRepository<User>();

            var user = await repo.GetByIdAsync(command.Dto.Id);

            if (user != null)
            {
                user.Name = command.Dto.Name;
                user.Surname = command.Dto.Surname;

                var result = await repo.UpdateAsync(user);

                await unitOfWork.SaveChangesAsync();

                return result;
            }

            throw new InvalidOperationException($"User with Id = {command.Dto.Id} does not exists!");

        }
        catch (Exception ex)
		{
            logger.LogError(ex, ex.Message);            
            return false;
        }
    }
}
