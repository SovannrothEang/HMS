# Agent Guidelines - HMS Project

This document provides essential information for agentic coding agents working on the Hospital Management System (HMS).

## 🛠 Build and Development

### Core Commands
- **Build Solution**: `dotnet build HMS.sln`
- **Run Application**: `dotnet run --project Hospital_management_system/Hospital_management_system.csproj`
- **Clean Solution**: `dotnet clean`
- **Restore Dependencies**: `dotnet restore`

### Linting and Formatting
- **Format Code**: `dotnet format`
- **Run Analyzers**: `dotnet build /p:RunAnalyzers=true`
- **Check Style**: Adhere to the `.editorconfig` settings in the root directory.

### Testing
*Note: Currently, there is no dedicated test project. When adding tests, follow these conventions:*
- **Run All Tests**: `dotnet test`
- **Run Single Test**: `dotnet test --filter FullyQualifiedName~MyTestName`
- **Framework**: Prefer xUnit for new test projects.

---

## 📝 Code Style and Conventions

### General Principles
- **Clean Architecture**: Strictly follow the 4-layer separation:
  - `Domain`: Entities, Repository Interfaces, Value Objects.
  - `Application`: DTOs, Mappers, Business Logic.
  - `Infrastructure`: DbContext, Repository Implementations, Service Config.
  - `Presentation`: WinForms Controls, State Management.
- **File-scoped Namespaces**: Use `namespace Name.Space;` instead of block-scoped namespaces.
- **Async First**: Use asynchronous methods (`Task`, `async/await`) for all I/O operations, especially database calls via EF Core.

### Naming Conventions
- **Classes/Structs/Interfaces**: `PascalCase`.
- **Interfaces**: Must start with `I` (e.g., `IRepository`).
- **Methods/Properties**: `PascalCase`.
- **Private Fields**: `_camelCase` (e.g., `_staffRepository`).
- **Local Variables/Parameters**: `camelCase`.
- **Enums**: `PascalCase` for both type and members.

### Formatting
- **Indentation**: 4 spaces (no tabs).
- **Braces**: Allman style (braces on new lines).
- **Regions**: Organize class members using regions:
  ```csharp
  #region - Field
  private readonly IStaffRepository _repo;
  #endregion

  #region + Property
  public string Code { get; set; }
  #endregion
  ```

### Error Handling
- **Result Pattern**: Prefer returning a `Result<T>` or similar structure for service/logic methods instead of throwing exceptions for expected failures.
- **Global Catch**: Use `try-catch` blocks in `Program.cs` or top-level UI events to handle unexpected crashes gracefully.
- **Validation**: Implement validation in Domain entities or via dedicated validators in the Application layer.

### Database (EF Core)
- **Entities**: Inherit from `BaseEntity` to ensure consistency in `Code`, `IsActive`, `IsDeleted`, and timestamps.
- **Soft Delete**: Use the `IsDeleted` flag instead of hard-deleting records.
- **Mappers**: Use manual extension method mappers (e.g., `ToDto()`) located in `Application/Mapper`.

---

## 📂 Project Structure

- **Hospital_management_system/**: Root project directory.
  - **Domain/**: Core entities and repository interfaces. No dependencies on other layers.
  - **Application/**: Data Transfer Objects (DTOs), manual mappers, and business logic interfaces.
  - **Infrastructure/**: EF Core DbContext, repository implementations, and external service configurations.
    - `Persistence/AppDbContext.cs`: Database configuration and entity mapping.
    - `Persistence/Repositories/`: Concrete repository implementations.
    - `ServiceConfigurator.cs`: Dependency Injection (DI) registration.
  - **Presentation/**: Windows Forms controls, main form, and UI state management.
    - `Controls/`: Custom user controls (e.g., `DoctorsControl`, `StaffsControl`).
    - `Forms/`: Additional dialogs and forms.
    - `State/GlobalState.cs`: Current (legacy) static state management.

---

## 🛠 Tech Stack Details

- **Framework**: .NET 8.0 Windows (WinForms).
- **ORM**: Entity Framework Core 8.0.21.
- **Database**: SQL Server.
- **DI Container**: Microsoft.Extensions.DependencyInjection.

## 📌 Critical Constraints & Warnings

1. **Static State**: Be extremely careful when modifying `GlobalState.cs`. It is heavily used across the application and lacks thread-safety.
2. **Performance**: Avoid O(n) lookups in UI event handlers (like `CellFormatting`). Use dictionaries for O(1) lookups instead.
3. **Timezone**: Use `UTC+7` for all business date/time logic unless specified otherwise.
4. **Manual Mapping**: Do NOT introduce AutoMapper. Use the existing extension methods in `Application/Mapper`.
5. **BaseEntity Compliance**: All new domain entities MUST inherit from `BaseEntity`.

---

## 🤖 AI Agent Instructions

- **Context Awareness**: Always read the `HMS_ANALYSIS_AND_SUGGESTIONS.md` file for deep architectural insights and identified performance bottlenecks.
- **Dependency Management**: Ensure NuGet packages match the target framework (.NET 8.0). Avoid mixing version 10.x packages.
- **Cursor/Copilot Rules**: None found in `.cursor/rules/`, `.cursorrules`, or `.github/copilot-instructions.md`.

