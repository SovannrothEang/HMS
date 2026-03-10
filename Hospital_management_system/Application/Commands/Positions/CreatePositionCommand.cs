using Hospital_management_system.Application.Common;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;

namespace Hospital_management_system.Application.Commands.Positions;

public record CreatePositionCommand(string Code, string Name, string Description, string DepartmentId) : IRequest<Result>;

public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, Result>
{
    private readonly IPositionRepository _positionRepository;

    public CreatePositionCommandHandler(IPositionRepository positionRepository)
    {
        _positionRepository = positionRepository;
    }

    public async Task<Result> HandleAsync(CreatePositionCommand request, CancellationToken cancellationToken)
    {
        var existing = await _positionRepository.GetByCodeAsync(request.Code);
        if (existing != null) return Result.Failure("Position code already exists.");

        var position = new Position
        {
            PositionId = Guid.NewGuid().ToString(),
            Code = request.Code,
            Name = request.Name,
            Description = request.Description,
            DepartmentId = request.DepartmentId,
            IsActive = true,
            IsDeleted = false
        };

        var result = await _positionRepository.AddAsync(position);
        return result > 0 ? Result.Success() : Result.Failure("Failed to create position.");
    }
}
