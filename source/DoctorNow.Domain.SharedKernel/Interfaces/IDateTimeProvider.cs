namespace DoctorNow.Domain.SharedKernel.Interfaces;

public interface IDateTimeProvider
{
    public DateTime Now { get; }
}