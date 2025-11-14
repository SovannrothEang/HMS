using Hospital_management_system.Application.DTOs;
using Hospital_management_system.Domain.Entities;
using System.ComponentModel;

namespace Hospital_management_system.Presentation.State;

public static class GlobalState
{
    public static string CurrentUsername { get; set; } = null!;
    public static StaffDto CurrentStaffInfo { get; set; } = null!;

    // Events
    public static event Action DataUpdated = null!;

    // Recently accessed records
    public static BindingList<DepartmentDto> Departments { get; set; } = [];
    public static BindingList<DoctorDto> Doctors { get; set; } = [];
    public static BindingList<PatientDto> Patients { get; set; } = [];
    public static BindingList<StaffDto> Staffs { get; set; } = [];

    public static BindingList<UserDto> Users { get; set; } = [];

    public static void AddItems<T>(IEnumerable<T> items, BindingList<T> list)
    where T : BaseDtoEntity
    {
        var newItems = items.OrderBy(x => x.Code).ToList();
        foreach (var item in newItems)
        {
            list.Add(item);
        }
        DataUpdated?.Invoke();
    }
}
