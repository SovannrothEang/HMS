using Hospital_management_system.Application.Common;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;

namespace Hospital_management_system.Application.Queries.Departments;

public record GetDepartmentsQuery : IRequest<IEnumerable<Department>>;

public class GetDepartmentsHandler : IRequestHandler<GetDepartmentsQuery, IEnumerable<Department>>
{
    private readonly IDepartmentRepository _departmentRepository;

    public GetDepartmentsHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<IEnumerable<Department>> HandleAsync(GetDepartmentsQuery request, CancellationToken cancellationToken)
    {
        return await _departmentRepository.GetAllAsync();
    }
}
