using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test;
using Test_2.AddingPeople;

namespace Test_2
{
    public partial class MainForm : Form
    {
        public static PersonList personList;
        public MainForm()
        {
            InitializeComponent();
            personList = new PersonList();
        }
        private void StudentListToDataGrid()
        {
            studentDataGridView.Rows.Clear();
            int i = 0;
            foreach (Student item in personList.getList())
            {
                studentDataGridView.Rows.Add(1);
                studentDataGridView.Rows[i].Cells["SId"].Value = item.getId().ToString();
                studentDataGridView.Rows[i].Cells["SName"].Value = item.getName();
                studentDataGridView.Rows[i].Cells["SAge"].Value = item.getAge();
                studentDataGridView.Rows[i].Cells["SAddress"].Value = item.getAddress().ToString();
                studentDataGridView.Rows[i].Cells["Faculty"].Value = item.getFaculty();
                studentDataGridView.Rows[i].Cells["Group"].Value = item.getGroup();
                if (item.getIsState()) studentDataGridView.Rows[i].Cells["isState"].Value = "Бюджетная";
                else studentDataGridView.Rows[i].Cells["isState"].Value = "Контрактная";
                studentDataGridView.Rows[i].Cells["Scholarship"].Value = item.getScholarship();
                studentDataGridView.Rows[i].Cells["AverageBall"].Value = item.getAverageBall();
                if (studentDataGridView.Rows[i].Cells["CourseWork"].Value != null) studentDataGridView.Rows[i].Cells["CourseWork"].Value = item.getCourseWork().getTitle(); 
                else studentDataGridView.Rows[i].Cells["CourseWork"].Value="";
                i++;
            }
        }
        private void TeacherListToDataGrid()
        {
            teacherDataGridView.Rows.Clear();
            int i = 0;
            foreach (Teacher item in personList.getList())
            {
                teacherDataGridView.Rows.Add(1);
                teacherDataGridView.Rows[i].Cells["TId"].Value = item.getId().ToString();
                teacherDataGridView.Rows[i].Cells["TName"].Value = item.getName();
                teacherDataGridView.Rows[i].Cells["TAge"].Value = item.getAge();
                teacherDataGridView.Rows[i].Cells["TAddress"].Value = item.getAddress().ToString();
                teacherDataGridView.Rows[i].Cells["Salary"].Value = item.getSalary();
                teacherDataGridView.Rows[i].Cells["MaxNumberOfCourseWorks"].Value = item.getMaxNumberOfCourseWorks();
                foreach (var st in item.getCourseWorkStudents())
                    teacherDataGridView.Rows[i].Cells["CourseWorkStudents"].Value += item.getName() + ", ";
                teacherDataGridView.Rows[i].Cells["CourseWorkStudents"].Value = teacherDataGridView.Rows[i].Cells["CourseWorkStudents"].Value.ToString().Remove(teacherDataGridView.Rows[i].Cells["CourseWorkStudents"].Value.ToString().LastIndexOf(", "));
                teacherDataGridView.Rows[i].Cells["AcademicDegree"].Value = item.getAcademicDegreeStr();
                teacherDataGridView.Rows[i].Cells["Title"].Value = item.getTitle();
                i++;
            }
        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            StudentForm addStudentForm = new StudentForm(ref student);
            addStudentForm.ShowDialog();
            if(student.getName()!="xxx") personList.AddPerson(student);
            StudentListToDataGrid();
        }

        private void editStudentButton_Click(object sender, EventArgs e)
        {
            switch (studentDataGridView.SelectedRows.Count)
            {
                case 0:
                    {
                        if(MessageBox.Show("Не выбрано ни одной позиции. Не желаете ли создать новую?", "Предупреждение", MessageBoxButtons.OKCancel)==DialogResult.OK)
                            addStudentButton_Click(sender, e);
                        break;
                    }
                case 1:
                    {
                        Student student = (Student)personList.FindPersonByName(studentDataGridView.SelectedRows[0].Cells["SName"].Value.ToString()).getList()[0];
                        StudentForm editStudentForm = new StudentForm(ref student);
                        editStudentForm.ShowDialog();
                        StudentListToDataGrid();
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Выбрано более 1 позиции. Для редактирования выберите ОДНУ позицию.", "Ошибка");
                        break;
                    }
            }
        }
        
        private void addTeacherButton_Click(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher();
            TeacherForm addTeacherForm = new TeacherForm(ref teacher);
            addTeacherForm.ShowDialog();
            personList.AddPerson(teacher);
            TeacherListToDataGrid();
        }

        private void editTeacherButton_Click(object sender, EventArgs e)
        {
            switch (teacherDataGridView.SelectedRows.Count)
            {
                case 0:
                    {
                        if (MessageBox.Show("Не выбрано ни одной позиции. Не желаете ли создать новую?", "Предупреждение", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            addTeacherButton_Click(sender, e);
                        break;
                    }
                case 1:
                    {
                        Teacher teacher = (Teacher)personList.FindPersonByName(teacherDataGridView.SelectedRows[0].Cells["TName"].Value.ToString()).getList()[0];
                        TeacherForm editTeacherForm = new TeacherForm(ref teacher);
                        editTeacherForm.ShowDialog();
                        TeacherListToDataGrid();
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Выбрано более 1 позиции. Для редактирования выберите ОДНУ позицию.", "Ошибка");
                        break;
                    }
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Куда вы хотите экспортировать данные? Да-в текстовый файл, Нет - в XML", "ВЫберите вариант", MessageBoxButtons.YesNoCancel);
            switch (dialogResult)
            {
                case DialogResult.Yes:
                    {
                        personList.ExportInTxt();
                        break;
                    }
                case DialogResult.No:
                    {
                        personList.ExportInXml();
                        break;
                    }
                default:
                    break;
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Откуда вы хотите импортировать данные? Да-из текстового файла, Нет - из XML", "ВЫберите вариант", MessageBoxButtons.YesNoCancel);
            switch (dialogResult)
            {
                case DialogResult.Yes:
                    {
                        personList.ImportFromTxt();
                        break;
                    }
                case DialogResult.No:
                    {
                        personList.ImportFromXml();
                        break;
                    }
                default:
                    break;
            }
        }

        private void deleteStudentButton_Click(object sender, EventArgs e)
        {
            switch (studentDataGridView.SelectedRows.Count)
            {
                case 0:
                    {
                        MessageBox.Show("Не выбрано ни одной позиции для удаления!", "Ошибка");
                        break;
                    }
                case 1:
                    {
                        if (MessageBox.Show($"Вы действительно хотите удалить студента {studentDataGridView.SelectedRows[0].Cells["SName"].Value}?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            MessageBox.Show($"Студент {studentDataGridView.SelectedRows[0].Cells["SName"].Value} успешно удален.", "Успех");
                            personList.RemovePerson(int.Parse(studentDataGridView.SelectedRows[0].Cells["SId"].Value.ToString()));
                        }
                        break;
                    }
                default:
                    {
                        if (MessageBox.Show("Вы действительно хотите удалить выбранных студентов?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            MessageBox.Show($"Студент {studentDataGridView.SelectedRows[0].Cells["SName"].Value} успешно удален.", "Успех");
                            personList.RemovePerson(int.Parse(studentDataGridView.SelectedRows[0].Cells["SId"].Value.ToString()));
                        }
                        break;
                    }
            }
        }
    }
}
