using Hospital_management_system.Application.Common;
using Hospital_management_system.Domain.Repositories;

namespace Hospital_management_system.Application.Commands.Positions;

public record DeletePositionCommand(string Code) : IRequest<Result>;

public class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand, Result>
{
    private readonly IPositionRepository _positionRepository;
    private readonly IStaffRepository _staffRepository;

    public DeletePositionCommandHandler(IPositionRepository positionRepository, IStaffRepository staffRepository)
    {
        _positionRepository = positionRepository;
        _staffRepository = staffRepository;
    }

    public async Task<Result> HandleAsync(DeletePositionCommand request, CancellationToken cancellationToken)
    {
        var position = await _positionRepository.GetByCodeAsync(request.Code);
        if (position == null) return Result.Failure("Position not found.");

        // Guard: Check if position has staff assigned to it
        var staff = await _staffRepository.GetByPositionIdAsync(position.PositionId);
        if (staff.Any())
        {
            return Result.Failure("Cannot delete position because it is currently assigned to one or more staff members. Please reassign the staff first.");
        }

        var result = await _positionRepository.DeleteAsync(request.Code);
        return result > 0 ? Result.Success() : Result.Failure("Failed to delete position.");
    }
}
