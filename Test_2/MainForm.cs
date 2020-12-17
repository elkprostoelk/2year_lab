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
            foreach (Person item in personList.getList())
            {
                if (item.GetTypeName() == "Student")
                {
                    var item1=(Student)item;
                    studentDataGridView.Rows.Add(1);
                    studentDataGridView.Rows[i].Cells["SId"].Value = item1.getId().ToString();
                    studentDataGridView.Rows[i].Cells["SName"].Value = item1.getName();
                    studentDataGridView.Rows[i].Cells["SAge"].Value = item1.getAge();
                    studentDataGridView.Rows[i].Cells["SAddress"].Value = item1.getAddress().ToString();
                    studentDataGridView.Rows[i].Cells["Faculty"].Value = item1.getFaculty();
                    studentDataGridView.Rows[i].Cells["Group"].Value = item1.getGroup();
                    if (item1.getIsState()) studentDataGridView.Rows[i].Cells["isState"].Value = "Бюджетная";
                    else studentDataGridView.Rows[i].Cells["isState"].Value = "Контрактная";
                    studentDataGridView.Rows[i].Cells["Scholarship"].Value = item1.getScholarship();
                    studentDataGridView.Rows[i].Cells["AverageBall"].Value = item1.getAverageBall();
                    if (item1.getCourseWork() != null)
                    {
                        studentDataGridView.Rows[i].Cells["CourseWorkTitle"].Value = item1.getCourseWork().getTitle();
                        studentDataGridView.Rows[i].Cells["CourseWorkDescription"].Value = item1.getCourseWork().getDescription();
                    }
                    else studentDataGridView.Rows[i].Cells["CourseWorkTitle"].Value = "";
                    i++;
                }
            }
        }
        private void TeacherListToDataGrid()
        {
            teacherDataGridView.Rows.Clear();
            int i = 0;
            foreach (Person item in personList.getList())
            {
                if (item.GetTypeName() == "Teacher")
                {
                    var item1 = (Teacher)item;
                    teacherDataGridView.Rows.Add(1);
                    teacherDataGridView.Rows[i].Cells["TId"].Value = item1.getId().ToString();
                    teacherDataGridView.Rows[i].Cells["TName"].Value = item1.getName();
                    teacherDataGridView.Rows[i].Cells["TAge"].Value = item1.getAge();
                    teacherDataGridView.Rows[i].Cells["TAddress"].Value = item1.getAddress().ToString();
                    teacherDataGridView.Rows[i].Cells["Salary"].Value = item1.getSalary();
                    teacherDataGridView.Rows[i].Cells["MaxNumberOfCourseWorks"].Value = item1.getMaxNumberOfCourseWorks();
                    foreach (var st in item1.getCourseWorkStudents())
                        teacherDataGridView.Rows[i].Cells["CourseWorkStudents"].Value += st.getName() + ", ";
                    teacherDataGridView.Rows[i].Cells["AcademicDegree"].Value = item1.getAcademicDegreeStr();
                    teacherDataGridView.Rows[i].Cells["Title"].Value = item1.getTitleStr();
                    i++;
                }
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
                        personList.RecountIds();
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
                        personList.RecountIds();
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
                        MessageBox.Show("Готово!");
                        break;
                    }
                case DialogResult.No:
                    {
                        personList.ExportInXml();
                        MessageBox.Show("Готово!");
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
                        StudentListToDataGrid();
                        TeacherListToDataGrid();
                        break;
                    }
                case DialogResult.No:
                    {
                        personList.ImportFromXml();
                        StudentListToDataGrid();
                        TeacherListToDataGrid();
                        break;
                    }
                default:
                    break;
            }
            personList.RecountIds();
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
                            studentDataGridView.Rows.Remove(studentDataGridView.SelectedRows[0]);
                        }
                        break;
                    }
                default:
                    {
                        if (MessageBox.Show("Вы действительно хотите удалить выбранных студентов?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            MessageBox.Show($"Студенты успешно удалены.", "Успех");
                            foreach (DataGridViewRow row in studentDataGridView.SelectedRows)
                            {
                                personList.RemovePerson(int.Parse(row.Cells["SId"].Value.ToString()));
                                studentDataGridView.Rows.Remove(row);
                            }
                        }
                        break;
                    }
            }
        }

        private void deleteTeacherButton_Click(object sender, EventArgs e)
        {
            switch (teacherDataGridView.SelectedRows.Count)
            {
                case 0:
                    {
                        MessageBox.Show("Не выбрано ни одной позиции для удаления!", "Ошибка");
                        break;
                    }
                case 1:
                    {
                        if (MessageBox.Show($"Вы действительно хотите удалить преподавателя {teacherDataGridView.SelectedRows[0].Cells["TName"].Value}?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            MessageBox.Show($"Преподаватель {teacherDataGridView.SelectedRows[0].Cells["TName"].Value} успешно удален.", "Успех");
                            personList.RemovePerson(int.Parse(teacherDataGridView.SelectedRows[0].Cells["TId"].Value.ToString()));
                            teacherDataGridView.Rows.Remove(teacherDataGridView.SelectedRows[0]);
                        }
                        break;
                    }
                default:
                    {
                        if (MessageBox.Show("Вы действительно хотите удалить выбранных преподавателей?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            MessageBox.Show($"Преподаватели успешно удалены.", "Успех");
                            foreach (DataGridViewRow row in teacherDataGridView.SelectedRows)
                            {
                                personList.RemovePerson(int.Parse(row.Cells["TId"].Value.ToString()));
                                teacherDataGridView.Rows.Remove(row);
                            }
                        }
                        break;
                    }
            }
        }
    }
}
