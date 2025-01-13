using CompanyTest.Application.Dtos;
using MediatR;

namespace CompanyTest.Application.Features.Companies.Commands.Update;
public record UpdateCommand(CompanyDto Dto) : IRequest<bool>;
