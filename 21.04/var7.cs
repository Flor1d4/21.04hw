using System;
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
    public partial class var7 : Form
    {
        List<CompanyEmployees2> employees2 = null;
        public var7()
        {
           InitializeComponent();
            employees2 = new List<CompanyEmployees2>
            {
               new CompanyEmployees2("Данилова", "Алиса", "Данииловна", new DateTime(2012, 5, 10),"Одесса"),
                 new CompanyEmployees2("Иванова", "МАрия", "Алексеевна", new DateTime(1993, 7, 24),  "Одесса"),
                   new CompanyEmployees2("Черняев", "Даниил", "Адамович", new DateTime(1991, 7, 23), "Киев"),
                  new CompanyEmployees2("Коваленко", "Ярослав", "Владимирович", new DateTime(2004, 3, 31),  "Одесса"),
                new CompanyEmployees2("Цапкалов", "Григорий", "Глебович", new DateTime(2004, 6, 8),  "Одесса"),
                   new CompanyEmployees2("Чубаев", "Мартин", "Афанасьевич", new DateTime(2000, 9, 18), "Львов"),
                     new CompanyEmployees2("Харитон", "Гомер", "Курчов", new DateTime(1990, 6, 13), "Харьков"),
                       new CompanyEmployees2("Симпсон", "Барт", "Гомерович", new DateTime(1996, 11, 3),  "Киев"),
              new CompanyEmployees2("Томченко", "Роман", "Томович", new DateTime(1997, 4, 6),  "Харьков"),
                new CompanyEmployees2("Принц", "Артем", "Маркович", new DateTime(1999, 12, 31),  "Киев"),
              new CompanyEmployees2("Дмитришин", "Игорь", "Кавказович", new DateTime(1945, 6, 14), "Тернополь") 
            };
            listView1.Columns.Add("Фамилия");
            listView1.Columns.Add("Имя");
            listView1.Columns.Add("Отчество");
            listView1.Columns.Add("Дата рождения");
            listView1.Columns.Add("Место рождения");
            foreach (CompanyEmployees2 employee in employees2)
            {
                ListViewItem item = new ListViewItem(employee.LastName);
                item.SubItems.Add(employee.FirstName);
                item.SubItems.Add(employee.MiddleName);
                item.SubItems.Add(employee.BirthDate.ToShortDateString());
                item.SubItems.Add(employee.LivePlase);
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
                button1.Enabled = false;
        }
        public async Task FinalCount()
        {
            int year = int.Parse(textBox1.Text);
            listView1.Items.Clear();

            foreach (CompanyEmployees2 employee in employees2)
            {
                if (year == employee.BirthDate.Year)
                {
                    ListViewItem row = new ListViewItem("Введённый вами год");
                    row.SubItems.Add("");
                    row.SubItems.Add("");
                    listView1.Items.Add(row);

                    ListViewItem item = new ListViewItem(employee.LastName);
                    item.SubItems.Add(employee.FirstName);
                    item.SubItems.Add(employee.MiddleName);
                    item.SubItems.Add(employee.BirthDate.ToShortDateString());
                    item.SubItems.Add(employee.LivePlase);
                    listView1.Items.Add(item);
                }
            }
            foreach (CompanyEmployees2 employee in employees2)
            {
                if (employee.BirthDate.Year == 1985)
                {
                    ListViewItem row = new ListViewItem("Сотрудник рожденный в год быка");
                    row.SubItems.Add("");
                    row.SubItems.Add("");
                    listView1.Items.Add(row);

                    ListViewItem item = new ListViewItem(employee.LastName);
                    item.SubItems.Add(employee.FirstName);
                    item.SubItems.Add(employee.MiddleName);
                    item.SubItems.Add(employee.BirthDate.ToShortDateString());
                    item.SubItems.Add(employee.LivePlase);
                    listView1.Items.Add(item);
                }
            }
        }
        class CompanyEmployees2
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public DateTime BirthDate { get; set; }
            public string LivePlase { get; set; }

            public CompanyEmployees2(string lastName, string firstName, string middleName, DateTime birthDate, string livePlase)
            {
                LastName = lastName;
                FirstName = firstName;
                MiddleName = middleName;
                BirthDate = birthDate;
                LivePlase = livePlase;
            }
        }
    }
}
