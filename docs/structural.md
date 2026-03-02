# Structural Design Patterns in HMS

Structural patterns explain how to assemble objects and classes into larger structures while keeping these structures flexible and efficient. In HMS, these patterns manage data access, mapping, and transaction integrity.

---

## 1. Repository Pattern

The project uses the Repository pattern to encapsulate all database access logic behind a clean, domain-centric interface.

### Class & Location
- **Base Class**: `DapperRepository<T>`
- **Interface**: `IDoctorRepository`
- **Concrete Class**: `DoctorRepository`
- **Location**: `Hospital_management_system/Infrastructure/Persistence/Repositories/`

### Structure Code
```csharp
public abstract class DapperRepository<T>
{
    // The Template Method for database operations
    public virtual async Task<T?> GetByCodeAsync(string code)
    {
        using var connection = _connectionFactory.CreateConnection();
        // Common logic for all entities
        return await connection.QueryFirstOrDefaultAsync<T>(
            $"SELECT * FROM {_tableName} WHERE code = @Code...", 
            new { Code = code });
    }
}

public class DoctorRepository : DapperRepository<Doctor>, IDoctorRepository
{
    // Specific implementation for Doctor entities
}
```

### Where we use it
- **Infrastructure Layer**: Concrete repositories (`DoctorRepository`, `StaffRepository`, `PatientRepository`, etc.).
- **Application Handlers**: Commands like `CreateDoctorHandler` use these repositories to interact with the database.

### Advantages
- **Decoupling**: Business logic (Commands) doesn't know about SQL or Dapper.
- **Maintainability**: If a table schema changes, only the repository code needs an update.
- **Consistency**: Standardized CRUD operations across the entire application.

### Migration Context
- **From**: **Entity Framework Core (EF Core)** `DbSet` collections.
- **To**: **Dapper** based `DapperRepository<T>`.
- **Achievement**: 
    - **Optimization**: EF Core's automatic query generation often resulted in sub-optimal SQL for complex joins. Moving to manual Dapper repositories allows for hand-optimized SQL.
    - **Reduced Complexity**: Removed the heavy EF context and Migrations system in favor of simple SQL queries.
    - **Direct Mapping**: Leverages Dapper's fast object-mapping capabilities without EF's change tracking overhead.

---

## 2. Adapter / Mapper Pattern

HMS uses static extension methods to "adapt" Domain Entities into Data Transfer Objects (DTOs) for the presentation layer.

### Class & Location
- **Class**: `DoctorMapper`
- **Location**: `Hospital_management_system/Application/Mapper/DoctorMapper.cs`

### Structure Code
```csharp
public static class DoctorMapper
{
    public static DoctorDto ToDto(this Doctor entity)
    {
        return new DoctorDto()
        {
            DoctorId = entity.DoctorId,
            Code = entity.Code,
            // Adapting complex relationship to flat property
            Staff = entity.Staff?.ToDto(), 
            // Mapping other properties...
        };
    }
}
```

### Where we use it
- **Application Layer**: Handlers map database results to DTOs before sending them to the UI.
- **UI Logic**: When displaying data in a `DataGridView`, the UI works only with these "adapted" DTOs.

### Advantages
- **Separation of Concerns**: Prevents UI controls from being tightly coupled to the database schema (Entities).
- **Data Security**: DTOs can exclude sensitive information (e.g., passwords or internal flags) that shouldn't reach the Presentation layer.
- **View Optimization**: DTOs are "flat" and designed specifically for what the WinForms screens need to display.

### Migration Context
- **From**: Passing Entity Framework (EF) Entities directly to WinForms.
- **To**: Manual Mappers and DTOs.
- **Achievement**: 
    - **Avoided "Object Disposed" Errors**: EF Entities often require an open `DbContext` for lazy loading; DTOs are plain objects that work anywhere.
    - **Cleaner UI Code**: Presentation logic no longer needs to handle complex navigation properties (e.g., `doctor.Staff.User.Name`).

---

## 3. Unit of Work Pattern

Coordinates the work of multiple repositories by sharing a single database transaction.

### Class & Location
- **Interface**: `IUnitOfWork`
- **Concrete Class**: `UnitOfWork`
- **Location**: `Hospital_management_system/Infrastructure/Persistence/UnitOfWork.cs`

### Structure Code
```csharp
public class UnitOfWork : IUnitOfWork
{
    public IDbTransaction BeginTransaction() { ... }
    public void Commit() 
    { 
        _transaction?.Commit(); 
        // Logic to close connection...
    }
    public void Rollback() { _transaction?.Rollback(); }
}
```

### Where we use it
- **Complex Commands**: For example, when creating a `Staff` record AND a `User` record simultaneously, the `UnitOfWork` ensures both succeed or both fail (Atomicity).

### Advantages
- **Transaction Integrity**: Prevents partial data updates (e.g., a doctor created without their associated staff record).
- **Resource Management**: Ensures only one connection and transaction are active for a single business operation.
- **Simplified Error Handling**: If any repository fails, a single `Rollback()` call reverts everything.

### Migration Context
- **From**: Implicit transactions in EF Core's `SaveChangesAsync()`.
- **To**: Explicit Dapper-based `UnitOfWork`.
- **Achievement**: 
    - **Transparency**: Developers now explicitly declare when a transaction starts and ends, making the code's transactional behavior clear and predictable.
    - **Control**: Allows fine-grained control over isolation levels and transaction scope within Dapper.
