using DoctorNow.Domain.SharedKernel.Interfaces;

namespace DoctorNow.Domain.Users;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}