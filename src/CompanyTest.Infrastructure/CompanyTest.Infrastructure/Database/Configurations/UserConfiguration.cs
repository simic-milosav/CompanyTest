using CompanyTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyTest.Infrastructure.Database.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder
            .Property(x => x.Id)
            .IsRequired();
        builder
            .Property(x => x.Name)
            .IsRequired();
        builder
            .Property(x => x.Surname)
            .IsRequired();
    }
}
