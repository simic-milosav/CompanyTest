using CompanyTest.Application.Dtos;
using MediatR;

namespace CompanyTest.Application.Features.Users.Queries.GetById;
public record GetByIdQuery(Guid Id) : IRequest<UserDto>;
