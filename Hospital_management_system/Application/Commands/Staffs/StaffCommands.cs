using Hospital_management_system.Application.Common;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Domain.ValueObjects;

namespace Hospital_management_system.Application.Commands.Staffs;

public record CreateStaffCommand(
    string Code, 
    string FirstName, 
    string LastName, 
    DateTime DOB, 
    PersonGender Gender, 
    string? PhoneNumber, 
    string? Address, 
    string? Email, 
    string PositionId, 
    DateTime HiredDate, 
    decimal Salary, 
    string DepartmentId) : IRequest<Result<string>>;

public class CreateStaffHandler : IRequestHandler<CreateStaffCommand, Result<string>>
{
    private readonly IStaffRepository _staffRepository;

    public CreateStaffHandler(IStaffRepository staffRepository)
    {
        _staffRepository = staffRepository;
    }

    public async Task<Result<string>> HandleAsync(CreateStaffCommand request, CancellationToken cancellationToken)
    {
        var existing = await _staffRepository.GetByCodeAsync(request.Code);
        if (existing != null) return Result<string>.Failure("Staff with this code already exists.");

        var staff = new Staff
        {
            StaffId = Guid.NewGuid().ToString(),
            Code = request.Code,
            FirstName = request.FirstName,
            LastName = request.LastName,
            DOB = request.DOB,
            Gender = request.Gender,
            PhoneNumber = request.PhoneNumber,
            Address = request.Address,
            Email = request.Email,
            PositionId = request.PositionId,
            HiredDate = request.HiredDate,
            Salary = request.Salary,
            DepartmentId = request.DepartmentId,
            IsActive = true,
            IsDeleted = false,
            CreatedAt = DateTime.Now
        };

        await _staffRepository.AddAsync(staff);
        return Result<string>.Success(staff.StaffId);
    }
}

public record UpdateStaffCommand(
    string StaffId,
    string Code,
    string FirstName, 
    string LastName, 
    DateTime DOB, 
    PersonGender Gender, 
    string? PhoneNumber, 
    string? Address, 
    string? Email, 
    string PositionId, 
    DateTime HiredDate, 
    decimal Salary, 
    string DepartmentId,
    bool IsActive) : IRequest<Result>;

public class UpdateStaffHandler : IRequestHandler<UpdateStaffCommand, Result>
{
    private readonly IStaffRepository _staffRepository;

    public UpdateStaffHandler(IStaffRepository staffRepository)
    {
        _staffRepository = staffRepository;
    }

    public async Task<Result> HandleAsync(UpdateStaffCommand request, CancellationToken cancellationToken)
    {
        var staff = await _staffRepository.GetByCodeAsync(request.Code);
        if (staff == null) return Result.Failure("Staff not found.");

        staff.FirstName = request.FirstName;
        staff.LastName = request.LastName;
        staff.DOB = request.DOB;
        staff.Gender = request.Gender;
        staff.PhoneNumber = request.PhoneNumber;
        staff.Address = request.Address;
        staff.Email = request.Email;
        staff.PositionId = request.PositionId;
        staff.HiredDate = request.HiredDate;
        staff.Salary = request.Salary;
        staff.DepartmentId = request.DepartmentId;
        staff.IsActive = request.IsActive;
        staff.UpdatedAt = DateTime.Now;

        await _staffRepository.UpdateAsync(staff);
        return Result.Success();
    }
}

public record DeleteStaffCommand(string Code) : IRequest<Result>;

public class DeleteStaffHandler : IRequestHandler<DeleteStaffCommand, Result>
{
    private readonly IStaffRepository _staffRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IPatientRepository _patientRepository;

    public DeleteStaffHandler(
        IStaffRepository staffRepository,
        IDoctorRepository doctorRepository,
        IPatientRepository patientRepository)
    {
        _staffRepository = staffRepository;
        _doctorRepository = doctorRepository;
        _patientRepository = patientRepository;
    }

    public async Task<Result> HandleAsync(DeleteStaffCommand request, CancellationToken cancellationToken)
    {
        var staff = await _staffRepository.GetByCodeAsync(request.Code);
        if (staff == null) return Result.Failure("Staff not found.");

        // Validation for Staff who is also a Doctor
        var doctor = await _doctorRepository.GetByStaffIdAsync(staff.StaffId);
        if (doctor != null)
        {
            var hasActivePatients = await _patientRepository.HasActivePatientsAsync(doctor.DoctorId);
            if (hasActivePatients)
            {
                return Result.Failure("Cannot delete this staff member because they are a doctor with active patients assigned. Please reassign the patients first.");
            }

            // If no patients, cascade soft-delete the doctor record first
            await _doctorRepository.DeleteAsync(doctor.Code);
        }

        // Finally, delete the staff
        await _staffRepository.DeleteAsync(request.Code);
        return Result.Success();
    }
}
