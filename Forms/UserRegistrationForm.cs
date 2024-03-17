using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace project_dbsys32.Forms
{
    public partial class UserRegistrationForm : MetroFramework.Forms.MetroForm
    {
        string selectedRoleName;

        public UserRegistrationForm()
        {
            InitializeComponent();
            LoadRoles();
        }

        // load role
        private void LoadRoles()
        {
            string connectionString = "data source = .\\SQLEXPRESS; database = dbsys32; integrated security = True";
            string sqlQuery = "SELECT [description] FROM user_category"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        cmbRole.Items.Clear();

                        while (reader.Read())
                        {
                            string roleName = reader["description"].ToString();
                            cmbRole.Items.Add(roleName);
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        // convert role to int
        private int MapRoleToRoleId(string roleName)
        {
            switch (roleName)
            {
                case "Client":
                    return 1;
                case "Staff":
                    return 2;
                case "Administrator":
                    return 3;
                default:
                    return -1;
            }
        }

        private string GenerateUserID()
        {
            string nextUserID = "";
            string connectionString = "data source = .\\SQLEXPRESS; database = dbsys32; integrated security = True";

            string sqlQuery = "SELECT CONCAT('C-', RIGHT('000' + CAST(ISNULL(MAX(CAST(RIGHT(user_id, 3) AS INT)), 0) + 1 AS VARCHAR(3)), 3)) AS NextUserID FROM user_account";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    try
                    {
                        connection.Open();
                        nextUserID = (string)command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }

            return nextUserID;
        }

        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private bool IsUsernameExists(string username)
        {
            string connectionString = "data source = .\\SQLEXPRESS; database = dbsys32; integrated security = True";
            string sqlQuery = "SELECT COUNT(*) FROM user_account WHERE username = @username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "Empty field");
                return;
            }

            if (String.IsNullOrEmpty(txtUserPassword.Text))
            {
                errorProvider1.SetError(txtUserPassword, "Empty field");
                return;
            }

            if (String.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                errorProvider1.SetError(txtConfirmPassword, "Empty field");
                return;
            }

            selectedRoleName = cmbRole.SelectedItem?.ToString();
            int roleID = MapRoleToRoleId(selectedRoleName);

            if (cmbRole.SelectedItem == null)
            {
                errorProvider1.SetError(cmbRole, "Please select a role");
                return;
            }

            if (roleID == -1)
            {
                MessageBox.Show("Invalid role selected");
                return;
            }

            if (txtUserPassword.Text != txtConfirmPassword.Text)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtConfirmPassword, "Passwords do not match");
                return;
            }

            string username = txtUserName.Text;

            if (IsUsernameExists(username))
            {
                MessageBox.Show("Username already exists. Please choose a different username.");
                return;
            }

            string userID = GenerateUserID();

            if (string.IsNullOrEmpty(userID))
            {
                MessageBox.Show("Failed to generate User ID");
                return;
            }

            string hashedPassword = HashPassword(txtUserPassword.Text);

            string sqlQuery = "INSERT INTO user_account (user_id, role_id, username, password) VALUES (@user_id, @role_id, @username, @password)";

            using (SqlConnection connection = new SqlConnection("data source = .\\SQLEXPRESS; database = dbsys32; integrated security = True"))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    try
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@user_id", userID);
                        command.Parameters.AddWithValue("@role_id", roleID);
                        command.Parameters.AddWithValue("@username", txtUserName.Text);
                        command.Parameters.AddWithValue("@password", hashedPassword);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Account created successfully");
                        // Form1 login = new Form1();
                        // login.Show();
                        // this.Hide();

                        // Clear fields
                        txtUserName.Text = "";
                        txtUserPassword.Text = "";
                        txtConfirmPassword.Text = "";

                        // Focus
                        cmbRole.SelectedIndex = -1; 


                        txtUserName.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
    }

}

