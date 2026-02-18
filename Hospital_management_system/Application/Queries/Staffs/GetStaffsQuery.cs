using Hospital_management_system.Application.Common;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;

namespace Hospital_management_system.Application.Queries.Staffs;

public record GetStaffsQuery : IRequest<IEnumerable<Staff>>;

public class GetStaffsHandler : IRequestHandler<GetStaffsQuery, IEnumerable<Staff>>
{
    private readonly IStaffRepository _staffRepository;

    public GetStaffsHandler(IStaffRepository staffRepository)
    {
        _staffRepository = staffRepository;
    }

    public async Task<IEnumerable<Staff>> HandleAsync(GetStaffsQuery request, CancellationToken cancellationToken)
    {
        return await _staffRepository.GetAllWithDepartmentsAsync();
    }
}
