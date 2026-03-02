# Creational Design Patterns in HMS

This document details the **Creational** design patterns implementation in the Hospital Management System (HMS), focusing on object creation mechanisms that increase flexibility and reuse of existing code.

---

## 1. Singleton Pattern (via Static Monostate)

### **Location**
*   **File**: `Hospital_management_system/Presentation/State/GlobalState.cs`
*   **Class**: `GlobalState`

### **Core Concept**
The Singleton pattern ensures a class has only one instance and provides a global point of access to it. In C#, a `static` class acts as a variation called the **Monostate** pattern, where the state is shared across all contexts.

### **Implementation Details**
The implementation uses a `static` class with `static` properties. This serves as a global shared memory space for the application, particularly useful in Windows Forms where passing data between disjointed UI forms is complex.

#### **Code Structure**
```csharp
public static class GlobalState
{
    // 1. Global Session State
    // Stores the currently logged-in user information accessible from anywhere
    public static string CurrentUsername { get; set; } = null!;
    public static StaffDto CurrentStaffInfo { get; set; } = null!;

    // 2. Global Data Cache
    // BindingLists act as a shared data source for UI controls
    public static BindingList<DoctorDto> Doctors { get; set; } = [];
    
    // 3. Global Event Hub
    // Acts as a centralized notification system
    public static event Action DataUpdated = null!;
    
    // 4. Centralized State Management
    public static void ClearAllData()
    {
        // Resets the state cleanly
        Doctors.Clear();
        // ...
    }
}
```

### **Usage Context**
*   **Login**: When a user logs in, `GlobalState.CurrentUsername` is populated.
*   **Dashboard**: The `DashboardControl` displays user info by reading `GlobalState.CurrentStaffInfo`.
*   **Data Binding**: Grids in `DoctorsControl` bind directly to `GlobalState.Doctors`. When this list updates, all listening UI components refresh automatically.

### **Advantages**
1.  **Unified State**: Eliminates "prop-drilling" where you would otherwise have to pass `User` objects through 5 different constructors to get it to a child control.
2.  **Instant UI Synchronization**: Since multiple forms bind to the *same* static list, adding a doctor in one form instantly reflects in another without complex messaging.

### **Migration & Evolution**
*   **From (Legacy/Smart UI)**: In typical legacy WinForms, data is often stored inside the form itself (`this.doctorList`). This leads to data inconsistency where Form A updates a doctor, but Form B still shows the old data.
*   **To (Current)**: By moving to `GlobalState`, we decoupled data from the UI.
*   **Why strict Singleton?**: We avoided a standard `public class Singleton { private static Singleton _instance; }` because a `static class` is simpler in C# when no inheritance is required.

---

## 2. Factory Method Pattern

### **Location**
*   **Interface**: `Hospital_management_system/Infrastructure/Persistence/IDbConnectionFactory.cs`
*   **Implementation**: `Hospital_management_system/Infrastructure/Persistence/SqlConnectionFactory.cs`

### **Core Concept**
Defines an interface for creating an object, but let subclasses decide which class to instantiate. Factory Method lets a class defer instantiation to subclasses.

### **Implementation Details**
We abstract the creation of the SQL connection. The repositories need a connection, but they shouldn't know *how* to create it (connection strings, timeouts, providers).

#### **Code Structure**
```csharp
// 1. The Creator Interface
public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}

// 2. The Concrete Creator
public class SqlConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    // The Factory Method
    public IDbConnection CreateConnection()
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open(); // Encapsulates the "Open" logic
        return connection;
    }
}
```

### **Usage Context**
In `DapperRepository.cs`:
```csharp
using var connection = _connectionFactory.CreateConnection();
```
The repository calls `CreateConnection()` without knowing if it's getting a SQL Server connection, a mocked connection for testing, or a wrapped connection for profiling.

### **Advantages**
1.  **Encapsulation**: The logic of opening the connection (`connection.Open()`) is centralized. If we need to add retry logic for failed connections, we do it in one place.
2.  **Testability**: We can inject a `MockDbConnectionFactory` that returns a fake connection, allowing us to unit test repositories without a real database.

### **Migration & Evolution**
*   **From (Entity Framework Core)**: In EF Core, the `DbContext` handles connection management internally. Developers rarely touch the raw `SqlConnection`.
*   **To (Dapper + Factory)**: Moving to Dapper required us to manage connections manually.
    *   **The Problem**: Instantiating `new SqlConnection("string")` in every repository method leads to code duplication and hardcoded dependencies on SQL Server.
    *   **The Solution**: The Factory Method pattern restores the abstraction we lost by leaving EF Core, giving us the performance of Dapper with the architectural cleanliness of an ORM.

---
