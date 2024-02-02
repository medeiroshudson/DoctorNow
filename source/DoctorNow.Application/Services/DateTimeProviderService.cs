using DoctorNow.Domain.SharedKernel.Interfaces;

namespace DoctorNow.Application.Services;

public class DateTimeProviderService : IDateTimeProvider
{
    public DateTime Now => DateTime.UtcNow;
}