# Behavioral Design Patterns in HMS

Behavioral patterns focus on communication between objects, how objects interact, and their responsibilities. In HMS, these patterns decouple UI components from business logic and manage the flow of data through commands and events.

---

## 1. Mediator Pattern

Decouples the UI (Presentation) from the Application business logic. The UI sends a "Request" to the Mediator, which then routes it to the correct "Handler".

### Class & Location
- **Interface**: `IMediator`
- **Concrete Class**: `Mediator`
- **Location**: `Hospital_management_system/Application/Common/Mediator.cs`

### Structure Code
```csharp
public class Mediator : IMediator
{
    public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    {
        // Dynamically finds the handler for the specific request type
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        var handler = _serviceProvider.GetRequiredService(handlerType);
        // Invokes HandleAsync...
    }
}
```

### Where we use it
- **WinForms UI**: `DoctorsControl` calls `_mediator.SendAsync(new CreateDoctorCommand(...))` instead of calling a specific Service class.
- **Application Flow**: The `Mediator` acts as the single entry point for all application operations (Commands/Queries).

### Advantages
- **Decoupling**: The UI doesn't need to know which class handles its request.
- **Maintainability**: Makes it easy to add new features by creating a new Command and Handler, without modifying existing UI code.
- **Consistency**: All requests follow the same execution pipeline (logging, validation, error handling).

### Migration Context
- **From**: Tightly coupled "Service" classes injected directly into every WinForms control.
- **To**: A single `IMediator` interface.
- **Achievement**: 
    - **Reduced Constructor Bloat**: Controls now only need one dependency (`IMediator`) instead of multiple services (e.g., `IDoctorService`, `IStaffService`, `IDeptService`).
    - **Clean Architecture**: Strictly enforces the separation between the Presentation and Application layers.

---

## 2. Command Pattern

Encapsulates all information needed to perform an action or trigger an event into a single "Command" object.

### Class & Location
- **Base Interface**: `IRequest<TResponse>`
- **Command Record**: `CreateDoctorCommand`
- **Location**: `Hospital_management_system/Application/Commands/`

### Structure Code
```csharp
// The Command Object (using C# records for immutability)
public record CreateDoctorCommand(
    string Code, 
    string Specialization, 
    // All required data fields...
) : IRequest<Result<string>>;

// The Command Handler
public class CreateDoctorHandler : IRequestHandler<CreateDoctorCommand, Result<string>>
{
    public async Task<Result<string>> HandleAsync(CreateDoctorCommand request, ...)
    {
        // Business logic to create a doctor...
        return Result<string>.Success(newDoctorCode);
    }
}
```

### Where we use it
- **All Business Actions**: Creating departments, updating staff, deleting patients, and user authentication are all implemented as distinct Commands.

### Advantages
- **Encapsulation**: Every operation is a self-contained object that can be serialized, logged, or queued.
- **Immutability**: Using records ensures that command data cannot be changed once it's created.
- **Auditability**: It's easy to track exactly what data was sent for any operation.

---

## 3. Template Method Pattern

Defines the "skeleton" of an algorithm in a base class, allowing subclasses to override specific steps without changing the overall structure.

### Class & Location
- **Base Class**: `DapperRepository<T>`
- **Location**: `Hospital_management_system/Infrastructure/Persistence/Repositories/DapperRepository.cs`

### Structure Code
```csharp
public abstract class DapperRepository<T>
{
    // The Template Method: Common steps for every database query
    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection(); // Step 1: Create connection
        return await connection.QueryAsync<T>($"SELECT * FROM {_tableName}"); // Step 2: Run SQL
        // Step 3: Connection is automatically closed by 'using'
    }
}
```

### Where we use it
- **All Repositories**: `DoctorRepository`, `StaffRepository`, etc., inherit from `DapperRepository<T>` and use its standardized methods for basic CRUD operations.

### Advantages
- **Code Reuse**: Standard database logic (opening connections, handling Dapper queries) is written only once.
- **Extensibility**: Concrete repositories can override virtual methods to provide custom SQL for specialized entities.

---

## 4. Observer Pattern

Defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified automatically.

### Class & Location
- **Subject**: `GlobalState`
- **Location**: `Hospital_management_system/Presentation/State/GlobalState.cs`

### Structure Code
```csharp
public static class GlobalState
{
    // The Subject Event
    public static event Action DataUpdated = null!;

    public static void AddItems(...)
    {
        // State changes...
        // Notify all Observers (UI controls)
        DataUpdated?.Invoke();
    }
}
```

### Where we use it
- **UI Synchronization**: `DashboardControl`, `DoctorsControl`, and `StaffsControl` subscribe to the `DataUpdated` event. When any control adds or deletes data, all other controls refresh their display automatically.

### Advantages
- **Decoupling**: `GlobalState` doesn't need to know which forms are open; it just "broadcasts" that data has changed.
- **Real-time Updates**: Ensures the user sees consistent data across all open windows.

---

## 5. Strategy Pattern

Defines a family of algorithms and makes them interchangeable. In HMS, interfaces define the "Strategy", and concrete repositories provide the specific implementation.

### Class & Location
- **Strategy Interface**: `IDoctorRepository`
- **Concrete Strategy**: `DoctorRepository` (Dapper Implementation)
- **Location**: `Infrastructure/Persistence/Repositories/`

### Structure Code
```csharp
// The Strategy Interface (Contract)
public interface IDoctorRepository
{
    Task<IEnumerable<Doctor>> GetAllAsync();
}

// The Concrete Strategy (Dapper Implementation)
public class DoctorRepository : DapperRepository<Doctor>, IDoctorRepository { ... }
```

### Where we use it
- **Command Handlers**: Handlers depend on `IDoctorRepository` (the Strategy), not the concrete Dapper class.

### Advantages
- **Interchangeability**: We could swap the Dapper implementation for an Entity Framework implementation or a Mock for testing without changing the handler logic.

---

## 6. Result Pattern

A pattern used for functional error handling, where methods return an object indicating success or failure instead of throwing exceptions.

### Class & Location
- **Class**: `Result<T>`
- **Location**: `Hospital_management_system/Application/Common/Result.cs`

### Structure Code
```csharp
public class Result<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; }
    public string Error { get; }

    public static Result<T> Success(T value) => new(value, true, string.Empty);
    public static Result<T> Failure(string error) => new(default, false, error);
}
```

### Where we use it
- **Business Logic Handlers**: Every command handler returns a `Result` or `Result<T>`.
- **UI Feedback**: Forms check `result.IsSuccess` to decide whether to show a success message or an error dialog.

### Advantages
- **Explicit Failure**: Forces developers to handle errors instead of relying on "try-catch" blocks.
- **Performance**: Avoiding exceptions for expected business failures (e.g., "Duplicate Code" or "User Not Found") is much faster.
- **Clarity**: The method signature clearly states that it might fail and why.

### Migration Context
- **From**: Standard Exception-based control flow (throwing exceptions for validation errors).
- **To**: Result-based control flow.
- **Achievement**: 
    - **Stability**: Fewer unhandled crashes in the WinForms environment.
    - **Readability**: Logic flows naturally through "if (result.IsFailure) return result;" checks.
