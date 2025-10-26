namespace EmployeeClient
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageEmployees;
        private System.Windows.Forms.TabPage tabPageStatistics;
        private System.Windows.Forms.DataGridView dataGridViewEmployees;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ComboBox cmbPost;
        private System.Windows.Forms.TextBox txtLastNameFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Button btnResetFilter;
        private System.Windows.Forms.GroupBox groupBoxStats;
        private System.Windows.Forms.ComboBox cmbStatStatus;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.RadioButton rbEmployed;
        private System.Windows.Forms.RadioButton rbUnemployed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnShowStatistics;
        private System.Windows.Forms.DataGridView dataGridViewStats;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSettings;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageEmployees = new System.Windows.Forms.TabPage();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.btnResetFilter = new System.Windows.Forms.Button();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLastNameFilter = new System.Windows.Forms.TextBox();
            this.cmbPost = new System.Windows.Forms.ComboBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.tabPageStatistics = new System.Windows.Forms.TabPage();
            this.dataGridViewStats = new System.Windows.Forms.DataGridView();
            this.groupBoxStats = new System.Windows.Forms.GroupBox();
            this.btnShowStatistics = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rbUnemployed = new System.Windows.Forms.RadioButton();
            this.rbEmployed = new System.Windows.Forms.RadioButton();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.cmbStatStatus = new System.Windows.Forms.ComboBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            this.groupBoxFilter.SuspendLayout();
            this.tabPageStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStats)).BeginInit();
            this.groupBoxStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageEmployees);
            this.tabControl1.Controls.Add(this.tabPageStatistics);
            this.tabControl1.Location = new System.Drawing.Point(12, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(960, 608);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageEmployees
            // 
            this.tabPageEmployees.Controls.Add(this.dataGridViewEmployees);
            this.tabPageEmployees.Controls.Add(this.groupBoxFilter);
            this.tabPageEmployees.Location = new System.Drawing.Point(4, 24);
            this.tabPageEmployees.Name = "tabPageEmployees";
            this.tabPageEmployees.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEmployees.Size = new System.Drawing.Size(952, 580);
            this.tabPageEmployees.TabIndex = 0;
            this.tabPageEmployees.Text = "Список сотрудников";
            this.tabPageEmployees.UseVisualStyleBackColor = true;
            // 
            // dataGridViewEmployees
            // 
            this.dataGridViewEmployees.AllowUserToAddRows = false;
            this.dataGridViewEmployees.AllowUserToDeleteRows = false;
            this.dataGridViewEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.Location = new System.Drawing.Point(6, 120);
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.ReadOnly = true;
            this.dataGridViewEmployees.RowHeadersVisible = false;
            this.dataGridViewEmployees.Size = new System.Drawing.Size(940, 454);
            this.dataGridViewEmployees.TabIndex = 1;
            this.dataGridViewEmployees.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewEmployees_ColumnHeaderMouseClick);
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFilter.Controls.Add(this.btnResetFilter);
            this.groupBoxFilter.Controls.Add(this.btnApplyFilter);
            this.groupBoxFilter.Controls.Add(this.label4);
            this.groupBoxFilter.Controls.Add(this.label3);
            this.groupBoxFilter.Controls.Add(this.label2);
            this.groupBoxFilter.Controls.Add(this.label1);
            this.groupBoxFilter.Controls.Add(this.txtLastNameFilter);
            this.groupBoxFilter.Controls.Add(this.cmbPost);
            this.groupBoxFilter.Controls.Add(this.cmbDepartment);
            this.groupBoxFilter.Controls.Add(this.cmbStatus);
            this.groupBoxFilter.Location = new System.Drawing.Point(6, 6);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(940, 108);
            this.groupBoxFilter.TabIndex = 0;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Фильтры";
            // 
            // btnResetFilter
            // 
            this.btnResetFilter.Location = new System.Drawing.Point(859, 65);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Size = new System.Drawing.Size(75, 23);
            this.btnResetFilter.TabIndex = 9;
            this.btnResetFilter.Text = "Сброс";
            this.btnResetFilter.UseVisualStyleBackColor = true;
            this.btnResetFilter.Click += new System.EventHandler(this.btnResetFilter_Click);
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Location = new System.Drawing.Point(859, 36);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(75, 23);
            this.btnApplyFilter.TabIndex = 8;
            this.btnApplyFilter.Text = "Применить";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(597, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Фамилия (часть):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(399, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Должность:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Отдел:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Статус:";
            // 
            // txtLastNameFilter
            // 
            this.txtLastNameFilter.Location = new System.Drawing.Point(597, 40);
            this.txtLastNameFilter.Name = "txtLastNameFilter";
            this.txtLastNameFilter.Size = new System.Drawing.Size(180, 23);
            this.txtLastNameFilter.TabIndex = 3;
            // 
            // cmbPost
            // 
            this.cmbPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPost.FormattingEnabled = true;
            this.cmbPost.Location = new System.Drawing.Point(399, 40);
            this.cmbPost.Name = "cmbPost";
            this.cmbPost.Size = new System.Drawing.Size(180, 23);
            this.cmbPost.TabIndex = 2;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(201, 40);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(180, 23);
            this.cmbDepartment.TabIndex = 1;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(6, 40);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(180, 23);
            this.cmbStatus.TabIndex = 0;
            // 
            // tabPageStatistics
            // 
            this.tabPageStatistics.Controls.Add(this.dataGridViewStats);
            this.tabPageStatistics.Controls.Add(this.groupBoxStats);
            this.tabPageStatistics.Location = new System.Drawing.Point(4, 24);
            this.tabPageStatistics.Name = "tabPageStatistics";
            this.tabPageStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStatistics.Size = new System.Drawing.Size(952, 580);
            this.tabPageStatistics.TabIndex = 1;
            this.tabPageStatistics.Text = "Статистика";
            this.tabPageStatistics.UseVisualStyleBackColor = true;
            // 
            // dataGridViewStats
            // 
            this.dataGridViewStats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStats.Location = new System.Drawing.Point(6, 180);
            this.dataGridViewStats.Name = "dataGridViewStats";
            this.dataGridViewStats.ReadOnly = true;
            this.dataGridViewStats.RowHeadersVisible = false;
            this.dataGridViewStats.Size = new System.Drawing.Size(940, 394);
            this.dataGridViewStats.TabIndex = 1;
            // 
            // groupBoxStats
            // 
            this.groupBoxStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxStats.Controls.Add(this.btnShowStatistics);
            this.groupBoxStats.Controls.Add(this.label8);
            this.groupBoxStats.Controls.Add(this.label7);
            this.groupBoxStats.Controls.Add(this.label6);
            this.groupBoxStats.Controls.Add(this.label5);
            this.groupBoxStats.Controls.Add(this.rbUnemployed);
            this.groupBoxStats.Controls.Add(this.rbEmployed);
            this.groupBoxStats.Controls.Add(this.dtpEndDate);
            this.groupBoxStats.Controls.Add(this.dtpStartDate);
            this.groupBoxStats.Controls.Add(this.cmbStatStatus);
            this.groupBoxStats.Location = new System.Drawing.Point(6, 6);
            this.groupBoxStats.Name = "groupBoxStats";
            this.groupBoxStats.Size = new System.Drawing.Size(940, 168);
            this.groupBoxStats.TabIndex = 0;
            this.groupBoxStats.TabStop = false;
            this.groupBoxStats.Text = "Параметры статистики";
            // 
            // btnShowStatistics
            // 
            this.btnShowStatistics.Location = new System.Drawing.Point(859, 120);
            this.btnShowStatistics.Name = "btnShowStatistics";
            this.btnShowStatistics.Size = new System.Drawing.Size(75, 23);
            this.btnShowStatistics.TabIndex = 9;
            this.btnShowStatistics.Text = "Показать";
            this.btnShowStatistics.UseVisualStyleBackColor = true;
            this.btnShowStatistics.Click += new System.EventHandler(this.btnShowStatistics_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Тип:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(399, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Дата окончания:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(201, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Дата начала:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Статус:";
            // 
            // rbUnemployed
            // 
            this.rbUnemployed.AutoSize = true;
            this.rbUnemployed.Location = new System.Drawing.Point(100, 122);
            this.rbUnemployed.Name = "rbUnemployed";
            this.rbUnemployed.Size = new System.Drawing.Size(86, 19);
            this.rbUnemployed.TabIndex = 4;
            this.rbUnemployed.TabStop = true;
            this.rbUnemployed.Text = "Уволенные";
            this.rbUnemployed.UseVisualStyleBackColor = true;
            // 
            // rbEmployed
            // 
            this.rbEmployed.AutoSize = true;
            this.rbEmployed.Checked = true;
            this.rbEmployed.Location = new System.Drawing.Point(6, 122);
            this.rbEmployed.Name = "rbEmployed";
            this.rbEmployed.Size = new System.Drawing.Size(88, 19);
            this.rbEmployed.TabIndex = 3;
            this.rbEmployed.TabStop = true;
            this.rbEmployed.Text = "Принятые";
            this.rbEmployed.UseVisualStyleBackColor = true;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(399, 40);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(180, 23);
            this.dtpEndDate.TabIndex = 2;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(201, 40);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(180, 23);
            this.dtpStartDate.TabIndex = 1;
            // 
            // cmbStatStatus
            // 
            this.cmbStatStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatStatus.FormattingEnabled = true;
            this.cmbStatStatus.Location = new System.Drawing.Point(6, 40);
            this.cmbStatStatus.Name = "cmbStatStatus";
            this.cmbStatStatus.Size = new System.Drawing.Size(180, 23);
            this.cmbStatStatus.TabIndex = 0;
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(12, 12);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(120, 23);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.Text = "Настройки";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Учет сотрудников";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.tabPageStatistics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStats)).EndInit();
            this.groupBoxStats.ResumeLayout(false);
            this.groupBoxStats.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}