using Hospital_management_system.Application.Common;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;

namespace Hospital_management_system.Application.Commands.Departments;

public record UpdateDepartmentCommand(string Code, string Name, string Description) : IRequest<Result>;

public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentCommand, Result>
{
    private readonly IDepartmentRepository _departmentRepository;

    public UpdateDepartmentHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<Result> HandleAsync(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await _departmentRepository.GetByCodeAsync(request.Code);
        if (department == null) return Result.Failure("Department not found.");

        department.Name = request.Name;
        department.Description = request.Description;
        department.UpdatedAt = DateTime.Now;

        await _departmentRepository.UpdateAsync(department);
        return Result.Success();
    }
}

public record DeleteDepartmentCommand(string Code) : IRequest<Result>;

public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentCommand, Result>
{
    private readonly IDepartmentRepository _departmentRepository;

    public DeleteDepartmentHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<Result> HandleAsync(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await _departmentRepository.GetByCodeAsync(request.Code);
        if (department == null) return Result.Failure("Department not found.");

        await _departmentRepository.DeleteAsync(request.Code);
        return Result.Success();
    }
}
