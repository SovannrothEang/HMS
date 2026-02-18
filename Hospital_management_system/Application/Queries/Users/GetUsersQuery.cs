using Hospital_management_system.Application.Common;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;

namespace Hospital_management_system.Application.Queries.Users;

public record GetUsersQuery : IRequest<IEnumerable<User>>;

public class GetUsersHandler : IRequestHandler<GetUsersQuery, IEnumerable<User>>
{
    private readonly IUserRepository _userRepository;

    public GetUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> HandleAsync(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetAllWithStaffAsync();
    }
}
