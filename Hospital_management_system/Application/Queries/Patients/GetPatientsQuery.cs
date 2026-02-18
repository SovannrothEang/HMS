using Hospital_management_system.Application.Common;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;

namespace Hospital_management_system.Application.Queries.Patients;

public record GetPatientsQuery : IRequest<IEnumerable<Patient>>;

public class GetPatientsHandler : IRequestHandler<GetPatientsQuery, IEnumerable<Patient>>
{
    private readonly IPatientRepository _patientRepository;

    public GetPatientsHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<IEnumerable<Patient>> HandleAsync(GetPatientsQuery request, CancellationToken cancellationToken)
    {
        return await _patientRepository.GetAllWithDoctorAsync();
    }
}
