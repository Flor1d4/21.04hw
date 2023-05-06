using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21._04
{
    public partial class var8 : Form
    {
        List<Student> students = null;
        public var8()
        {
            InitializeComponent();
            Student s1 = new Student("Данилова А.Д.", "Группа 1", 80, 90, 70, new DateTime(2023, 6, 25));
            Student s2 = new Student("Иванова М.А.", "Группа 2", 80, 90, 70, new DateTime(2023, 6, 27));
            Student s3 = new Student("Черняев Д.А.", "Группа 3", 80, 90, 70, new DateTime(2023, 6, 25));
            Student s4 = new Student("Коваленко Я.В.", "Группа 1", 80, 90, 70, new DateTime(2023, 6, 26));
            Student s5 = new Student("Цапкалов Г.Г.", "Группа 2", 80, 90, 70, new DateTime(2023, 6, 25));
            Student s6 = new Student("Чубаев М.А.", "Группа 3", 80, 90, 70, new DateTime(2023, 6, 27));
            Student s7 = new Student("Харитон Г.К.", "Группа 1", 80, 90, 70, new DateTime(2023, 6, 25));
            Student s8 = new Student("Симпсон Б.Г.", "Группа 2", 80, 90, 70, new DateTime(2023, 6, 26));
            Student s9 = new Student("Томченко Р.Т.", "Группа 3", 80, 90, 70, new DateTime(2023, 6, 27));
            Student s10 = new Student("Принц А.М.", "Группа 1", 80, 90, 70, new DateTime(2023, 6, 25));

            students = new List<Student> { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10 };

            listView1.Columns.Add("ФИО");
            listView1.Columns.Add("Номер группы");
            listView1.Columns.Add("Программирование");
            listView1.Columns.Add("Английский");
            listView1.Columns.Add("Математика");
            listView1.Columns.Add("Дата сдачи экзамена");

            foreach (Student student in students)
            {
                ListViewItem item = new ListViewItem(student.FullName);
                item.SubItems.Add(student.GroupNumber);
                item.SubItems.Add(student.PhysicsGrade.ToString());
                item.SubItems.Add(student.MathGrade.ToString());
                item.SubItems.Add(student.InformaticsGrade.ToString());
                item.SubItems.Add(student.LastExamDate.ToShortDateString());
                listView1.Items.Add(item);
            }

            foreach (ColumnHeader column in listView1.Columns)
            {
                column.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                button1.Enabled = false;
            }
                
        }
        public async Task FinalCount()
        {
            DateTime dateTime = DateTime.Parse(textBox1.Text);
            listView1.Items.Clear();
            listView1.Columns.Add("Средний балл");

            foreach (ColumnHeader column in listView1.Columns)
            {
                column.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            }

            foreach (Student student in students)
            {
                if (student.LastExamDate <= dateTime)
                {
                    double GPA = (student.InformaticsGrade + student.MathGrade +
                        student.PhysicsGrade) / 3;
                    ListViewItem item = new ListViewItem(student.FullName);
                    item.SubItems.Add(student.GroupNumber);
                    item.SubItems.Add(student.PhysicsGrade.ToString());
                    item.SubItems.Add(student.MathGrade.ToString());
                    item.SubItems.Add(student.InformaticsGrade.ToString());
                    item.SubItems.Add(student.LastExamDate.ToShortDateString());
                    item.SubItems.Add(GPA.ToString());
                    listView1.Items.Add(item);
                }
            }
            listView1.ListViewItemSorter = new GPAComparer(6);
            listView1.Sort();
        }
        class Student
        {
            public string FullName { get; set; }
            public string GroupNumber { get; set; }
            public int PhysicsGrade { get; set; }
            public int MathGrade { get; set; }
            public int InformaticsGrade { get; set; }
            public DateTime LastExamDate { get; set; }
            public Student(string fullName, string groupNumber, int physicsGrade, int mathGrade, int informaticsGrade, DateTime lastExamDate)
            {
                FullName = fullName;
                GroupNumber = groupNumber;
                PhysicsGrade = physicsGrade;
                MathGrade = mathGrade;
                InformaticsGrade = informaticsGrade;
                LastExamDate = lastExamDate;
            }
        }
        public class GPAComparer : IComparer
        {
            private int column;

            public GPAComparer(int column)
            {
                this.column = column;
            }

            public int Compare(object x, object y)
            {
                ListViewItem itemX = (ListViewItem)x;
                ListViewItem itemY = (ListViewItem)y;

                double gpaX = double.Parse(itemX.SubItems[column].Text);
                double gpaY = double.Parse(itemY.SubItems[column].Text);

                return gpaX.CompareTo(gpaY);
            }
        }
    }
}
