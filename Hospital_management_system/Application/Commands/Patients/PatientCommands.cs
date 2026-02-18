using Hospital_management_system.Application.Common;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Domain.ValueObjects;

namespace Hospital_management_system.Application.Commands.Patients;

public record CreatePatientCommand(
    string Code, 
    string FirstName, 
    string LastName, 
    DateTime DOB, 
    PersonGender Gender, 
    string? PhoneNumber, 
    string? Address, 
    string? Email, 
    string Sickness, 
    string DoctorId) : IRequest<Result<string>>;

public class CreatePatientHandler : IRequestHandler<CreatePatientCommand, Result<string>>
{
    private readonly IPatientRepository _patientRepository;

    public CreatePatientHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Result<string>> HandleAsync(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var existing = await _patientRepository.GetByCodeAsync(request.Code);
        if (existing != null) return Result<string>.Failure("Patient with this code already exists.");

        var patient = new Patient
        {
            PatientId = Guid.NewGuid().ToString(),
            Code = request.Code,
            FirstName = request.FirstName,
            LastName = request.LastName,
            DOB = request.DOB,
            Gender = request.Gender,
            PhoneNumber = request.PhoneNumber,
            Address = request.Address,
            Email = request.Email,
            Sickness = request.Sickness,
            DoctorId = request.DoctorId,
            IsActive = true,
            IsDeleted = false,
            CreatedAt = DateTime.Now
        };

        await _patientRepository.AddAsync(patient);
        return Result<string>.Success(patient.PatientId);
    }
}

public record UpdatePatientCommand(
    string PatientId,
    string Code,
    string FirstName, 
    string LastName, 
    DateTime DOB, 
    PersonGender Gender, 
    string? PhoneNumber, 
    string? Address, 
    string? Email, 
    string Sickness, 
    string DoctorId,
    bool IsActive) : IRequest<Result>;

public class UpdatePatientHandler : IRequestHandler<UpdatePatientCommand, Result>
{
    private readonly IPatientRepository _patientRepository;

    public UpdatePatientHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Result> HandleAsync(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetByCodeAsync(request.Code);
        if (patient == null) return Result.Failure("Patient not found.");

        patient.FirstName = request.FirstName;
        patient.LastName = request.LastName;
        patient.DOB = request.DOB;
        patient.Gender = request.Gender;
        patient.PhoneNumber = request.PhoneNumber;
        patient.Address = request.Address;
        patient.Email = request.Email;
        patient.Sickness = request.Sickness;
        patient.DoctorId = request.DoctorId;
        patient.IsActive = request.IsActive;
        patient.UpdatedAt = DateTime.Now;

        await _patientRepository.UpdateAsync(patient);
        return Result.Success();
    }
}

public record DeletePatientCommand(string Code) : IRequest<Result>;

public class DeletePatientHandler : IRequestHandler<DeletePatientCommand, Result>
{
    private readonly IPatientRepository _patientRepository;

    public DeletePatientHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Result> HandleAsync(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetByCodeAsync(request.Code);
        if (patient == null) return Result.Failure("Patient not found.");

        await _patientRepository.DeleteAsync(request.Code);
        return Result.Success();
    }
}
