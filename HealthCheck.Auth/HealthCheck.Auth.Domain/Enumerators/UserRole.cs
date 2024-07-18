using System.ComponentModel;

namespace HealthCheck.Auth.Domain.Enumerators;

public enum UserRole
{
    [Description("Doctor")]
    Doctor = 0,

    [Description("Patient")]
    Patient = 1,
}