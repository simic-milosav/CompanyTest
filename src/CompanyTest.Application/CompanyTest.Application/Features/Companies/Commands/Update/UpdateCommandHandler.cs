using CompanyTest.Contracts.UnitOfWork;
using CompanyTest.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CompanyTest.Application.Features.Companies.Commands.Update;
internal sealed class UpdateCommandHandler(
    IUnitOfWork unitOfWork,
    ILogger<UpdateCommandHandler> logger) : IRequestHandler<UpdateCommand, bool>
{
    public async Task<bool> Handle(UpdateCommand command, CancellationToken cancellationToken)
    {
		try
		{
            var repo = unitOfWork.GetRepository<Company>();

            var company = await repo.GetByIdAsync(command.Dto.Id);

            if (company != null)
            {
                company.CompanyName = command.Dto.CompanyName;
                company.Address = command.Dto.Address;

                var result = await repo.UpdateAsync(company);

                await unitOfWork.SaveChangesAsync();

                return result;
            }

            throw new InvalidOperationException($"Company with Id = {command.Dto.Id} does not exists!");

        }
        catch (Exception ex)
		{
            logger.LogError(ex, ex.Message);            
            return false;
        }
    }
}
