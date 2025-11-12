using Hospital_management_system.Application.DTOs;
using System.ComponentModel;

namespace Hospital_management_system.Presentation.State;

public static class GlobalState
{
    //public static int CurrentStaffs { get; set; }
    //public static int CurrentDoctors { get; set; }
    //public static int CurrentPatients { get; set; }

    // Events
    public static event Action DataUpdated = null!;

    // Recently accessed records
    public static BindingList<DepartmentDto> Departments { get; set; } = [];
    public static BindingList<DoctorDto> Doctors { get; set; } = [];
    public static BindingList<PatientDto> Patients { get; set; } = [];
    public static BindingList<StaffDto> Staffs { get; set; } = [];

    public static BindingList<string> AllStaffDoctorsCodeList { get; set; } = [];
    public static BindingList<string> DoctorsCodeList { get; set; } = [];

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
