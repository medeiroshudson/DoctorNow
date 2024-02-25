using DoctorNow.Application.Abstractions.Mapping;
using DoctorNow.Application.Features.Users.Contracts;
using DoctorNow.Domain.Users;
using Riok.Mapperly.Abstractions;

namespace DoctorNow.Application.Features.Users;

[Mapper]
public partial class UserMapper : IMapper
{
    public partial UserResponse MapToResponse(User request);
    public partial IEnumerable<UserResponse> MapToResponse(IEnumerable<User> request);
}