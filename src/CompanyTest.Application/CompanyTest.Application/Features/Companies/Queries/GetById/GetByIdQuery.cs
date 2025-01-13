using CompanyTest.Application.Dtos;
using MediatR;

namespace CompanyTest.Application.Features.Companies.Queries.GetById;
public record GetByIdQuery(Guid Id) : IRequest<CompanyDto>;
