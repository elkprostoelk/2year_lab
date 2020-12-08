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
    public partial class StudentForm : Form
    {
        private Student student;
        public StudentForm(ref Student student)
        {
            InitializeComponent();
            this.student = student;
            courseWorksComboBox.SelectedItem = courseWorksComboBox.Items[0];
            if(student.getName()!="xxx")
            {
                nameTextBox.Text = student.getName();
                ageTextBox.Text = student.getAge().ToString();
                countryTextBox.Text = student.getAddress().getCountry();
                oblastTextBox.Text = student.getAddress().getOblast();
                regionTextBox.Text = student.getAddress().getRegion();
                cityTextBox.Text = student.getAddress().getCity();
                streetTextBox.Text = student.getAddress().getStreet();
                homeNumberTextBox.Text = student.getAddress().getHomeNumber();
                apartmentTextBox.Text = student.getAddress().getApartment().ToString();
                facultyTextBox.Text = student.getFaculty();
                groupTextBox.Text = student.getGroup();
                if (student.getIsState()) isStateComboBox.SelectedItem = isStateComboBox.Items[0];
                else isStateComboBox.SelectedItem = isStateComboBox.Items[1];
                scholarshipTextBox.Text = student.getScholarship().ToString();
                averageBallTextBox.Text = student.getAverageBall().ToString();
            }
        }

        private void submitStudentButton_Click(object sender, EventArgs e)
        {
            student.setName(nameTextBox.Text);
            student.setAge(int.Parse(ageTextBox.Text));
            student.setAddress(new AddressField(countryTextBox.Text, oblastTextBox.Text, regionTextBox.Text,
                cityTextBox.Text, streetTextBox.Text, homeNumberTextBox.Text, int.Parse(apartmentTextBox.Text)));
            student.setFaculty(facultyTextBox.Text);
            student.setGroup(groupTextBox.Text);
            if (isStateComboBox.SelectedIndex == 0) student.setIsState(true);
            else student.setIsState(false);
            student.setScholarship(float.Parse(scholarshipTextBox.Text));
            student.setAverageBall(float.Parse(averageBallTextBox.Text));
            if (courseWorksComboBox.SelectedItem.ToString() == "нет") student.setCourseWork(null);
            MessageBox.Show("Готово!", "OK", MessageBoxButtons.OK);
            this.Close();
        }

        private void isStateComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (isStateComboBox.SelectedItem == isStateComboBox.Items[1])
            {
                scholarshipTextBox.ReadOnly = true;
                scholarshipTextBox.Text = "0";
            }
            else scholarshipTextBox.ReadOnly = false;
        }
    }
}
