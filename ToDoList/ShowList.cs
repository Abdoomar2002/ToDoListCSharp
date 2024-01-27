using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore;
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
    public partial class ShowList : UserControl
    {
        public readonly  AppDbContext context;

        public ShowList()
        {
            InitializeComponent();
            context = new AppDbContext();
        }
        public ShowList(DbContextOptions<AppDbContext> options)
        {
            context = new AppDbContext(options);
            context.Database.EnsureCreated();
        }
        public void ShowList_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
           
            var list =  context._items.ToList();
            if(list.Count > 0 )
            {
                foreach (var item in list)
                {
            Guna2Panel guna2 = new Guna2Panel();
                    Guna2TextBox lbl = new Guna2TextBox();
                    lbl.Multiline = true;
                    lbl.Name = item.Id;
                    lbl.BorderThickness = 0;
                    lbl.ForeColor = Color.Black;
                    lbl.Font=new Font("Cairo",9);
                   Guna2Button btn = new Guna2Button();
                    btn.Text = "delete";
                    btn.Font= new Font("Cairo", 12);
                    btn.Size = new Size(100, 80);
                    btn.Click += Btn2_click;
                    lbl.Text+=item.Title+Environment.NewLine;
              
                    lbl.Text+=item.time.ToString()+Environment.NewLine;
                    lbl.Text += item.Description + Environment.NewLine;
              
                    lbl.Height += lbl.PreferredSize.Height;
                 btn.Location=new Point(180,50);
                    guna2.Controls.Add(lbl);
                    guna2.Controls.Add(btn);
                    guna2.Dock = DockStyle.Fill;
                    guna2.Width=guna2.PreferredSize.Width;

                   // tableLayoutPanel1.ColumnStyles[0].Width = ;
                   // tableLayoutPanel1.ColumnStyles[1].Width = Width / 2;
                    tableLayoutPanel1.Controls.Add(guna2);

                }
            }
        }
        public void Btn2_click(object sender, EventArgs e) 
        {
            Guna2Button button = (Guna2Button)sender;
            Guna2Panel guna2=(Guna2Panel)button.Parent;
         var name= Parent.GetNextControl(button,false).Name;
            context._items.Remove(context._items.Where(x=>x.Id==name).FirstOrDefault());
            context.SaveChanges();
            ShowList_Load(null, null);
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
