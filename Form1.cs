using System;
using System.Data;
using System.Windows.Forms;

namespace EmployeeClient
{
    public partial class Form1 : Form
    {
        private DatabaseHelper dbHelper;
        private DataTable employeesTable;

        public Form1()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComboBoxes();
                LoadEmployees();

                // Установка текущих дат для статистики
                dtpStartDate.Value = DateTime.Now.AddMonths(-1);
                dtpEndDate.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        private void LoadComboBoxes()
        {
            cmbStatus.DataSource = dbHelper.GetStatuses();
            cmbStatus.DisplayMember = "name";
            cmbStatus.ValueMember = "id";
            cmbStatus.SelectedIndex = -1;

            cmbDepartment.DataSource = dbHelper.GetDepartments();
            cmbDepartment.DisplayMember = "name";
            cmbDepartment.ValueMember = "id";
            cmbDepartment.SelectedIndex = -1;

            cmbPost.DataSource = dbHelper.GetPosts();
            cmbPost.DisplayMember = "name";
            cmbPost.ValueMember = "id";
            cmbPost.SelectedIndex = -1;

            cmbStatStatus.DataSource = dbHelper.GetStatuses();
            cmbStatStatus.DisplayMember = "name";
            cmbStatStatus.ValueMember = "id";
        }

        private void LoadEmployees()
        {
            try
            {
                int? statusId = cmbStatus.SelectedIndex > -1 ? (int?)cmbStatus.SelectedValue : null;
                int? depId = cmbDepartment.SelectedIndex > -1 ? (int?)cmbDepartment.SelectedValue : null;
                int? postId = cmbPost.SelectedIndex > -1 ? (int?)cmbPost.SelectedValue : null;
                string lastNameFilter = txtLastNameFilter.Text;

                employeesTable = dbHelper.GetEmployees(statusId, depId, postId, lastNameFilter, "last_name", "ASC");
                dataGridViewEmployees.DataSource = employeesTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки сотрудников: {ex.Message}");
            }
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbPost.SelectedIndex = -1;
            txtLastNameFilter.Text = "";
            LoadEmployees();
        }

        private void btnShowStatistics_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbStatStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите статус для статистики");
                    return;
                }

                DateTime startDate = dtpStartDate.Value;
                DateTime endDate = dtpEndDate.Value;

                if (startDate > endDate)
                {
                    MessageBox.Show("Дата начала не может быть больше даты окончания");
                    return;
                }

                string statType = rbEmployed.Checked ? "employ" : "uneploy";
                int statusId = (int)cmbStatStatus.SelectedValue;

                DataTable statsTable = dbHelper.GetStatistics(statusId, startDate, endDate, statType);
                dataGridViewStats.DataSource = statsTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки статистики: {ex.Message}");
            }
        }

        private void dataGridViewEmployees_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string sortField = dataGridViewEmployees.Columns[e.ColumnIndex].DataPropertyName;
                string sortOrder = dataGridViewEmployees.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Ascending ? "DESC" : "ASC";

                employeesTable.DefaultView.Sort = $"{sortField} {sortOrder}";
                dataGridViewEmployees.DataSource = employeesTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сортировки: {ex.Message}");
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new ConnectionSettingsForm();
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                // Перезагрузить данные при изменении подключения
                LoadComboBoxes();
                LoadEmployees();
            }
        }
        // В Form1.cs можно использовать так:
        private void LoadAllEmployees()
        {
            try
            {
                DataTable employeesTable = dbHelper.GetPersons();
                dataGridViewEmployees.DataSource = employeesTable;

                // Настройка заголовков столбцов
                if (dataGridViewEmployees.Columns.Count > 0)
                {
                    dataGridViewEmployees.Columns["first_name"].HeaderText = "Имя";
                    dataGridViewEmployees.Columns["second_name"].HeaderText = "Отчество";
                    dataGridViewEmployees.Columns["last_name"].HeaderText = "Фамилия";
                    dataGridViewEmployees.Columns["date_employ"].HeaderText = "Дата приема";
                    dataGridViewEmployees.Columns["date_uneploy"].HeaderText = "Дата увольнения";
                    dataGridViewEmployees.Columns["status_name"].HeaderText = "Статус";
                    dataGridViewEmployees.Columns["department_name"].HeaderText = "Отдел";
                    dataGridViewEmployees.Columns["position_name"].HeaderText = "Должность";
                    dataGridViewEmployees.Columns["full_name"].HeaderText = "ФИО";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки сотрудников: {ex.Message}");
            }
        }

        // Или для получения данных без привязки к GridView
        private void ProcessEmployees()
        {
            DataTable personsTable = dbHelper.GetPersons();

            foreach (DataRow row in personsTable.Rows)
            {
                string fullName = row["full_name"].ToString();
                string department = row["department_name"].ToString();
                string position = row["position_name"].ToString();

                Console.WriteLine($"{fullName} - {department} - {position}");
            }
        }
        private void btnTestGetPersons_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable persons = dbHelper.GetPersons();
                MessageBox.Show($"Загружено {persons.Rows.Count} сотрудников", "GetPersons Test");

                // Показать первые 5 записей для проверки
                string result = "Первые 5 сотрудников:\n";
                for (int i = 0; i < Math.Min(5, persons.Rows.Count); i++)
                {
                    result += $"{persons.Rows[i]["full_name"]} - {persons.Rows[i]["department_name"]}\n";
                }
                MessageBox.Show(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}