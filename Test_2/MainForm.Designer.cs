
namespace Test_2
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addStudentButton = new System.Windows.Forms.ToolStripButton();
            this.studentDataGridView = new System.Windows.Forms.DataGridView();
            this.teacherDataGridView = new System.Windows.Forms.DataGridView();
            this.SName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Faculty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Scholarship = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AverageBall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseWork = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editStudentButton = new System.Windows.Forms.ToolStripButton();
            this.TName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxNumberOfCourseWorks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcademicDegree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseWorkStudents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addTeacherButton = new System.Windows.Forms.ToolStripButton();
            this.editTeacherButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teacherDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStudentButton,
            this.editStudentButton,
            this.addTeacherButton,
            this.editTeacherButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1261, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addStudentButton
            // 
            this.addStudentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addStudentButton.Image = ((System.Drawing.Image)(resources.GetObject("addStudentButton.Image")));
            this.addStudentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addStudentButton.Name = "addStudentButton";
            this.addStudentButton.Size = new System.Drawing.Size(29, 28);
            this.addStudentButton.Text = "Добавить студента";
            this.addStudentButton.Click += new System.EventHandler(this.addStudentButton_Click);
            // 
            // studentDataGridView
            // 
            this.studentDataGridView.AllowUserToAddRows = false;
            this.studentDataGridView.AllowUserToDeleteRows = false;
            this.studentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SName,
            this.SAge,
            this.SAddress,
            this.Faculty,
            this.Group,
            this.isState,
            this.Scholarship,
            this.AverageBall,
            this.CourseWork});
            this.studentDataGridView.Location = new System.Drawing.Point(26, 49);
            this.studentDataGridView.Name = "studentDataGridView";
            this.studentDataGridView.ReadOnly = true;
            this.studentDataGridView.RowHeadersWidth = 51;
            this.studentDataGridView.RowTemplate.Height = 24;
            this.studentDataGridView.Size = new System.Drawing.Size(1204, 150);
            this.studentDataGridView.TabIndex = 1;
            // 
            // teacherDataGridView
            // 
            this.teacherDataGridView.AllowUserToAddRows = false;
            this.teacherDataGridView.AllowUserToDeleteRows = false;
            this.teacherDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teacherDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TName,
            this.TAge,
            this.TAddress,
            this.Salary,
            this.MaxNumberOfCourseWorks,
            this.AcademicDegree,
            this.Title,
            this.CourseWorkStudents});
            this.teacherDataGridView.Location = new System.Drawing.Point(26, 236);
            this.teacherDataGridView.Name = "teacherDataGridView";
            this.teacherDataGridView.ReadOnly = true;
            this.teacherDataGridView.RowHeadersWidth = 51;
            this.teacherDataGridView.RowTemplate.Height = 24;
            this.teacherDataGridView.Size = new System.Drawing.Size(1204, 150);
            this.teacherDataGridView.TabIndex = 2;
            // 
            // SName
            // 
            this.SName.HeaderText = "Имя";
            this.SName.MinimumWidth = 6;
            this.SName.Name = "SName";
            this.SName.ReadOnly = true;
            this.SName.Width = 125;
            // 
            // SAge
            // 
            this.SAge.HeaderText = "Возраст";
            this.SAge.MinimumWidth = 6;
            this.SAge.Name = "SAge";
            this.SAge.ReadOnly = true;
            this.SAge.Width = 125;
            // 
            // SAddress
            // 
            this.SAddress.HeaderText = "Адрес";
            this.SAddress.MinimumWidth = 6;
            this.SAddress.Name = "SAddress";
            this.SAddress.ReadOnly = true;
            this.SAddress.Width = 125;
            // 
            // Faculty
            // 
            this.Faculty.HeaderText = "Факультет";
            this.Faculty.MinimumWidth = 6;
            this.Faculty.Name = "Faculty";
            this.Faculty.ReadOnly = true;
            this.Faculty.Width = 125;
            // 
            // Group
            // 
            this.Group.HeaderText = "Группа";
            this.Group.MinimumWidth = 6;
            this.Group.Name = "Group";
            this.Group.ReadOnly = true;
            this.Group.Width = 125;
            // 
            // isState
            // 
            this.isState.HeaderText = "Форма обучения";
            this.isState.MinimumWidth = 6;
            this.isState.Name = "isState";
            this.isState.ReadOnly = true;
            this.isState.Width = 125;
            // 
            // Scholarship
            // 
            this.Scholarship.HeaderText = "Стипендия";
            this.Scholarship.MinimumWidth = 6;
            this.Scholarship.Name = "Scholarship";
            this.Scholarship.ReadOnly = true;
            this.Scholarship.Width = 125;
            // 
            // AverageBall
            // 
            this.AverageBall.HeaderText = "Средний балл";
            this.AverageBall.MinimumWidth = 6;
            this.AverageBall.Name = "AverageBall";
            this.AverageBall.ReadOnly = true;
            this.AverageBall.Width = 125;
            // 
            // CourseWork
            // 
            this.CourseWork.HeaderText = "Курсовая работа";
            this.CourseWork.MinimumWidth = 6;
            this.CourseWork.Name = "CourseWork";
            this.CourseWork.ReadOnly = true;
            this.CourseWork.Width = 125;
            // 
            // editStudentButton
            // 
            this.editStudentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editStudentButton.Image = ((System.Drawing.Image)(resources.GetObject("editStudentButton.Image")));
            this.editStudentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editStudentButton.Name = "editStudentButton";
            this.editStudentButton.Size = new System.Drawing.Size(29, 28);
            this.editStudentButton.Text = "Редактировать студента";
            this.editStudentButton.Click += new System.EventHandler(this.editStudentButton_Click);
            // 
            // TName
            // 
            this.TName.HeaderText = "Имя";
            this.TName.MinimumWidth = 6;
            this.TName.Name = "TName";
            this.TName.ReadOnly = true;
            this.TName.Width = 125;
            // 
            // TAge
            // 
            this.TAge.HeaderText = "Возраст";
            this.TAge.MinimumWidth = 6;
            this.TAge.Name = "TAge";
            this.TAge.ReadOnly = true;
            this.TAge.Width = 125;
            // 
            // TAddress
            // 
            this.TAddress.HeaderText = "Адрес";
            this.TAddress.MinimumWidth = 6;
            this.TAddress.Name = "TAddress";
            this.TAddress.ReadOnly = true;
            this.TAddress.Width = 125;
            // 
            // Salary
            // 
            this.Salary.HeaderText = "Зарплата";
            this.Salary.MinimumWidth = 6;
            this.Salary.Name = "Salary";
            this.Salary.ReadOnly = true;
            this.Salary.Width = 125;
            // 
            // MaxNumberOfCourseWorks
            // 
            this.MaxNumberOfCourseWorks.HeaderText = "Макс. кол-во курсовых";
            this.MaxNumberOfCourseWorks.MinimumWidth = 6;
            this.MaxNumberOfCourseWorks.Name = "MaxNumberOfCourseWorks";
            this.MaxNumberOfCourseWorks.ReadOnly = true;
            this.MaxNumberOfCourseWorks.Width = 125;
            // 
            // AcademicDegree
            // 
            this.AcademicDegree.HeaderText = "Ученая степень";
            this.AcademicDegree.MinimumWidth = 6;
            this.AcademicDegree.Name = "AcademicDegree";
            this.AcademicDegree.ReadOnly = true;
            this.AcademicDegree.Width = 125;
            // 
            // Title
            // 
            this.Title.HeaderText = "Звание";
            this.Title.MinimumWidth = 6;
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 125;
            // 
            // CourseWorkStudents
            // 
            this.CourseWorkStudents.HeaderText = "Студенты-курсовики";
            this.CourseWorkStudents.MinimumWidth = 6;
            this.CourseWorkStudents.Name = "CourseWorkStudents";
            this.CourseWorkStudents.ReadOnly = true;
            this.CourseWorkStudents.Width = 125;
            // 
            // addTeacherButton
            // 
            this.addTeacherButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addTeacherButton.Image = ((System.Drawing.Image)(resources.GetObject("addTeacherButton.Image")));
            this.addTeacherButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addTeacherButton.Name = "addTeacherButton";
            this.addTeacherButton.Size = new System.Drawing.Size(29, 28);
            this.addTeacherButton.Text = "Добавить преподавателя";
            this.addTeacherButton.Click += new System.EventHandler(this.addTeacherButton_Click);
            // 
            // editTeacherButton
            // 
            this.editTeacherButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editTeacherButton.Image = ((System.Drawing.Image)(resources.GetObject("editTeacherButton.Image")));
            this.editTeacherButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editTeacherButton.Name = "editTeacherButton";
            this.editTeacherButton.Size = new System.Drawing.Size(29, 28);
            this.editTeacherButton.Text = "Редактировать преподавателя";
            this.editTeacherButton.Click += new System.EventHandler(this.editTeacherButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 551);
            this.Controls.Add(this.teacherDataGridView);
            this.Controls.Add(this.studentDataGridView);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "Люди";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teacherDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addStudentButton;
        private System.Windows.Forms.DataGridView studentDataGridView;
        private System.Windows.Forms.DataGridView teacherDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn SName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Faculty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn isState;
        private System.Windows.Forms.DataGridViewTextBoxColumn Scholarship;
        private System.Windows.Forms.DataGridViewTextBoxColumn AverageBall;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseWork;
        private System.Windows.Forms.ToolStripButton editStudentButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn TName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn TAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxNumberOfCourseWorks;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcademicDegree;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseWorkStudents;
        private System.Windows.Forms.ToolStripButton addTeacherButton;
        private System.Windows.Forms.ToolStripButton editTeacherButton;
    }
}

