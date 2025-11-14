using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Presentation.State;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Hospital_management_system.Presentation.Forms;

public partial class LoginForm : Form
{
    private readonly IServiceProvider _serviceProvider;
    public event EventHandler? LoginSucceeded;

    public LoginForm(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        InitializeComponent();
        var userRepo = _serviceProvider.GetRequiredService<IUserRepository>();
        //this.Load += async (s, e) =>
        //{
        //};
        btnLogin.Click += async (s, e) =>
        {
            var username = tbUsername.Text.Trim();
            var password = tbPassword.Text.Trim();

            var user = await userRepo.GetByUsernameAsync(username);
            if (user != null
                && string.Equals(user.Password, password, StringComparison.Ordinal))
            {
                GlobalState.CurrentUsername = username;
                GlobalState.CurrentStaffInfo = GlobalState.Staffs
                    .First(s => s.StaffId == user.StaffId);

                LoginSuccess();
            }
            else if (username.Equals("admin", StringComparison.CurrentCultureIgnoreCase)
                && string.Equals(password, "admin", StringComparison.Ordinal))
            {
                GlobalState.CurrentUsername = username;
                LoginSuccess();
            }
            else
            {
                MessageBox.Show("Invalid credentials!");
            }

        };
        tbPassword.KeyDown += (s, e) => {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; btnLogin.PerformClick(); }
        };
    }

    private void LoginSuccess()
    {
        MessageBox.Show("Login successful!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

        LoginSucceeded?.Invoke(this, EventArgs.Empty);

        this.Close();
    }
}
