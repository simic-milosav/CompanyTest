using CompanyTest.Application.Dtos;
using CompanyTest.Contracts.UnitOfWork;
using CompanyTest.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CompanyTest.Application.Features.Users.Queries.GetAll;
internal class GetAllQueryHandler(
    IUnitOfWork unitOfWork,
    ILogger<GetAllQueryHandler> logger) : IRequestHandler<GetAllQuery, IEnumerable<UserDto>>
{
    public async Task<IEnumerable<UserDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
		try
		{
            var repo = unitOfWork.GetRepository<User>();

            var users = await repo.GetAllAsync();

            if (users != null)
            {
                return users.Select(u => new UserDto(u.Name, u.Surname, u.Id)).ToList();
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
