using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();         
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit();

        }
        private void visiblePictureBox()
        {
            pictureBox1.Visible = false;
        }

        private void заказчикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visiblePictureBox();
            CustomersForm custForm = new CustomersForm();
            custForm.MdiParent = this;
            custForm.Show();           
        }
 
        private void проектыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visiblePictureBox();
            ProjectsForm pjForm = new ProjectsForm();
            pjForm.MdiParent = this;
            pjForm.Show();
            
        }
        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
             visiblePictureBox();
             EmployeesForm empForm = new EmployeesForm();                
             empForm.MdiParent = this;
             empForm.Show();
        }
    }
}