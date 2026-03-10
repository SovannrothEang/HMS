using Hospital_management_system.Application.Common;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;

namespace Hospital_management_system.Application.Commands.Positions;

public record UpdatePositionCommand(string PositionId, string Code, string Name, string Description, string DepartmentId, bool IsActive) : IRequest<Result>;

public class UpdatePositionCommandHandler : IRequestHandler<UpdatePositionCommand, Result>
{
    private readonly IPositionRepository _positionRepository;

    public UpdatePositionCommandHandler(IPositionRepository positionRepository)
    {
        _positionRepository = positionRepository;
    }

    public async Task<Result> HandleAsync(UpdatePositionCommand request, CancellationToken cancellationToken)
    {
        var existing = await _positionRepository.GetByCodeAsync(request.Code);
        if (existing == null) return Result.Failure("Position not found.");

        existing.Name = request.Name;
        existing.Description = request.Description;
        existing.DepartmentId = request.DepartmentId;
        existing.IsActive = request.IsActive;

        var result = await _positionRepository.UpdateAsync(existing);
        return result > 0 ? Result.Success() : Result.Failure("Failed to update position.");
    }
}
