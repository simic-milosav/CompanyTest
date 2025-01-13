using CompanyTest.Application.Dtos;
using MediatR;

namespace CompanyTest.Application.Features.Companies.Commands.Create;
public record CreateCommand(CompanyDto Dto) : IRequest<bool>;
