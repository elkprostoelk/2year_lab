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

namespace Test_2.AddingPeople
{
    public partial class TeacherForm : Form
    {
        private Teacher teacher;
        public TeacherForm(ref Teacher teacher)
        {
            InitializeComponent();
            this.teacher = teacher;
            academicDegreeComboBox.SelectedItem = academicDegreeComboBox.Items[3];
            titleComboBox.SelectedItem = titleComboBox.Items[3];
            foreach (var item in MainForm.personList.getList())
            {
                if (item.GetTypeName() == "Student")
                    checkedListBox1.Items.Add(item.getName());
            }
            if(teacher.getName()!="xxx")
            {
                nameTextBox.Text = teacher.getName();
                ageTextBox.Text = teacher.getAge().ToString();
                countryTextBox.Text = teacher.getAddress().getCountry();
                oblastTextBox.Text = teacher.getAddress().getOblast();
                regionTextBox.Text = teacher.getAddress().getRegion();
                cityTextBox.Text = teacher.getAddress().getCity();
                streetTextBox.Text = teacher.getAddress().getStreet();
                homeNumberTextBox.Text = teacher.getAddress().getHomeNumber();
                apartmentTextBox.Text = teacher.getAddress().getApartment().ToString();
                salaryTextBox.Text = teacher.getSalary().ToString();
                maxNumTextBox.Text = teacher.getMaxNumberOfCourseWorks().ToString();
                academicDegreeComboBox.SelectedItem = academicDegreeComboBox.Items[Convert.ToInt32(teacher.getAcademicDegree())];
                titleComboBox.SelectedItem = titleComboBox.Items[Convert.ToInt32(teacher.getTitle())];
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (teacher.getCourseWorkStudents().Contains(MainForm.personList.FindPersonByName(checkedListBox1.Items[i].ToString()).getList()[0]))
                        checkedListBox1.SetItemChecked(i, true);
                }
            }
        }

        private void submitStudentButton_Click(object sender, EventArgs e)
        {
            teacher.setName(nameTextBox.Text);
            teacher.setAge(int.Parse(ageTextBox.Text));
            teacher.setAddress(new AddressField(countryTextBox.Text,oblastTextBox.Text,regionTextBox.Text,
                cityTextBox.Text,streetTextBox.Text,homeNumberTextBox.Text,apartmentTextBox.Text));
            teacher.setSalary(float.Parse(salaryTextBox.Text));
            teacher.setMaxNumberOfCourseWorks(int.Parse(maxNumTextBox.Text));
            teacher.setAcademicDegreeStr(academicDegreeComboBox.SelectedItem.ToString());
            teacher.setTitleStr(titleComboBox.SelectedItem.ToString());
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                foreach (string item in checkedListBox1.CheckedItems)
                {
                    try 
                    { 
                        Student s = (Student)MainForm.personList.FindPersonByName(item).getList()[0];
                        if (!teacher.getCourseWorkStudents().Contains(s)) teacher.AddCourseWorkStudent(s);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
            else teacher.setCourseWorkStudents(new List<Student>(teacher.getMaxNumberOfCourseWorks()));
            MessageBox.Show("Готово!", "OK", MessageBoxButtons.OK);
            this.Close();
        }
    }
}
