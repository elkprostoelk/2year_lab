﻿
namespace Test_2.AddingPeople
{
    partial class StudentForm
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.submitStudentButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.scholarshipTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.averageBallTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.isStateComboBox = new System.Windows.Forms.ComboBox();
            this.courseWorksComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.facultyTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(249, 89);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(436, 22);
            this.nameTextBox.TabIndex = 0;
            // 
            // ageTextBox
            // 
            this.ageTextBox.Location = new System.Drawing.Point(249, 145);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(64, 22);
            this.ageTextBox.TabIndex = 1;
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(249, 207);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(436, 22);
            this.addressTextBox.TabIndex = 2;
            // 
            // submitStudentButton
            // 
            this.submitStudentButton.Location = new System.Drawing.Point(281, 626);
            this.submitStudentButton.Name = "submitStudentButton";
            this.submitStudentButton.Size = new System.Drawing.Size(199, 44);
            this.submitStudentButton.TabIndex = 3;
            this.submitStudentButton.Text = "Завершить";
            this.submitStudentButton.UseVisualStyleBackColor = true;
            this.submitStudentButton.Click += new System.EventHandler(this.submitStudentButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Полное имя студента:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Возраст:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Адрес:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 395);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Форма обучения:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 456);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Стипендия (если бюджет):";
            // 
            // scholarshipTextBox
            // 
            this.scholarshipTextBox.Location = new System.Drawing.Point(249, 453);
            this.scholarshipTextBox.Name = "scholarshipTextBox";
            this.scholarshipTextBox.Size = new System.Drawing.Size(100, 22);
            this.scholarshipTextBox.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(138, 512);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Средний балл:";
            // 
            // averageBallTextBox
            // 
            this.averageBallTextBox.Location = new System.Drawing.Point(249, 509);
            this.averageBallTextBox.Name = "averageBallTextBox";
            this.averageBallTextBox.Size = new System.Drawing.Size(100, 22);
            this.averageBallTextBox.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 570);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(203, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Курсовая работа (если есть):";
            // 
            // isStateComboBox
            // 
            this.isStateComboBox.FormattingEnabled = true;
            this.isStateComboBox.Items.AddRange(new object[] {
            "Бюджетная",
            "Контрактная"});
            this.isStateComboBox.Location = new System.Drawing.Point(249, 392);
            this.isStateComboBox.Name = "isStateComboBox";
            this.isStateComboBox.Size = new System.Drawing.Size(121, 24);
            this.isStateComboBox.TabIndex = 14;
            this.isStateComboBox.SelectedValueChanged += new System.EventHandler(this.isStateComboBox_SelectedValueChanged);
            // 
            // courseWorksComboBox
            // 
            this.courseWorksComboBox.FormattingEnabled = true;
            this.courseWorksComboBox.Items.AddRange(new object[] {
            "нет"});
            this.courseWorksComboBox.Location = new System.Drawing.Point(249, 567);
            this.courseWorksComboBox.Name = "courseWorksComboBox";
            this.courseWorksComboBox.Size = new System.Drawing.Size(321, 24);
            this.courseWorksComboBox.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(739, 44);
            this.label8.TabIndex = 16;
            this.label8.Text = "Добавление/редактирование студента";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(160, 271);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Факультет:";
            // 
            // facultyTextBox
            // 
            this.facultyTextBox.Location = new System.Drawing.Point(250, 268);
            this.facultyTextBox.Name = "facultyTextBox";
            this.facultyTextBox.Size = new System.Drawing.Size(162, 22);
            this.facultyTextBox.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(184, 332);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "Группа:";
            // 
            // groupTextBox
            // 
            this.groupTextBox.Location = new System.Drawing.Point(249, 332);
            this.groupTextBox.Name = "groupTextBox";
            this.groupTextBox.Size = new System.Drawing.Size(100, 22);
            this.groupTextBox.TabIndex = 20;
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 700);
            this.Controls.Add(this.groupTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.facultyTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.courseWorksComboBox);
            this.Controls.Add(this.isStateComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.averageBallTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.scholarshipTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.submitStudentButton);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.ageTextBox);
            this.Controls.Add(this.nameTextBox);
            this.MinimizeBox = false;
            this.Name = "StudentForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Добавить студента";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox ageTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Button submitStudentButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox scholarshipTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox averageBallTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox isStateComboBox;
        private System.Windows.Forms.ComboBox courseWorksComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox facultyTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox groupTextBox;
    }
}