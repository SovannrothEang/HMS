//using System.Configuration;

//namespace Hospital_management_system.Presentation.State;

//public static class ConfigurationState
//{
//    public static void SaveWindowPosition(Form form)
//    {
//        Properties.Settings.Default.WindowPositionX = form.Location.X;
//        Properties.Settings.Default.WindowPositionY = form.Location.Y;
//        Properties.Settings.Default.WindowWidth = form.Width;
//        Properties.Settings.Default.WindowHeight = form.Height;
//        Properties.Settings.Default.Save();
//    }

//    public static void LoadWindowPosition(Form form)
//    {
//        if (Properties.Settings.Default.WindowPositionX != 0)
//        {
//            form.Location = new Point(
//                Properties.Settings.Default.WindowPositionX,
//                Properties.Settings.Default.WindowPositionY
//            );
//        }

//        if (Properties.Settings.Default.WindowWidth > 0)
//        {
//            form.Size = new Size(
//                Properties.Settings.Default.WindowWidth,
//                Properties.Settings.Default.WindowHeight
//            );
//        }
//    }

//    public static void SaveLastPatientId(int patientId)
//    {
//        Properties.Settings.Default.LastSelectedPatientId = patientId;
//        Properties.Settings.Default.Save();
//    }

//    public static int GetLastPatientId()
//    {
//        return Properties.Settings.Default.LastSelectedPatientId;
//    }
//}
