using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Data.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.Property(t => t.AccountNumber)
            .HasMaxLength(20)
            .IsRequired();
        
        builder.Property(t => t.Username)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => e.AccountNumber)
            .IsUnique();
    }
}
