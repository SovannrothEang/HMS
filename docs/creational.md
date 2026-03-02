# Creational Design Patterns in HMS

Creational patterns focus on object creation mechanisms, trying to create objects in a manner suitable to the situation. In HMS, these patterns manage application state, database connections, and dependency resolution.

---

## 1. Singleton Pattern (Monostate Variant)

The project uses a static class implementation (Monostate pattern) to manage global application state. While not a classic singleton with a `.Instance` property, it serves the exact same purpose: ensuring a single shared state across the entire application.

### Class & Location
- **Class**: `GlobalState`
- **Location**: `Hospital_management_system/Presentation/State/GlobalState.cs`

### Structure Code
```csharp
public static class GlobalState
{
    public static string CurrentUsername { get; set; } = null!;
    public static StaffDto CurrentStaffInfo { get; set; } = null!;

    // Shared data lists accessed by multiple forms
    public static BindingList<DepartmentDto> Departments { get; set; } = [];
    public static BindingList<DoctorDto> Doctors { get; set; } = [];
    
    public static void ClearAllData() { ... }
}
```

### Where we use it
- **Auth Flow**: `LoginForm` sets `CurrentUsername` and `CurrentStaffInfo` after successful login.
- **UI Data Caching**: `DepartmentsControl`, `DoctorsControl`, etc., read from and update the static `BindingList` collections.
- **Session Tracking**: Used by `MainForm` to display the current logged-in user details.

### Advantages
- **Shared State**: Provides a single point of truth for application data.
- **Global Access**: Eliminates the need to pass user/data objects through every WinForms constructor.
- **Memory Efficiency**: Avoids redundant data loading across different screens.

### Migration Context
- **From**: Individual forms managing their own local state or passing complex objects.
- **To**: Centralized `GlobalState`.
- **Achievement**: Simplified communication between forms and reduced "prop-drilling" in a complex desktop application architecture.

---

## 2. Factory Method Pattern

Encapsulates the creation of complex objects (Database Connections) through a specialized interface.

### Class & Location
- **Interface**: `IDbConnectionFactory`
- **Concrete Class**: `SqlConnectionFactory`
- **Location**: `Hospital_management_system/Infrastructure/Persistence/IDbConnectionFactory.cs`

### Structure Code
```csharp
public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}

public class SqlConnectionFactory : IDbConnectionFactory
{
    public IDbConnection CreateConnection()
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open(); // Connection is opened immediately for use
        return connection;
    }
}
```

### Where we use it
- **Repositories**: `DapperRepository<T>` and its children call `_connectionFactory.CreateConnection()` for every database operation.
- **Unit of Work**: Used to initialize transactions within `UnitOfWork`.

### Advantages
- **Encapsulation**: Hides connection string handling and initialization logic.
- **Flexibility**: If the database provider changes (e.g., to PostgreSQL or MySQL), only the factory implementation changes; repositories remain untouched.
- **Consistency**: Ensures every connection is initialized and opened in exactly the same way.

### Migration Context
- **From**: **Entity Framework Core (EF Core)** `DbContext`.
- **To**: **Dapper** + `IDbConnectionFactory`.
- **Achievement**: 
    - **Performance**: EF Core's heavy overhead (change tracking, proxy generation) was removed in favor of Dapper's lightning-fast raw SQL execution.
    - **Control**: Developers now have direct control over SQL queries and connection lifecycle, which is critical for complex hospital reporting queries.
    - **Lightweight**: Reduced the application's memory footprint by removing the EF Core engine.

---

## 3. Dependency Injection (DI)

While often considered an architectural pattern, the project implements DI as the core creational strategy for all services and repositories.

### Class & Location
- **Class**: `ServiceConfigurator`
- **Location**: `Hospital_management_system/Infrastructure/ServiceConfigurator.cs`

### Structure Code
```csharp
public static class ServiceConfigurator
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        // Singleton for stateful/global objects
        services.AddSingleton<IDbConnectionFactory>(new SqlConnectionFactory(connectionString));
        
        // Scoped for transaction-bound objects
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        
        // Transient for stateless UI controls
        services.AddTransient<DashboardControl>();
        
        return services;
    }
}
```

### Where we use it
- **Application Startup**: Called in `Program.cs` to initialize the `Host`.
- **UI Constructors**: WinForms controls receive their repositories via constructor injection.

### Advantages
- **Decoupling**: Classes depend on abstractions (interfaces) rather than concrete implementations.
- **Testability**: Makes it trivial to swap real database repositories with "Mock" objects for unit testing.
- **Lifecycle Management**: The DI container handles object disposal and sharing (Singleton vs Scoped) automatically.

### Migration Context
- **From**: Manual instantiation (using `new`) and "Service Locator" patterns.
- **To**: Constructor Injection via Microsoft DI.
- **Achievement**: Significantly cleaner code and eliminated "New-is-Glue" issues, making the system vastly more maintainable.
