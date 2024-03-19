namespace project_dbsys32.Forms
{
    partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvServiceOption = new System.Windows.Forms.DataGridView();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtDescription = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvSelectedServices = new System.Windows.Forms.DataGridView();
            this.Services = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnAddService = new MetroFramework.Controls.MetroButton();
            this.btnDeleteService = new MetroFramework.Controls.MetroButton();
            this.btnRefresh = new MetroFramework.Controls.MetroButton();
            this.btnPrintSummary = new MetroFramework.Controls.MetroButton();
            this.txtSubtotal = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtPaymentAmount = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtChange = new MetroFramework.Controls.MetroTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceOption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedServices)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvServiceOption
            // 
            this.dgvServiceOption.AllowUserToAddRows = false;
            this.dgvServiceOption.AllowUserToDeleteRows = false;
            this.dgvServiceOption.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServiceOption.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServiceOption.Location = new System.Drawing.Point(23, 43);
            this.dgvServiceOption.Name = "dgvServiceOption";
            this.dgvServiceOption.ReadOnly = true;
            this.dgvServiceOption.Size = new System.Drawing.Size(375, 132);
            this.dgvServiceOption.TabIndex = 0;
            this.dgvServiceOption.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgvServiceOption.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 21);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(94, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Select Services";
            this.metroLabel1.Click += new System.EventHandler(this.metroLabel1_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.AutoSize = true;
            this.txtDescription.Location = new System.Drawing.Point(424, 276);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(74, 19);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.Text = "Description";
            this.txtDescription.Click += new System.EventHandler(this.txtDescription_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::project_dbsys32.Properties.Resources.full_head_tint;
            this.pictureBox1.Location = new System.Drawing.Point(424, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(335, 210);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // dgvSelectedServices
            // 
            this.dgvSelectedServices.AllowUserToAddRows = false;
            this.dgvSelectedServices.AllowUserToDeleteRows = false;
            this.dgvSelectedServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSelectedServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Services,
            this.Price});
            this.dgvSelectedServices.Location = new System.Drawing.Point(23, 200);
            this.dgvSelectedServices.Name = "dgvSelectedServices";
            this.dgvSelectedServices.ReadOnly = true;
            this.dgvSelectedServices.Size = new System.Drawing.Size(375, 132);
            this.dgvSelectedServices.TabIndex = 4;
            this.dgvSelectedServices.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvSelectedServices_RowsAdded);
            this.dgvSelectedServices.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvSelectedServices_RowsRemoved);
            // 
            // Services
            // 
            this.Services.HeaderText = "Services";
            this.Services.Name = "Services";
            this.Services.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 178);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(109, 19);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Selected Services";
            // 
            // btnAddService
            // 
            this.btnAddService.Location = new System.Drawing.Point(24, 338);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(89, 23);
            this.btnAddService.TabIndex = 6;
            this.btnAddService.Text = "Add Service";
            this.btnAddService.UseSelectable = true;
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // btnDeleteService
            // 
            this.btnDeleteService.Location = new System.Drawing.Point(119, 338);
            this.btnDeleteService.Name = "btnDeleteService";
            this.btnDeleteService.Size = new System.Drawing.Size(89, 23);
            this.btnDeleteService.TabIndex = 7;
            this.btnDeleteService.Text = "Delete Service";
            this.btnDeleteService.UseSelectable = true;
            this.btnDeleteService.Click += new System.EventHandler(this.btnDeleteService_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(214, 338);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(89, 23);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseSelectable = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPrintSummary
            // 
            this.btnPrintSummary.Location = new System.Drawing.Point(309, 338);
            this.btnPrintSummary.Name = "btnPrintSummary";
            this.btnPrintSummary.Size = new System.Drawing.Size(89, 23);
            this.btnPrintSummary.TabIndex = 9;
            this.btnPrintSummary.Text = "Print Summary";
            this.btnPrintSummary.UseSelectable = true;
            this.btnPrintSummary.Click += new System.EventHandler(this.btnPrintSummary_Click);
            // 
            // txtSubtotal
            // 
            // 
            // 
            // 
            this.txtSubtotal.CustomButton.Image = null;
            this.txtSubtotal.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.txtSubtotal.CustomButton.Name = "";
            this.txtSubtotal.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSubtotal.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSubtotal.CustomButton.TabIndex = 1;
            this.txtSubtotal.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSubtotal.CustomButton.UseSelectable = true;
            this.txtSubtotal.CustomButton.Visible = false;
            this.txtSubtotal.Enabled = false;
            this.txtSubtotal.Lines = new string[0];
            this.txtSubtotal.Location = new System.Drawing.Point(487, 312);
            this.txtSubtotal.MaxLength = 32767;
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.PasswordChar = '\0';
            this.txtSubtotal.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSubtotal.SelectedText = "";
            this.txtSubtotal.SelectionLength = 0;
            this.txtSubtotal.SelectionStart = 0;
            this.txtSubtotal.ShortcutsEnabled = true;
            this.txtSubtotal.Size = new System.Drawing.Size(75, 23);
            this.txtSubtotal.TabIndex = 10;
            this.txtSubtotal.UseSelectable = true;
            this.txtSubtotal.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSubtotal.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(424, 312);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(57, 19);
            this.metroLabel3.TabIndex = 11;
            this.metroLabel3.Text = "Subtotal";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(568, 312);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(110, 19);
            this.metroLabel4.TabIndex = 13;
            this.metroLabel4.Text = "Payment Amount";
            // 
            // txtPaymentAmount
            // 
            // 
            // 
            // 
            this.txtPaymentAmount.CustomButton.Image = null;
            this.txtPaymentAmount.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.txtPaymentAmount.CustomButton.Name = "";
            this.txtPaymentAmount.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPaymentAmount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPaymentAmount.CustomButton.TabIndex = 1;
            this.txtPaymentAmount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPaymentAmount.CustomButton.UseSelectable = true;
            this.txtPaymentAmount.CustomButton.Visible = false;
            this.txtPaymentAmount.Lines = new string[0];
            this.txtPaymentAmount.Location = new System.Drawing.Point(684, 312);
            this.txtPaymentAmount.MaxLength = 32767;
            this.txtPaymentAmount.Name = "txtPaymentAmount";
            this.txtPaymentAmount.PasswordChar = '\0';
            this.txtPaymentAmount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPaymentAmount.SelectedText = "";
            this.txtPaymentAmount.SelectionLength = 0;
            this.txtPaymentAmount.SelectionStart = 0;
            this.txtPaymentAmount.ShortcutsEnabled = true;
            this.txtPaymentAmount.Size = new System.Drawing.Size(75, 23);
            this.txtPaymentAmount.TabIndex = 12;
            this.txtPaymentAmount.UseSelectable = true;
            this.txtPaymentAmount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPaymentAmount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPaymentAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPaymentAmount_KeyPress);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(424, 343);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(54, 19);
            this.metroLabel5.TabIndex = 15;
            this.metroLabel5.Text = "Change";
            // 
            // txtChange
            // 
            // 
            // 
            // 
            this.txtChange.CustomButton.Image = null;
            this.txtChange.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.txtChange.CustomButton.Name = "";
            this.txtChange.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtChange.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtChange.CustomButton.TabIndex = 1;
            this.txtChange.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtChange.CustomButton.UseSelectable = true;
            this.txtChange.CustomButton.Visible = false;
            this.txtChange.Enabled = false;
            this.txtChange.Lines = new string[0];
            this.txtChange.Location = new System.Drawing.Point(487, 341);
            this.txtChange.MaxLength = 32767;
            this.txtChange.Name = "txtChange";
            this.txtChange.PasswordChar = '\0';
            this.txtChange.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtChange.SelectedText = "";
            this.txtChange.SelectionLength = 0;
            this.txtChange.SelectionStart = 0;
            this.txtChange.ShortcutsEnabled = true;
            this.txtChange.Size = new System.Drawing.Size(75, 23);
            this.txtChange.TabIndex = 14;
            this.txtChange.UseSelectable = true;
            this.txtChange.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtChange.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 413);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.txtChange);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.txtPaymentAmount);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.btnPrintSummary);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDeleteService);
            this.Controls.Add(this.btnAddService);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.dgvSelectedServices);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.dgvServiceOption);
            this.Name = "ClientForm";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceOption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvServiceOption;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel txtDescription;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvSelectedServices;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btnAddService;
        private MetroFramework.Controls.MetroButton btnDeleteService;
        private MetroFramework.Controls.MetroButton btnRefresh;
        private MetroFramework.Controls.MetroButton btnPrintSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Services;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private MetroFramework.Controls.MetroTextBox txtSubtotal;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtPaymentAmount;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox txtChange;
    }
}