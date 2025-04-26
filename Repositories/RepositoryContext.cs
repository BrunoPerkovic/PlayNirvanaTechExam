using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlayNirvanaTechExam.Entities;

namespace PlayNirvanaTechExam.Repositories;

public class RepositoryContext : IdentityDbContext<User, IdentityRole, string>
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                {
                    property.SetValueConverter(new ValueConverter<DateTime, DateTime>(
                        v => v.Kind == DateTimeKind.Utc ? v : v.ToUniversalTime(),
                        v => DateTime.SpecifyKind(v, DateTimeKind.Utc)));
                }
            }
        }

        base.OnModelCreating(builder);

        builder.Entity<User>(entity =>
        {
            entity.Property(u => u.UserName)
                .IsRequired();
            entity.HasIndex(u => u.UserName)
                .IsUnique();
            entity.Property(u => u.RefreshTokenExpiryTime)
                .HasConversion(v => v,
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        });
        builder.HasDefaultSchema("identity");
    }
}