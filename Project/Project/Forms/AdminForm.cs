using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Project
{
    public partial class AdminForm : Form
    {
        private BindingSource bs = new BindingSource();
        public AdminForm()
        {
            InitializeComponent();
            try
            {
                using (LoginContext db = new LoginContext())
                {
                    db.Employees.Load();
                    List<Employee> list = new List<Employee>(db.Employees.Local.ToList());

                    bs.DataSource = list;
                    dataGridView1.DataSource = bs;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
        }
     

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit();

        }
    }
}
