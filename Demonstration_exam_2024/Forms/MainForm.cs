using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Demonstration_exam_2024.Utils;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Demonstration_exam_2024.Forms
{
    public partial class MainForm : Form
    {
        private readonly DatabaseContext db;
        private readonly Timer timer;
        private readonly int userId;
        private DataTable partnersTable;

        public MainForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            db = new DatabaseContext();

            timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            this.Load += MainForm_Load;
            this.FormClosing += MainForm_FormClosing;

            SetupForm();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer?.Stop();
            timer?.Dispose();
            db?.Dispose();
        }

        private void SetupForm()
        {
            try
            {
                Text = "Partner Management System";
                BackColor = ColorTranslator.FromHtml("#F4E8D3");
                MinimumSize = new Size(816, 489);

                SetupDataGridView();
                ConfigureButtons();
                LoadData();
                UpdateDateTime();
                UpdateUserInfo();
            }
            catch (Exception ex)
            {
                ShowError("Initialization Error", ex);
            }
        }

        private void SetupDataGridView()
        {
            dgvPartners.AutoGenerateColumns = false;
            dgvPartners.Columns.Clear();

            dgvPartners.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "PartnerId",
                    HeaderText = "ID",
                    DataPropertyName = "PartnerId",
                    Visible = false
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "CompanyName",
                    HeaderText = "Company Name",
                    DataPropertyName = "CompanyName",
                    Width = 200
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "CompanyType",
                    HeaderText = "Type",
                    DataPropertyName = "CompanyType",
                    Width = 80
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "DirectorName",
                    HeaderText = "Director",
                    DataPropertyName = "DirectorName",
                    Width = 150
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Phone",
                    HeaderText = "Phone",
                    DataPropertyName = "Phone",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Rating",
                    HeaderText = "Rating",
                    DataPropertyName = "Rating",
                    Width = 60
                }
            });

            dgvPartners.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPartners.MultiSelect = false;
            dgvPartners.ReadOnly = true;
            dgvPartners.AllowUserToAddRows = false;
            dgvPartners.AllowUserToDeleteRows = false;
            dgvPartners.AllowUserToOrderColumns = true;
            dgvPartners.SelectionChanged += dgvPartners_SelectionChanged;
        }

        private void ConfigureButtons()
        {
            foreach (Button button in new[] { btnAdd, btnEdit, btnDelete })
            {
                button.BackColor = ColorTranslator.FromHtml("#67BA80");
                button.ForeColor = Color.White;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
            }

            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            txtSearch.TextChanged += txtSearch_TextChanged;

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void LoadData(string searchText = "")
        {
            try
            {
                string query = "SELECT * FROM Partners WHERE 1=1";
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    query += @" AND (
                        CompanyName LIKE @Search OR 
                        CompanyType LIKE @Search OR 
                        DirectorName LIKE @Search OR 
                        Phone LIKE @Search OR 
                        Email LIKE @Search OR 
                        Address LIKE @Search OR 
                        INN LIKE @Search
                    )";
                }

                SqlParameter[] parameters = null;
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    parameters = new[] { new SqlParameter("@Search", $"%{searchText}%") };
                }

                partnersTable = db.ExecuteQuery(query, parameters);
                dgvPartners.DataSource = partnersTable;

                UpdateStatus($"Found {partnersTable.Rows.Count} partners");
            }
            catch (Exception ex)
            {
                ShowError("Data Loading Error", ex);
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (IsHandleCreated)
            {
                Invoke(new Action(UpdateDateTime));
            }
        }

        private void UpdateDateTime()
        {
            lblDateTime.Text = $"Current Date and Time (UTC - YYYY-MM-DD HH:MM:SS formatted): {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}";
        }

        private void UpdateUserInfo()
        {
            try
            {
                string query = "SELECT Login FROM Users WHERE UserId = @UserId";
                var parameter = new SqlParameter("@UserId", userId);

                var result = db.ExecuteScalar(query, new[] { parameter });
                if (result != null)
                {
                    lblUserLogin.Text = $"Current User's Login: {result}";
                }
            }
            catch (Exception ex)
            {
                ShowError("User Info Error", ex);
            }
        }

        private void UpdateStatus(string message)
        {
            lblStatus.Text = message;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new EditPartnerForm(null))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData(txtSearch.Text);
                        UpdateStatus("Partner added successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Add Partner Error", ex);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPartners.CurrentRow?.DataBoundItem is DataRowView rowView)
                {
                    int partnerId = Convert.ToInt32(rowView["PartnerId"]);
                    using (var form = new EditPartnerForm(partnerId))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            LoadData(txtSearch.Text);
                            UpdateStatus("Partner updated successfully");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Edit Partner Error", ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPartners.CurrentRow?.DataBoundItem is DataRowView rowView)
                {
                    if (MessageBox.Show(
                        "Are you sure you want to delete this partner?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int partnerId = Convert.ToInt32(rowView["PartnerId"]);
                        string query = "DELETE FROM Partners WHERE PartnerId = @PartnerId";
                        var parameter = new SqlParameter("@PartnerId", partnerId);

                        db.ExecuteNonQuery(query, new[] { parameter });
                        LoadData(txtSearch.Text);
                        UpdateStatus("Partner deleted successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Delete Partner Error", ex);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }

        private void dgvPartners_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dgvPartners.SelectedRows.Count > 0;
            btnEdit.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
        }

        private void ShowError(string title, Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            UpdateStatus($"Error: {ex.Message}");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            timer?.Stop();
            timer?.Dispose();
            db?.Dispose();
        }
    }
}