using CompanyTest.Application.Dtos;
using CompanyTest.Contracts.UnitOfWork;
using CompanyTest.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CompanyTest.Application.Features.Users.Queries.GetById;
internal sealed class GetByIdQueryHandler(
    IUnitOfWork unitOfWork,
    ILogger<GetByIdQueryHandler> logger) : IRequestHandler<GetByIdQuery, UserDto>
{
    public async Task<UserDto> Handle(GetByIdQuery query, CancellationToken cancellationToken)
    {
		try
		{
            var repo = unitOfWork.GetRepository<User>();

            var user = await repo.GetByIdAsync(query.Id);

            if(user != null)
            {
                return new UserDto(user.Name, user.Surname, user.Id);
            }

            throw new InvalidOperationException($"User with the Id = {query.Id} not found!");
        }
		catch (Exception ex)
		{
            logger.LogError(ex, ex.Message);
            return default;
		}
    }
}
