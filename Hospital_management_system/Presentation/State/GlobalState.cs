using Hospital_management_system.Application.DTO;
using System.ComponentModel;

namespace Hospital_management_system.Presentation.State;

public static class GlobalState
{
    public static int CurrentUserId { get; set; }
    public static string CurrentUserName { get; set; } = string.Empty;
    public static string CurrentUserRole { get; set; } = string.Empty;
    public static DateTime LastLoginTime { get; set; }
    public static bool IsUserLoggedIn { get; set; } = false;


    // Recently accessed records
    public static BindingList<DepartmentDto> Departments { get; set; } = [];
    public static BindingList<StaffDto> Staffs { get; set; } = [];

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
}
