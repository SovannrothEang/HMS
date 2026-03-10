using Hospital_management_system.Application.Common;
using Hospital_management_system.Domain.Repositories;

namespace Hospital_management_system.Application.Commands.Positions;

public record DeletePositionCommand(string Code) : IRequest<Result>;

public class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand, Result>
{
    private readonly IPositionRepository _positionRepository;

    public DeletePositionCommandHandler(IPositionRepository positionRepository)
    {
        _positionRepository = positionRepository;
    }

    public async Task<Result> HandleAsync(DeletePositionCommand request, CancellationToken cancellationToken)
    {
        var result = await _positionRepository.DeleteAsync(request.Code);
        return result > 0 ? Result.Success() : Result.Failure("Failed to delete position.");
    }
}
