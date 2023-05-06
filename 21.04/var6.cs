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
    public partial class var6 : Form
    {
        List<CompanyEmployees> employees = null;
        public var6()
        {
            InitializeComponent();
            employees = new List<CompanyEmployees>
            {
    new CompanyEmployees("Данилова", "Алиса", "Данииловна", new DateTime(2012, 5, 10), "+380739694823", "Улица Прорізна", 49, "107"),
    new CompanyEmployees("Иванова", "МАрия", "Алексеевна", new DateTime(1993, 7, 24), "+380932861260", "Улица М. Коцюбинського", 2, "5"),
    new CompanyEmployees("Черняев", "Даниил", "Адамович", new DateTime(1991, 7, 23), "+380930187946", "Улица Фізкультури", 1, "25"),
    new CompanyEmployees("Коваленко", "Ярослав", "Владимирович", new DateTime(2004, 3, 31), "+380918198579", "Улица Тараса Шевченка", 54, "33"),
    new CompanyEmployees("Цапкалов", "Григорий", "Глебович", new DateTime(2004, 6, 8), "+380989592000", "Улица Паторжинського", 100, "85"),
    new CompanyEmployees("Чубаев", "Мартин", "Афанасьевич", new DateTime(2000, 9, 18), "+380922245078", "Улица Урицького", 30, "30"),
    new CompanyEmployees("Харитон", "Гомер", "Курчов", new DateTime(1990, 6, 13), "+380996796692", "Улица І. Франкa", 74, "31"),
    new CompanyEmployees("Симпсон", "Барт", "Гомерович", new DateTime(1996, 11, 3), "+380927688705", "Улица П. Орлика", 168, "69"),
    new CompanyEmployees("Томченко", "Роман", "Томович", new DateTime(1997, 4, 6), "+380960020849", "Улица Інститутська", 23, "55"),
    new CompanyEmployees("Принц", "Артем", "Маркович", new DateTime(1999, 12, 31), "+380971020841", "Улица Хрещатик", 74, "49"),
    new CompanyEmployees("Дмитришин", "Игорь", "Кавказович", new DateTime(1945, 6, 14), "+380918345626", "Улица Львівська", 99, "108") 
            }; 
            listView1.Columns.Add("Фамилия");
            listView1.Columns.Add("Имя");
            listView1.Columns.Add("Отчество");
            listView1.Columns.Add("Дата рождения");
            listView1.Columns.Add("Телефон");
            listView1.Columns.Add("Улица");
            listView1.Columns.Add("Номер дома");
            listView1.Columns.Add("Номер кв.");
            foreach (CompanyEmployees employee in employees)
            {
                ListViewItem item = new ListViewItem(employee.LastName);
                item.SubItems.Add(employee.FirstName);
                item.SubItems.Add(employee.MiddleName);
                item.SubItems.Add(employee.BirthDate.ToShortDateString());
                item.SubItems.Add(employee.Phone);
                item.SubItems.Add(employee.Street);
                item.SubItems.Add(employee.HouseNumber.ToString());
                item.SubItems.Add(employee.ApartmentNumber);
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
            string street = textBox1.Text;
            listView1.Items.Clear();
            int totalAge = 0;

            foreach (CompanyEmployees employee in employees)
            {
                if ((street == employee.Street) && (employee.HouseNumber % 2 == 0))
                {
                    ListViewItem item = new ListViewItem(employee.LastName);
                    totalAge += DateTime.Now.Year - employee.BirthDate.Year;
                    item.SubItems.Add(employee.FirstName);
                    item.SubItems.Add(employee.MiddleName);
                    item.SubItems.Add(employee.BirthDate.ToShortDateString());
                    item.SubItems.Add(employee.Phone);
                    item.SubItems.Add(employee.Street);
                    item.SubItems.Add(employee.HouseNumber.ToString());
                    item.SubItems.Add(employee.ApartmentNumber);
                    listView1.Items.Add(item);
                }
            }
            double averageAge = totalAge / listView1.Items.Count;
            MessageBox.Show($"Средний возраст сотрудников: {averageAge:F1} лет");
        }
    }
    class CompanyEmployees
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public CompanyEmployees(string lastName, string firstName, string middleName, DateTime birthDate, string phone, string street, int houseNumber, string apartmentNumber)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            BirthDate = birthDate;
            Phone = phone;
            Street = street;
            HouseNumber = houseNumber;
            ApartmentNumber = apartmentNumber;
        }
    }
}

