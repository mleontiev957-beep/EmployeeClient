using System;
using System.Windows.Forms;

namespace EmployeeClient
{
    public partial class ConnectionSettingsForm : Form
    {
        public ConnectionSettingsForm()
        {
            InitializeComponent();
            LoadCurrentSettings();
        }

        private void LoadCurrentSettings()
        {
            txtConnectionString.Text = DatabaseHelper.GetConnectionString();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseHelper.SetConnectionString(txtConnectionString.Text);
                var helper = new DatabaseHelper();

                if (helper.TestConnection())
                {
                    MessageBox.Show("Подключение успешно!", "Тест подключения",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось подключиться к базе данных", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка подключения",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseHelper.SetConnectionString(txtConnectionString.Text);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
