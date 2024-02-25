using DoctorNow.Domain.Users;
using DoctorNow.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DoctorNow.Infrastructure.Persistence.Repositories.Users;

public class UserRepository(AppDbContext dbContext) 
    : Repository<User>(dbContext), IUserRepository
{
    private readonly AppDbContext _dbContext1 = dbContext;

    public Task<User?> GetByEmailAsync(string email)
        => _dbContext1.Users.FirstOrDefaultAsync(u => u.Email == email);
}