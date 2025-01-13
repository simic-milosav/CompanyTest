using CompanyTest.Application.Dtos;
using MediatR;

namespace CompanyTest.Application.Features.Users.Commands.Create;
public record CreateCommand(UserDto Dto) : IRequest<bool>;
