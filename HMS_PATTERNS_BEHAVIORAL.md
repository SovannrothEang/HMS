# Behavioral Design Patterns in HMS

This document details the **Behavioral** design patterns implementation in the Hospital Management System (HMS), focusing on algorithms and the assignment of responsibilities between objects.

---

## 1. Mediator Pattern

### **Location**
*   **Interface**: `Hospital_management_system/Application/Common/IMediator.cs`
*   **Implementation**: `Hospital_management_system/Application/Common/Mediator.cs`
*   **Usage**: `Hospital_management_system/Infrastructure/ServiceConfigurator.cs` (Registration)

### **Core Concept**
Defines an object that encapsulates how a set of objects interact. Mediator promotes loose coupling by keeping objects from referring to each other explicitly, and it lets you vary their interaction independently.

### **Implementation Details**
The project implements a lightweight version of the popular `MediatR` library. It acts as a dispatcher: it takes a request object and routes it to the correct handler class.

#### **Code Structure**
```csharp
// 1. The Mediator Implementation
public class Mediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;

    public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, ...)
    {
        // Reflection Magic:
        // 1. Determine the type of request (e.g., CreateDoctorCommand)
        // 2. Find the class that implements IRequestHandler<CreateDoctorCommand, TResponse>
        // 3. Instantiate that handler via DI
        // 4. Invoke the HandleAsync method
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        var handler = _serviceProvider.GetRequiredService(handlerType);
        // ... invoke method ...
    }
}
```

### **Usage Context**
Instead of a button click handler containing logic:
```csharp
// BAD: Button Handler
private void btnSave_Click(object sender, EventArgs e) {
    _repo.Save(doctor); // Direct dependency
}
```
We use:
```csharp
// GOOD: Mediator
private async void btnSave_Click(object sender, EventArgs e) {
    // UI doesn't know WHO handles this, just that it needs to be handled
    await _mediator.SendAsync(new CreateDoctorCommand(...)); 
}
```

### **Advantages**
1.  **Decoupling**: The UI form (Presentation) has zero dependency on the Logic/Database. It only depends on the command object (a simple DTO).
2.  **Single Responsibility**: Each `Handler` class does exactly one thing (e.g., `CreateDoctorHandler`). This is much cleaner than a "DoctorService" class with 50 methods.

### **Migration & Evolution**
*   **From (Smart UI / Service Layer)**: Typically, apps start with logic in the UI or a monolithic `DoctorService`.
*   **To (CQRS with Mediator)**: We migrated to this to support **CQRS** (Command Query Responsibility Segregation). It allows us to separate "Reads" (Queries) from "Writes" (Commands) cleanly, which is essential for scaling complex logic.

---

## 2. Command Pattern

### **Location**
*   **Folder**: `Hospital_management_system/Application/Commands/`
*   **Example**: `DoctorCommands.cs`

### **Core Concept**
Encapsulates a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support undoable operations.

### **Implementation Details**
Every distinct action in the system is defined as a `record` (immutable object) that implements `IRequest`.

#### **Code Structure**
```csharp
// The Command Object (Encapsulates "What to do" and "Data needed")
public record CreateDoctorCommand(
    string Code, 
    string Specialization, 
    string LicenseNumber
) : IRequest<Result<string>>;

// The Receiver/Executor (The logic)
public class CreateDoctorHandler : IRequestHandler<CreateDoctorCommand, Result<string>>
{
    public async Task<Result<string>> HandleAsync(CreateDoctorCommand command, ...)
    {
        // Business logic here
    }
}
```

### **Usage Context**
Used alongside the Mediator. The `CreateDoctorCommand` *is* the Command pattern instance.

### **Advantages**
1.  **Parameterization**: The method signature `HandleAsync` is always the same. We don't have methods with 10 arguments; we have one object containing 10 properties.
2.  **Audit Trail**: It becomes very easy to log "User X executed Command Y with Data Z" because the command is just a data object.

---

## 3. Template Method Pattern

### **Location**
*   **Base Class**: `Hospital_management_system/Infrastructure/Persistence/Repositories/DapperRepository.cs`
*   **Concrete Class**: `DoctorRepository.cs`

### **Core Concept**
Defines the skeleton of an algorithm in an operation, deferring some steps to subclasses. Template Method lets subclasses redefine certain steps of an algorithm without changing the algorithm's structure.

### **Implementation Details**
The `DapperRepository<T>` defines the standard "Algorithm" for fetching data (Open connection -> Execute Query -> Return Result).

#### **Code Structure**
```csharp
public abstract class DapperRepository<T>
{
    // The "Template" method
    public virtual async Task<T?> GetByCodeAsync(string code)
    {
        // Step 1: Boilerplate connection logic
        using var connection = _connectionFactory.CreateConnection();
        
        // Step 2: The Logic (with a hook for _tableName)
        return await connection.QueryFirstOrDefaultAsync<T>(
            $"SELECT * FROM {_tableName} WHERE code = @Code...", 
            new { Code = code });
    }
}

public class DoctorRepository : DapperRepository<Doctor>
{
    // Subclass simply provides the configuration
    public DoctorRepository(...) : base(..., TableNames.Doctors) { }
}
```

### **Advantages**
1.  **DRY (Don't Repeat Yourself)**: We wrote the SQL `SELECT * FROM ...` once. 
2.  **Consistency**: Every repository behaves exactly the same way regarding connection handling and disposal.

### **Migration & Evolution**
*   **From (Repeated Code)**: Without this, every repository (`DoctorRepo`, `PatientRepo`) would repeat the `using (var conn = ...)` lines, leading to potential bugs (e.g., forgetting to close connections).

---

## 4. Strategy Pattern

### **Location**
*   **Strategy Interface**: `Hospital_management_system/Domain/Repositories/IDoctorRepository.cs`
*   **Concrete Strategy**: `Hospital_management_system/Infrastructure/Persistence/Repositories/DoctorRepository.cs`

### **Core Concept**
Define a family of algorithms, encapsulate each one, and make them interchangeable. Strategy lets the algorithm vary independently from clients that use it.

### **Implementation Details**
The "Algorithm" here is "How to access data". The interface defines *what* we need, and the implementation defines *how* (using Dapper/SQL).

#### **Code Structure**
```csharp
// Context: CreateDoctorHandler depends on the Strategy Interface
public class CreateDoctorHandler
{
    private readonly IDoctorRepository _repository; // The Strategy

    public CreateDoctorHandler(IDoctorRepository repository)
    {
        _repository = repository;
    }
}
```

### **Advantages**
1.  **Testability**: This is the primary reason. We can swap `DoctorRepository` (SQL Strategy) with `MockDoctorRepository` (Memory List Strategy) for unit tests.
2.  **Database Independence**: If we moved to MongoDB, we would write `MongoDoctorRepository : IDoctorRepository`, change the DI registration, and the rest of the app would never know.

---

## 5. Observer Pattern

### **Location**
*   **Subject**: `Hospital_management_system/Presentation/State/GlobalState.cs`
*   **Observer**: `Hospital_management_system/Presentation/UserControls/DashboardControl.cs`

### **Core Concept**
Define a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.

### **Implementation Details**
We use C# `event` keywords to implement this. `GlobalState` is the Subject. The UI Controls are the Observers.

#### **Code Structure**
```csharp
// Subject
public static class GlobalState
{
    public static event Action DataUpdated; // The notification mechanism

    public static void AddItems(...)
    {
        // Change State
        list.Add(item);
        // Notify Observers
        DataUpdated?.Invoke();
    }
}

// Observer (DashboardControl.cs - conceptual)
public void Initialize()
{
    // Subscribe
    GlobalState.DataUpdated += RefreshCounts;
}
```

### **Usage Context**
When a new Doctor is added in the `DoctorsControl`, the `GlobalState` fires `DataUpdated`. The `DashboardControl` (which shows "Total Doctors: 5") hears this event and re-runs its count logic.

### **Advantages**
1.  **Decoupling**: `DoctorsControl` does not need a reference to `DashboardControl` to tell it to update. It just modifies the state, and the state notifies whoever cares.

---
