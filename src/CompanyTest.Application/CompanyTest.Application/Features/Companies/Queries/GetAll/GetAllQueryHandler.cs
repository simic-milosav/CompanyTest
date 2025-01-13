using CompanyTest.Application.Dtos;
using CompanyTest.Contracts.UnitOfWork;
using CompanyTest.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CompanyTest.Application.Features.Companies.Queries.GetAll;
internal class GetAllQueryHandler(
    IUnitOfWork unitOfWork,
    ILogger<GetAllQueryHandler> logger) : IRequestHandler<GetAllQuery, IEnumerable<CompanyDto>>
{
    public async Task<IEnumerable<CompanyDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
		try
		{
            var repo = unitOfWork.GetRepository<Company>();

            var companies = await repo.GetAllAsync();

            if (companies != null)
            {
                return companies.Select(u => new CompanyDto(u.CompanyName, u.Address, u.Id)).ToList();
            }

            throw new InvalidOperationException("Error while fetching users.");
        }
        catch (Exception ex)
		{
			logger.LogError(ex, ex.Message);
			return default;
		}
    }
}
