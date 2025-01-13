using CompanyTest.Application.Dtos;
using MediatR;

namespace CompanyTest.Application.Features.Companies.Queries.GetAll;
public record GetAllQuery() : IRequest<IEnumerable<CompanyDto>>;
