using Hospital_management_system.Application.Common;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;

namespace Hospital_management_system.Application.Commands.Doctors;

public record CreateDoctorCommand(
    string Code, 
    string Specialization, 
    string LicenseNumber, 
    int YearsOfExperience, 
    string StaffId) : IRequest<Result<string>>;

public class CreateDoctorHandler : IRequestHandler<CreateDoctorCommand, Result<string>>
{
    private readonly IDoctorRepository _doctorRepository;

    public CreateDoctorHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<Result<string>> HandleAsync(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        var existing = await _doctorRepository.GetByCodeAsync(request.Code);
        if (existing != null) return Result<string>.Failure("Doctor with this code already exists.");

        var doctor = new Doctor
        {
            DoctorId = Guid.NewGuid().ToString(),
            Code = request.Code,
            Specialization = request.Specialization,
            LicenseNumber = request.LicenseNumber,
            YearsOfExperience = request.YearsOfExperience,
            StaffId = request.StaffId,
            IsActive = true,
            IsDeleted = false,
            CreatedAt = DateTime.Now
        };

        await _doctorRepository.AddAsync(doctor);
        return Result<string>.Success(doctor.DoctorId);
    }
}

public record UpdateDoctorCommand(
    string DoctorId,
    string Code,
    string Specialization, 
    string LicenseNumber, 
    int YearsOfExperience, 
    bool StoppedWork,
    string StaffId) : IRequest<Result>;

public class UpdateDoctorHandler : IRequestHandler<UpdateDoctorCommand, Result>
{
    private readonly IDoctorRepository _doctorRepository;

    public UpdateDoctorHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<Result> HandleAsync(UpdateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _doctorRepository.GetByCodeAsync(request.Code);
        if (doctor == null) return Result.Failure("Doctor not found.");

        doctor.Specialization = request.Specialization;
        doctor.LicenseNumber = request.LicenseNumber;
        doctor.YearsOfExperience = request.YearsOfExperience;
        doctor.StoppedWork = request.StoppedWork;
        doctor.StaffId = request.StaffId;
        doctor.UpdatedAt = DateTime.Now;

        await _doctorRepository.UpdateAsync(doctor);
        return Result.Success();
    }
}

public record DeleteDoctorCommand(string Code) : IRequest<Result>;

public class DeleteDoctorHandler : IRequestHandler<DeleteDoctorCommand, Result>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IPatientRepository _patientRepository;

    public DeleteDoctorHandler(
        IDoctorRepository doctorRepository,
        IPatientRepository patientRepository)
    {
        _doctorRepository = doctorRepository;
        _patientRepository = patientRepository;
    }

    public async Task<Result> HandleAsync(DeleteDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _doctorRepository.GetByCodeAsync(request.Code);
        if (doctor == null) return Result.Failure("Doctor not found.");

        // Check if there are active patients assigned to this doctor
        var hasActivePatients = await _patientRepository.HasActivePatientsAsync(doctor.DoctorId);
        if (hasActivePatients)
        {
            return Result.Failure("Cannot delete this doctor because they have active patients assigned. Please reassign the patients first.");
        }

        await _doctorRepository.DeleteAsync(request.Code);
        return Result.Success();
    }
}
