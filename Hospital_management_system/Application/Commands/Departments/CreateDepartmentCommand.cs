using Hospital_management_system.Application.Common;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Infrastructure.Persistence;

namespace Hospital_management_system.Application.Commands.Departments;

public record CreateDepartmentCommand(string Code, string Name, string Description) : IRequest<Result<string>>;

public class CreateDepartmentHandler : IRequestHandler<CreateDepartmentCommand, Result<string>>
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDepartmentHandler(IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork)
    {
        _departmentRepository = departmentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<string>> HandleAsync(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var existing = await _departmentRepository.GetByCodeAsync(request.Code);
        if (existing != null)
        {
            return Result<string>.Failure("Department with this code already exists.");
        }

        var department = new Department
        {
            DepartmentId = Guid.NewGuid().ToString(),
            Code = request.Code,
            Name = request.Name,
            Description = request.Description,
            IsActive = true,
            IsDeleted = false,
            CreatedAt = DateTime.Now
        };

        // In a real scenario, we might use the Unit of Work transaction if we had multiple operations
        // using (var transaction = _unitOfWork.BeginTransaction()) { ... _unitOfWork.Commit(); }
        
        await _departmentRepository.AddAsync(department);
        
        return Result<string>.Success(department.Code);
    }
}
