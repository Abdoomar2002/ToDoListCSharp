using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            addItem1.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            showList1.BringToFront();
            showList1.ShowList_Load(null,null);
           // notifyIcon1.ShowBalloonTip(3000,"asfad","adfa",ToolTipIcon.Info);
        }
    }
}
