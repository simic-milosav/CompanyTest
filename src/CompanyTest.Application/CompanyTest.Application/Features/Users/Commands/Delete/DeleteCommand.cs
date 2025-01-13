using MediatR;

namespace CompanyTest.Application.Features.Users.Commands.Delete;
public record DeleteCommand(Guid Id) : IRequest<bool>;
