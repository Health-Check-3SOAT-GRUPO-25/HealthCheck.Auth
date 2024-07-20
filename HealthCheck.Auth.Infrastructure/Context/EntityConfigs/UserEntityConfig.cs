using HealthCheck.Auth.Domain.Entities;
using HealthCheck.Auth.Domain.Enumerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCheck.Auth.Infrastructure.Context.EntityConfigs;

public class UserEntityConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.Cpf)
            .IsRequired(false)
            .HasMaxLength(15);

        builder.Property(x => x.Crm)
            .IsRequired(false);

        builder.Property(x => x.Email)
            .IsRequired(false)
            .HasMaxLength(100);

        builder.Property(x => x.PasswordHash)
            .IsRequired();

        builder.HasData(
            new User(
                null!,
                "000000",
                "Doctor One",
                "doctor1@healthcheck.com",
                "$2a$11$C99.K9/gfTc0RqR8XYAiu.T3BG/GvWgOt2oggKkyivz9dGpZPwpEy",
                UserRole.Doctor
            ),
            new User(
                null!,
                "111111",
                "Doctor Two",
                "doctor2@healthcheck.com",
                "$2a$11$C99.K9/gfTc0RqR8XYAiu.T3BG/GvWgOt2oggKkyivz9dGpZPwpEy",
                UserRole.Doctor
            ),
            new User(
                "22222222222",
                null!,
                "Patient One",
                "patient1@healthcheck.com",
                "$2a$11$C99.K9/gfTc0RqR8XYAiu.T3BG/GvWgOt2oggKkyivz9dGpZPwpEy",
                UserRole.Patient
            ),
            new User(
                "33333333333",
                null!,
                "Patient Two",
                "patient2@healthcheck.com",
                "$2a$11$C99.K9/gfTc0RqR8XYAiu.T3BG/GvWgOt2oggKkyivz9dGpZPwpEy",
                UserRole.Patient
            )
        );
    }
}
