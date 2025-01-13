using CompanyTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyTest.Infrastructure.Database.Configurations;
public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(x => x.Id);
        builder
            .Property(x => x.Id)
            .IsRequired();
        builder
            .Property(x => x.CompanyName)
            .IsRequired();
        builder
            .Property(x => x.Address)
            .IsRequired();
    }
}
