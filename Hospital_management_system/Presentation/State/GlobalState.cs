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

    //public static List<int> RecentDoctorIds { get; set; } = new List<int>();

    //public static void AddRecentPatient(int patientId)
    //{
    //    if (!RecentPatientIds.Contains(patientId))
    //    {
    //        RecentPatientIds.Insert(0, patientId);
    //        if (RecentPatientIds.Count > 10) // Keep only last 10
    //            RecentPatientIds.RemoveAt(RecentPatientIds.Count - 1);
    //    }
    //}

    //public static async Task LoadAsync()
    //{
    //    var result = await IServiceProvider

    //    Items = new BindingList<MyDto>(result);
    //    DataUpdated?.Invoke();
    //}
    public static void AddItems<T>(IEnumerable<T> items, BindingList<T> list)
    {
        foreach (var item in items)
        {
            list.Add(item);
        }
        DataUpdated?.Invoke();
    }
}
