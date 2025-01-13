using MediatR;

namespace CompanyTest.Application.Features.Companies.Commands.Delete;
public record DeleteCommand(Guid Id) : IRequest<bool>;
