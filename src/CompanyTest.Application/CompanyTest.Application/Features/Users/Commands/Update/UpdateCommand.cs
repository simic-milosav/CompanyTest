using CompanyTest.Application.Dtos;
using MediatR;

namespace CompanyTest.Application.Features.Users.Commands.Update;
public record UpdateCommand(UserDto Dto) : IRequest<bool>;
