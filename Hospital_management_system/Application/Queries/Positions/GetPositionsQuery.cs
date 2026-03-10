using Hospital_management_system.Application.Common;
using Hospital_management_system.Application.DTOs;
using Hospital_management_system.Application.Mapper;
using Hospital_management_system.Domain.Repositories;

namespace Hospital_management_system.Application.Queries.Positions;

public record GetPositionsQuery : IRequest<IEnumerable<PositionDto>>;

public class GetPositionsQueryHandler : IRequestHandler<GetPositionsQuery, IEnumerable<PositionDto>>
{
    private readonly IPositionRepository _positionRepository;

    public GetPositionsQueryHandler(IPositionRepository positionRepository)
    {
        _positionRepository = positionRepository;
    }

    public async Task<IEnumerable<PositionDto>> HandleAsync(GetPositionsQuery request, CancellationToken cancellationToken)
    {
        var positions = await _positionRepository.GetAllAsync();
        return positions.Select(p => p.ToDto());
    }
}
