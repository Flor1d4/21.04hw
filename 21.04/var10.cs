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
    public partial class var10 : Form
    {
        List<Shop> tovary = new List<Shop>();
        public var10()
        {
            InitializeComponent();
            Shop item1 = new Shop("Фрукты", "Бананы", "Сан Лукар", new DateTime(2023, 5, 6), TimeSpan.FromDays(7));
            Shop item2 = new Shop("Молочные продукты", "Молоко Nöm", "Niederösterreichische Molkerei", new DateTime(2023, 5, 6), TimeSpan.FromDays(14));
            Shop item3 = new Shop("Овощи", "Помидоры", "regionale Produktlinie Da komm' ich her", new DateTime(2023, 5, 6), TimeSpan.FromDays(5));
            Shop item4 = new Shop("Рыбные продукты", "Икра форели", "BILLA Genusswelt", new DateTime(2023, 5, 6), TimeSpan.FromDays(4));
            Shop item5 = new Shop("Мясные продукты", "Филе куриное", "Clever", new DateTime(2023, 5, 6), TimeSpan.FromDays(7));
            Shop item6 = new Shop("Напитки", "Almdudler", "Almdudler-Limonade A. & S. Klein GmbH & Co KG", new DateTime(2023, 5, 6), TimeSpan.FromDays(365));
            Shop item7 = new Shop("Выпечка", "Печенье BILLA с ореховым кремом", "BILLA immer gut", new DateTime(2023, 5, 6), TimeSpan.FromDays(125));
            Shop item8 = new Shop("Консервы", "Inzersdorfer Chili Con Carne", "MARESI Austria GmbH", new DateTime(2023, 5, 6), TimeSpan.FromDays(1825));
            Shop item9 = new Shop("Крупы и макаронные изделия", "Паста Buitoni Farfalle в форме сетки", "Newlat GmbH", new DateTime(2023, 5, 6), TimeSpan.FromDays(730));

            tovary = new List<Shop> { item1, item2, item3, item4, item5, item6, item7, item8, item9 };

            listView1.Columns.Add("Группа товара");
            listView1.Columns.Add("Товар");
            listView1.Columns.Add("Изготовитель");
            listView1.Columns.Add("Дата изготовления");
            listView1.Columns.Add("Срок годности в днях");

            foreach (Shop shop in tovary)
            {
                ListViewItem item = new ListViewItem(shop.Group);
                item.SubItems.Add(shop.Name);
                item.SubItems.Add(shop.Manufacturer);
                item.SubItems.Add(shop.DateManufacture.ToShortDateString());
                item.SubItems.Add(shop.Shelflife.TotalDays.ToString());
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
            DateTime interval = DateTime.Parse(textBox1.Text);
            foreach (Shop shop in tovary)
            {
                DateTime shelf = shop.DateManufacture + shop.Shelflife;
                if (interval > shelf)
                {
                    ListViewItem item = new ListViewItem(shop.Group);
                    item.SubItems.Add(shop.Name);
                    item.SubItems.Add(shop.Manufacturer);
                    item.SubItems.Add(shop.DateManufacture.ToShortDateString());
                    item.SubItems.Add(shop.Shelflife.TotalDays.ToString());
                    listView1.Items.Add(item);
                }
            }
        }
    }
    public class Shop
    {
        public string Group { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public DateTime DateManufacture { get; set; }
        public TimeSpan Shelflife { get; set; }

        public Shop(string group, string name, string manufacturer, DateTime dateManufacture, TimeSpan shelfLife)
        {
            Group = group;
            Name = name;
            Manufacturer = manufacturer;
            DateManufacture = dateManufacture;
            Shelflife = shelfLife;
        }
    }
}

