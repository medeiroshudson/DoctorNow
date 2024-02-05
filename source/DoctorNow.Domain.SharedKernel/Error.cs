namespace DoctorNow.Domain.SharedKernel;

public record Error(string Code, string? Message = null);