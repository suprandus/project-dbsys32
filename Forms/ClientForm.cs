using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project_dbsys32.Forms
{
    public partial class ClientForm : MetroFramework.Forms.MetroForm
    {
        private decimal subtotal = 0;
        public ClientForm()
        {
            InitializeComponent();
        }
           
        private void ClientForm_Load(object sender, EventArgs e)
        {
            LoadServicesData();
        }

        private void LoadServicesData()
        {
            try
            {
                string connectionString = "data source = .\\SQLEXPRESS; database = dbsys32; integrated security = True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT service_name AS 'Services', price AS 'Price' FROM services";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        DataTable dataTable = new DataTable();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                        dgvServiceOption.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvServiceOption.SelectedRows.Count > 0)
            {
                string firstColumnValue = dgvServiceOption.SelectedRows[0].Cells[0].Value.ToString();
                string description;
                string imageName = GetImageNameForValue(firstColumnValue, out description);

                if (!string.IsNullOrEmpty(imageName))
                {
                    pictureBox1.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(imageName);
                }
                else
                {
                    pictureBox1.Image = null;
                }

                txtDescription.Text = description;
            }
        }

        private string GetImageNameForValue(string value, out string description)
        {
            switch (value)
            {
                case "Cut & Style":
                    description = "Transform your look with precision and style.";
                    return "cut_and_style";
                case "Dry or Wet Cut":
                    description = "Versatile cuts tailored to your preference.";
                    return "dry_wet_cut";
                case "Full Head Highlights":
                    description = "Illuminate your locks with vibrant highlights.";
                    return "full_head_highlights";
                case "Full Head Tint":
                    description = "Revitalize your color for a fresh, new look.";
                    return "full_head_tint";
                case "Gents":
                    description = "Refined grooming for the modern gentleman."; 
                    return "gents";
                default:
                    description = ""; 
                    return ""; 
            }
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtDescription_Click(object sender, EventArgs e)
        {

        }

        private void CalculateSubtotal()
        {
            subtotal = 0;

            foreach (DataGridViewRow row in dgvSelectedServices.Rows)
            {
                if (decimal.TryParse(row.Cells[1].Value?.ToString(), out decimal value))
                {
                    subtotal += value;
                }
            }

            txtSubtotal.Text = subtotal.ToString("C");
        }
        private void btnAddService_Click(object sender, EventArgs e)
        {
            if (dgvServiceOption.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvServiceOption.SelectedRows[0];

                dgvSelectedServices.Rows.Add(selectedRow.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value).ToArray());
            }
            else
            {
                MessageBox.Show("Please select a service to add.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            if (dgvSelectedServices.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this service?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    dgvSelectedServices.Rows.RemoveAt(dgvSelectedServices.SelectedRows[0].Index);
                }
            }
            else
            {
                MessageBox.Show("Please select a service to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvSelectedServices.DataSource = null;
        }

        private void dgvSelectedServices_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateSubtotal();
        }

        private void dgvSelectedServices_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateSubtotal();
        }

        private void txtPaymentAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (decimal.TryParse(txtPaymentAmount.Text, out decimal paymentAmount))
                {
                    if (paymentAmount >= subtotal)
                    {
                        decimal change = paymentAmount - subtotal;
                        txtChange.Text = change.ToString("C");
                    }
                    else
                    {
                        MessageBox.Show("Payment amount cannot be less than the subtotal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtChange.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid integer payment amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPaymentAmount.Clear();
                    txtChange.Clear();
                }
            }
        }
        

        private PrintDocument printDocument;

        private void btnPrintSummary_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to continue with this transaction?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ExecuteTransaction();
            }
        }

        private void ExecuteTransaction()
        {
            try
            {
                string currentUser = CurrentUser.Username;
                string connectionString = "data source = .\\SQLEXPRESS; database = dbsys32; integrated security = True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = @"
                INSERT INTO services_transaction (service_id, username, service_name, price)
                VALUES (@service_id, @username, @service_name, @price);
            ";

                    foreach (DataGridViewRow row in dgvSelectedServices.Rows)
                    {
                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@username", currentUser);
                            command.Parameters.AddWithValue("@service_name", row.Cells[0].Value.ToString());
                            command.Parameters.AddWithValue("@price", Convert.ToDecimal(row.Cells[1].Value));

                            string serviceIdQuery = "SELECT service_id FROM services WHERE service_name = @service_name;";

                            using (SqlCommand serviceIdCommand = new SqlCommand(serviceIdQuery, connection))
                            {
                                serviceIdCommand.Parameters.AddWithValue("@service_name", row.Cells[0].Value.ToString());
                                object result = serviceIdCommand.ExecuteScalar();

                                if (result != null && result != DBNull.Value)
                                {
                                    string serviceId = result.ToString();
                                    command.Parameters.AddWithValue("@service_id", serviceId);
                                }
                                else
                                {
                                    Console.WriteLine("No service ID found for service name: " + row.Cells[0].Value.ToString());
                                    // You may want to handle this case further, such as skipping this row or displaying an error message to the user.
                                }
                            }

                            command.ExecuteNonQuery();
                        }
                    }
                }

                // Preview transaction
                printDocument = new PrintDocument();
                printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = printDocument;
                printPreviewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            string summaryText = "Summary:\n\n";
            summaryText += "Date: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\n\n";
            summaryText += "Selected Services:\n";
            foreach (DataGridViewRow row in dgvSelectedServices.Rows)
            {
                summaryText += row.Cells[0].Value.ToString() + " - " + row.Cells[1].Value.ToString() + "\n";
            }
            summaryText += "\nSubtotal: " + txtSubtotal.Text + "\n";
            summaryText += "Payment Amount: " + txtPaymentAmount.Text + "\n";
            summaryText += "Change: " + txtChange.Text + "\n";

            Font font = new Font("Arial", 12);
            SolidBrush brush = new SolidBrush(Color.Black);

            e.Graphics.DrawString(summaryText, font, brush, new PointF(100, 100));
        }

    }
}
