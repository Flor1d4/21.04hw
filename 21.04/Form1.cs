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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var6 var6 = new var6();
            var6.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var7 var7= new var7();
            var7.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var8 var8 = new var8();
            var8.Show();
        }
        private async void button6_Click(object sender, EventArgs e)
        {
            //await Asynk_Await();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            var9 var9 = new var9();
            var9.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            var10 var10 = new var10();
            var10.Show();
        }
        //private async Task Asynk_Await(var6 var6, var7 var7, var8 var8, var9 var9, var10 var10)
        //{
        //    if (var6 != null && var6.button1.Enabled == false)
        //    {
        //        await var6.FinalCount();
        //    }
        //    if (var7 != null && var7.button1.Enabled == false)
        //    {
        //        await var7.FinalCount();
        //    }
        //    if (var8 != null && var8.button1.Enabled == false)
        //    {
        //        await var8.FinalCount();
        //    }
        //    if (var9 != null && var9.button1.Enabled == false)
        //    {
        //        await var9.FinalCount();
        //    }
        //    if (var10 != null && var10.button1.Enabled == false)
        //    {
        //        await var10.FinalCount();
        //    }
        //}
    }
}
