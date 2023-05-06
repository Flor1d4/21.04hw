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
    public partial class var9 : Form
    {
        List<Book> books = null;
        public var9()
        {
            InitializeComponent();

            Book book1 = new Book("001", "Василь Барка", "Жёлтый князь", "Нью-Йорк", "1963", new DateTime(2023, 4, 15), new DateTime(2023, 5, 15));
            Book book2 = new Book("002", "Леся Украинка", "Лесная песня", "Киев", "1914", new DateTime(2023, 3, 15), new DateTime(2023, 4, 15));
            Book book3 = new Book("003", "Тарас Шевченко", "Кобзар", "Киев", "1840", new DateTime(2023, 4, 15), new DateTime(2023, 5, 15));
            Book book4 = new Book("004", "Панас Мирный", "Гулящая: роман", "Киев", "1993", new DateTime(2023, 4, 15), new DateTime(2023, 5, 15));
            Book book5 = new Book("005", "Иван Павлович Багряный", "Тигроловы", "Детроит", "1946", new DateTime(2023, 2, 23), new DateTime(2023, 3, 23));
            Book book6 = new Book("006", "Иван Петрович Котляревский", "Энеида", "Львов", "1842", new DateTime(2023, 1, 03), new DateTime(2023, 2, 03));
            Book book7 = new Book("007", "Иван Семёнович Нечуй-Левицкий", "Семья Кайдаша", "Львов", "1878", new DateTime(2023, 4, 15), new DateTime(2023, 5, 15));
            

            books = new List<Book> { book1, book2, book3, book4, book5, book6, book7 };

            listView1.Columns.Add("Номер");
            listView1.Columns.Add("Автор");
            listView1.Columns.Add("Название");
            listView1.Columns.Add("Издательство");
            listView1.Columns.Add("Год издания");
            listView1.Columns.Add("Дата выдачи книги");
            listView1.Columns.Add("Срок возврата");

            foreach (Book book in books)
            {
                ListViewItem item = new ListViewItem(book.Number);
                item.SubItems.Add(book.NameAuthor);
                item.SubItems.Add(book.Title);
                item.SubItems.Add(book.Publishing);
                item.SubItems.Add(book.PublishingYear);
                item.SubItems.Add(book.DateIssue.ToShortDateString());
                item.SubItems.Add(book.ReturnPeriod.ToShortDateString());
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
            listView1.Items.Clear();

            DateTime now = DateTime.Now;
            TimeSpan interval = TimeSpan.Parse(textBox1.Text);
            DateTime newDateTime = now.Add(interval);
            foreach (Book book in books)
            {
                if (book.ReturnPeriod > newDateTime)
                {
                    ListViewItem item = new ListViewItem(book.Number);
                    item.SubItems.Add(book.NameAuthor);
                    item.SubItems.Add(book.Title);
                    item.SubItems.Add(book.Publishing);
                    item.SubItems.Add(book.PublishingYear);
                    item.SubItems.Add(book.DateIssue.ToShortDateString());
                    item.SubItems.Add(book.ReturnPeriod.ToShortDateString());
                    listView1.Items.Add(item);
                }
            }
        }
    }
    class Book
    {
        public string Number { get; set; }
        public string NameAuthor { get; set; }
        public string Title { get; set; }
        public string Publishing { get; set; }
        public string PublishingYear { get; set; }
        public DateTime DateIssue { get; set; }
        public DateTime ReturnPeriod { get; set; }

        public Book(string number, string nameAuthor, string title, string publishing, string publishingYear, DateTime dateIssue, DateTime returnPeriod)
        {
            Number = number;
            NameAuthor = nameAuthor;
            Title = title;
            Publishing = publishing;
            PublishingYear = publishingYear;
            DateIssue = dateIssue;
            ReturnPeriod = returnPeriod;
        }
    }
}

