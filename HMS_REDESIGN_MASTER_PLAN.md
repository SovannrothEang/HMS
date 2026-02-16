# HMS Redesign Master Plan: Total Pattern-Driven Overhaul

This document defines the transition from the current "Loose Clean Architecture" to a strictly governed, design-pattern-heavy system. We are replacing automated abstractions (EF Core) with explicit patterns (Dapper/ADO.NET) and decoupling the UI using MVP.

---

## 🏛️ Target Architecture: DDD-Infused Clean Architecture

### 1. Domain Layer (The Heart)
- **Entities**: Rich domain models with behavior (not just DTOs).
- **Value Objects**: `Email`, `PhoneNumber`, `LicenseNumber`, `Address`.
- **Repository Interfaces**: Strict, narrow interfaces.
- **Domain Events**: Internal signals for side effects (e.g., `PatientAdmittedEvent`).

### 2. Application Layer (The Orchestrator)
- **Command/Query (CQRS)**: Separating read and write operations.
- **Mediator (GoF)**: `MediatR`-style implementation to decouple UI from business logic.
- **Presenters (MVP)**: Managing UI state and logic.
- **DTOs & Mappers**: Manual mapping from Domain to Application.

### 3. Infrastructure Layer (The Implementation)
- **Dapper & ADO.NET**: Replacing EF Core for maximum performance and explicit SQL control.
- **Unit of Work (GoF)**: Centralized transaction management.
- **External Services**: Logging, Configuration, Email.

### 4. Presentation Layer (The View)
- **Passive View (MVP)**: Windows Forms will contain ZERO logic. They only display data and notify the Presenter of user actions.

---

## 🛠️ The Pattern Replacement Map (All 23 GoF Patterns)

| Category | Pattern | Application in HMS |
| :--- | :--- | :--- |
| **Creational** | **Abstract Factory** | Creating `IDbConnection` based on DB Provider (SQL Server/MySQL). |
| | **Builder** | Constructing complex `Patient` records or multi-part reports. |
| | **Factory Method** | Instantiating different `Staff` types (Doctor, Nurse, Admin). |
| | **Prototype** | Cloning complex scheduling/shift templates. |
| | **Singleton** | `AppConfig`, `LicenseManager`, and central `EventBus`. |
| **Structural** | **Adapter** | Wrapping legacy Excel/PDF export libraries. |
| | **Bridge** | Decoupling UI Rendering from UI Framework (WinForms vs future Web). |
| | **Composite** | Managing hierarchical Department/Ward structures. |
| | **Decorator** | Adding Logging/Caching to Repository methods without changing code. |
| | **Facade** | Simplifying the interaction with the entire "Pharmacy" or "Billing" subsystems. |
| | **Flyweight** | Sharing common metadata across thousands of `MedicalRecord` entries. |
| | **Proxy** | Controlling access to sensitive Patient Data (Audit/Security Proxy). |
| **Behavioral** | **Chain of Resp.** | Multi-stage Approval Workflows (e.g., Surgery clearance). |
| | **Command** | Encapsulating every UI button click as a testable object. |
| | **Interpreter** | Parsing complex medical search queries or formula-based billing. |
| | **Iterator** | Navigating through large sets of `AuditLogs` or `PatientRecords`. |
| | **Mediator** | Coordinating communication between UserControls via a central hub. |
| | **Memento** | "Draft" states for complex patient admission forms (Undo/Redo). |
| | **Observer** | UI Controls updating automatically when `GlobalState` changes. |
| | **State** | Managing `PatientStatus` (Admitted -> UnderTreatment -> Discharged). |
| | **Strategy** | Swappable Calculation Logic (Salary, Insurance, Tax). |
| | **Template Method**| Standardized CRUD lifecycle (Load -> Validate -> Save). |
| | **Visitor** | Generating different report types (CSV, XML, JSON) from Domain Objects. |

---

## 💾 Data Access Overhaul (EF Core ➡️ Dapper)

### The New Stack
1. **Dapper Context**: A lightweight wrapper around `SqlConnection`.
2. **Explicit Repositories**:
   ```csharp
   public async Task<Doctor> GetByIdAsync(string id) {
       using var conn = _db.CreateConnection();
       return await conn.QuerySingleAsync<Doctor>("SELECT * FROM Doctors WHERE Id = @Id", new { Id = id });
   }
   ```
3. **Unit of Work**:
   ```csharp
   using (var uow = _uowFactory.Create()) {
       await uow.Staff.UpdateAsync(staff);
       await uow.Doctors.UpdateAsync(doctor);
       uow.Commit();
   }
   ```

---

## 🖥️ UI Refactor: Code-Behind ➡️ MVP

### Current (Bad)
- `DoctorsControl.cs` handles Button clicks, validates input, calls DB, and formats grid.

### Future (Target)
- **View (`IDoctorView`)**: Interface defining UI properties (`string LicenseNo`, `event Action SaveClicked`).
- **Presenter (`DoctorPresenter`)**: Handles `SaveClicked`, calls Application Service, tells View to show "Success".
- **View Implementation (`DoctorsControl.cs`)**: Just implements the interface and wires up WinForms controls.

---

## 🚀 Execution Strategy

1. **Phase 1: Foundation**: Create `Infrastructure.Dapper` and `Application.Core` (Mediator/Command).
2. **Phase 2: Domain Hardening**: Convert Entities to rich models, add Value Objects.
3. **Phase 3: Repository Migration**: Implement Dapper Repositories one-by-one, replacing EF calls.
4. **Phase 4: Presentation Decoupling**: Extract logic into Presenters, starting with `MainForm`.
5. **Phase 5: State Migration**: Replace `GlobalState.cs` with an `AppStateStore` using the Observer pattern.

**NO MORE STATIC STATE. NO MORE EF TRACKING. TOTAL CONTROL.**
