using CompanyTest.Application.Dtos;
using MediatR;

namespace CompanyTest.Application.Features.Users.Queries.GetAll;
public record GetAllQuery() : IRequest<IEnumerable<UserDto>>;
