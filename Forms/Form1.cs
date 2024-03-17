using project_dbsys32.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_dbsys32
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // functions
        private void OpenRegistrationForm()
        {
            using (var registrationForm = new UserRegistrationForm())
            {
                this.Hide();
                _ = registrationForm.ShowDialog();
                this.Show();
            }
        }

        // buttons
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            OpenRegistrationForm();
        }

        private void chkShowPassword_CheckedChanged_1(object sender, EventArgs e)
        {
            txtPassword.Enabled = chkShowPassword.Checked;
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '●';
        }

        // HashPassword
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Please enter your username.");
                return;
            }

            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter your password.");
                return;
            }

            string username = txtUsername.Text;
            string password = HashPassword(txtPassword.Text);

            // Query to retrieve role_id along with the user details
            string sqlQuery = "SELECT role_id FROM user_account WHERE username = @username AND password = @password";
            CurrentUser.Username = username;
            using (SqlConnection connection = new SqlConnection("data source = .\\SQLEXPRESS; database = dbsys32; integrated security = True"))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    try
                    {
                        connection.Open();
                        object roleIdObject = command.ExecuteScalar();

                        if (roleIdObject != null && roleIdObject != DBNull.Value)
                        {
                            int roleId = Convert.ToInt32(roleIdObject);

                            switch (roleId)
                            {
                                case 1:
                                    using (var clientForm = new ClientForm())
                                    {
                                        MessageBox.Show("Login successful! Opening client form...");
                                        this.Hide();
                                        _ = clientForm.ShowDialog();
                                        this.Show();
                                    }
                                    break;
                                case 2:
                                    using (var staffForm = new StaffForm())
                                    {
                                        MessageBox.Show("Login successful! Opening staff form...");
                                        this.Hide();
                                        _ = staffForm.ShowDialog();
                                        this.Show();
                                    }
                                    break;
                                case 3:
                                    using (var adminForm = new AdminForm())
                                    {
                                        MessageBox.Show("Login successful! Opening admin form...");
                                        this.Hide();
                                        _ = adminForm.ShowDialog();
                                        this.Show();
                                    }
                                    break;
                                default:
                                    MessageBox.Show("Invalid role.");
                                    break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password. Please try again.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }
    }
}
