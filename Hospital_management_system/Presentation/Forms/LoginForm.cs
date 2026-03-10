using Hospital_management_system.Application.Mapper;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Presentation.State;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;

namespace Hospital_management_system.Presentation.Forms;

public partial class LoginForm : Form
{
    private readonly IServiceProvider _serviceProvider;
    public event EventHandler? LoginSucceeded;

    // For dragging the borderless form
    public const int WM_NCLBUTTONDOWN = 0xA1;
    public const int HT_CAPTION = 0x2;

    [DllImportAttribute("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    [DllImportAttribute("user32.dll")]
    public static extern bool ReleaseCapture();

    public LoginForm(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        InitializeComponent();
        
        var userRepo = _serviceProvider.GetRequiredService<IUserRepository>();

        #region Events
        btnLogin.Click += async (s, e) =>
        {
            var username = tbUsername.Text.Trim();
            var password = tbPassword.Text.Trim();

            var user = await userRepo.GetByUsernameAsync(username);
            if (user != null && string.Equals(user.Password, password, StringComparison.Ordinal))
            {
                GlobalState.CurrentUsername = user.Username;
                GlobalState.CurrentStaffInfo = user.Staff?.ToDto();
                LoginSucceeded?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        };

        cbShowPassword.CheckedChanged += (s, e) =>
        {
            tbPassword.PasswordChar = cbShowPassword.Checked ? '\0' : '•';
        };

        // Enable form dragging since it is borderless
        pnlLeft.MouseDown += Form_MouseDown;
        pnlRight.MouseDown += Form_MouseDown;
        pictureBox1.MouseDown += Form_MouseDown;
        lblTitleLeft.MouseDown += Form_MouseDown;
        #endregion
    }

    private void Form_MouseDown(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
    }

    private void BtnExit_Click(object? sender, EventArgs e)
    {
        System.Windows.Forms.Application.Exit();
    }
}
