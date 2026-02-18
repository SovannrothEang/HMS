using Hospital_management_system.Application.DTOs;

namespace Hospital_management_system.Presentation.Views;

public interface IDepartmentsView
{
    string Code { get; set; }
    string DepartmentName { get; set; }
    string Description { get; set; }
    
    void BindDepartments(IEnumerable<DepartmentDto> departments);
    void ShowError(string message);
    void ShowSuccess(string message);
    bool ConfirmAction(string message, string title);
    void DisableControls(bool disable);
}
