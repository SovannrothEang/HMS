# Structural Design Patterns in HMS

This document details the **Structural** design patterns implementation in the Hospital Management System (HMS), focusing on how classes and objects are composed to form larger structures.

---

## 1. Adapter Pattern (via Extension Methods)

### **Location**
*   **Folder**: `Hospital_management_system/Application/Mapper/`
*   **Examples**: `DoctorMapper.cs`, `PatientMapper.cs`, `StaffMapper.cs`

### **Core Concept**
The Adapter pattern allows objects with incompatible interfaces to work together. It wraps an object in an adapter to make it look like something else.

### **Implementation Details**
In this project, the "Adapter" is implemented functionally using C# Extension Methods. We are adapting the **Domain Entity** (rich behavior, database structure) to a **Data Transfer Object (DTO)** (flat structure, UI-optimized).

#### **Code Structure**
```csharp
// The "Adaptee" is the Doctor entity
// The "Target" is the DoctorDto

public static class DoctorMapper
{
    // This extension method acts as the Adapter
    public static DoctorDto ToDto(this Doctor entity)
    {
        if (entity == null) return null;

        return new DoctorDto()
        {
            // Direct mapping
            DoctorId = entity.DoctorId,
            
            // Complex mapping (The Adapter logic)
            // Flattening a relationship: Entity has 'Staff' object, DTO might just need the name or ID
            StaffId = entity.StaffId,
            Staff = entity.Staff?.ToDto(), // Recursive adaptation
            
            // Logic adaptation
            // Handling null propagation safely
            CreatedAt = entity.Staff == null ? entity.CreatedAt : entity.Staff.CreatedAt,
        };
    }
}
```

### **Usage Context**
*   **Repository Layer**: Returns purely `Doctor` entities.
*   **UI Layer**: Requires `DoctorDto` for binding to DataGrids (which prefer flat properties).
*   **Usage**: `var dtos = doctors.Select(d => d.ToDto()).ToList();`

### **Advantages**
1.  **Separation of Concerns**: The Database/Domain layer doesn't need to know about UI requirements (like formatting dates). The Adapter handles that translation.
2.  **Security**: Prevents sensitive domain data (like password hashes in a User entity) from accidentally leaking to the UI, as the DTO only includes safe fields.

### **Migration & Evolution**
*   **From (AutoMapper)**: Many .NET projects use libraries like AutoMapper.
    *   **The Issue**: AutoMapper relies on reflection, which can be slow and hard to debug ("Magic" mapping).
*   **To (Manual Adapter Pattern)**: 
    *   **Why?**: By writing explicit extension methods, we gained compile-time safety (if a property name changes, the code breaks immediately, not at runtime). We also gained performance by avoiding reflection. This fits the project's goal of being lightweight.

---

## 2. Decorator / Proxy Pattern (Implicit via DI)

### **Location**
*   **File**: `Hospital_management_system/Infrastructure/ServiceConfigurator.cs`
*   **Mechanism**: `Microsoft.Extensions.DependencyInjection`

### **Core Concept**
*   **Decorator**: Adds behavior to an object dynamically.
*   **Proxy**: Controls access to an object.

### **Implementation Details**
While not manually implemented as `public class LoggingRepository : IRepository`, the **Dependency Injection (DI) Container** acts as a dynamic proxy factory. It wraps the service creation and lifetime management.

#### **Code Structure**
```csharp
public static IServiceCollection ConfigureServices(this IServiceCollection services)
{
    // The DI container intercepts requests for IUnitOfWork
    // It creates the instance, manages its scope (Scoped), and injects dependencies
    services.AddScoped<IUnitOfWork, UnitOfWork>();
    
    // It effectively "decorates" the UnitOfWork with Lifetime Management behavior
    return services;
}
```

### **Usage Context**
When the `Mediator` asks for a handler, the DI container resolves it. The container ensures that within a single HTTP request (or scoped operation), the *same* instance of `UnitOfWork` is used, decorating the instance with "Scoped" behavior.

### **Advantages**
1.  **Lifetime Management**: We don't manually manage `new UnitOfWork()`. The container disposes of it automatically (calling `Dispose()`) when the scope ends.
2.  **Loose Coupling**: Consumers depend on `IUnitOfWork`, not the concrete implementation or how it's constructed.

### **Migration & Evolution**
*   **From (Tightly Coupled)**: `var repo = new DoctorRepository(new SqlConnection(...));`
*   **To (DI Container)**: `services.AddScoped<IDoctorRepository, DoctorRepository>();`
    *   **Benefit**: This allows us to inject *Decorators* later easily. For example, if we wanted to add caching, we could define `CachedDoctorRepository : IDoctorRepository` that wraps the real one, and just change one line in `ServiceConfigurator.cs`.

---

## 3. Composite Pattern (Implicit in WinForms)

### **Location**
*   **Folder**: `Hospital_management_system/Presentation/UserControls/`
*   **Files**: `DashboardControl.cs`, `DoctorsControl.cs`

### **Core Concept**
Compose objects into tree structures to represent part-whole hierarchies. Composite lets clients treat individual objects and compositions of objects uniformly.

### **Implementation Details**
Windows Forms is inherently built on the Composite pattern. A `UserControl` (Composite) contains multiple `Button`, `TextBox`, `Label` (Leafs) or other `Panel` (Composite) objects.

#### **Code Structure**
```csharp
// Implicit WinForms implementation
public partial class DashboardControl : UserControl
{
    public DashboardControl()
    {
        InitializeComponent();
        // The 'Controls' collection is the Composite list
        // We add specialized controls to this parent
        this.Controls.Add(this.panelHeader); 
        this.Controls.Add(this.dataGridView1);
    }
}
```

### **Usage Context**
The `MainForm` acts as the root. It swaps out the "Current View" by adding/removing `UserControls` from its main panel. Ideally, `MainForm` treats `DoctorsControl` and `PatientsControl` uniformly as just `Control`.

### **Advantages**
1.  **Uniformity**: The `MainForm` can call `control.Show()` or `control.Dispose()` without caring if it's a simple button or a complex Dashboard with 50 sub-components.
2.  **Recursive Rendering**: The OS renders the parent, which asks its children to render, recursively.

---
