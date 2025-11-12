using Hospital_management_system.Presentation.State;

namespace Hospital_management_system.Presentation.Forms;

public partial class LoginForm : Form
{
    public event EventHandler? LoginSucceeded;

    public LoginForm()
    {
        InitializeComponent();
        btnLogin.Click += (s, e) =>
        {
            var username = tbUsername.Text.Trim();
            var password = tbPassword.Text.Trim();

            if (username.ToLower() == "admin" && password == "123123")
            {
                GlobalState.CurrentUsername = username;
                MessageBox.Show("Login successful!");

                LoginSucceeded?.Invoke(this, EventArgs.Empty);

                this.Close();
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
}
