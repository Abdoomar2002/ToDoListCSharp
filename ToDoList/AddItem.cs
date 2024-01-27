using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoList.Db;

namespace ToDoList
{
    public partial class AddItem : UserControl
    {
        public AddItem()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AppDbContext context = new AppDbContext();
            ToDoItem item = new ToDoItem();
            item.Title = guna2TextBox1.Text;
            item.time = guna2DateTimePicker1.Value;
            item.Description = guna2TextBox2.Text;
            context._items.Add(item);
            context.SaveChanges();
            MessageBox.Show("تمت الاضافة");
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";
            guna2DateTimePicker1.Value = DateTime.Now;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
            notifyIcon1.ShowBalloonTip(3000);
           
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
