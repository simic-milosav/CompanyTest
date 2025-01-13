using CompanyTest.Application.Dtos;
using CompanyTest.Contracts.UnitOfWork;
using CompanyTest.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CompanyTest.Application.Features.Companies.Queries.GetById;
internal sealed class GetByIdQueryHandler(
    IUnitOfWork unitOfWork,
    ILogger<GetByIdQueryHandler> logger) : IRequestHandler<GetByIdQuery, CompanyDto>
{
    public async Task<CompanyDto> Handle(GetByIdQuery query, CancellationToken cancellationToken)
    {
		try
		{
            var repo = unitOfWork.GetRepository<Company>();

            var company = await repo.GetByIdAsync(query.Id);

            if(company != null)
            {
                return new CompanyDto(company.CompanyName, company.Address, company.Id);
            }

            throw new InvalidOperationException($"Company with the Id = {query.Id} not found!");
        }
		catch (Exception ex)
		{
            logger.LogError(ex, ex.Message);
            return default;
		}
    }
}
