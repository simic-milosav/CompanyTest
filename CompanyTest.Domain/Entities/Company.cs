namespace CompanyTest.Domain.Entities;
public class Company : EntityBase
{
    public required string CompanyName { get; set; }
    public required string Address { get; set; }
}
