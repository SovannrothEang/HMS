using Hospital_management_system.Application.Common;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;

namespace Hospital_management_system.Application.Commands.Users;

public record CreateUserCommand(
    string Code, 
    string Username, 
    string Password, 
    string StaffId) : IRequest<Result<string>>;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Result<string>>
{
    private readonly IUserRepository _userRepository;

    public CreateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<string>> HandleAsync(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var existing = await _userRepository.GetByUsernameAsync(request.Username);
        if (existing != null) return Result<string>.Failure("Username already exists.");

        var user = new User
        {
            UserId = Guid.NewGuid().ToString(),
            Code = request.Code,
            Username = request.Username,
            Password = request.Password,
            StaffId = request.StaffId,
            IsActive = true,
            IsDeleted = false,
            CreatedAt = DateTime.Now
        };

        await _userRepository.AddAsync(user);
        return Result<string>.Success(user.UserId);
    }
}

public record UpdateUserCommand(
    string UserId,
    string Code,
    string Username, 
    string Password, 
    string StaffId,
    bool IsActive) : IRequest<Result>;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Result>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result> HandleAsync(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByCodeAsync(request.Code);
        if (user == null) return Result.Failure("User not found.");

        user.Username = request.Username;
        user.Password = request.Password;
        user.StaffId = request.StaffId;
        user.IsActive = request.IsActive;
        user.UpdatedAt = DateTime.Now;

        await _userRepository.UpdateAsync(user);
        return Result.Success();
    }
}

public record DeleteUserCommand(string Code) : IRequest<Result>;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Result>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result> HandleAsync(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByCodeAsync(request.Code);
        if (user == null) return Result.Failure("User not found.");

        await _userRepository.DeleteAsync(request.Code);
        return Result.Success();
    }
}
