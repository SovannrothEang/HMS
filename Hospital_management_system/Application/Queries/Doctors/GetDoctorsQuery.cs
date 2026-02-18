using Hospital_management_system.Application.Common;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;

namespace Hospital_management_system.Application.Queries.Doctors;

public record GetDoctorsQuery : IRequest<IEnumerable<Doctor>>;

public class GetDoctorsHandler : IRequestHandler<GetDoctorsQuery, IEnumerable<Doctor>>
{
    private readonly IDoctorRepository _doctorRepository;

    public GetDoctorsHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<IEnumerable<Doctor>> HandleAsync(GetDoctorsQuery request, CancellationToken cancellationToken)
    {
        return await _doctorRepository.GetAllWithStaffsAsync();
    }
}
