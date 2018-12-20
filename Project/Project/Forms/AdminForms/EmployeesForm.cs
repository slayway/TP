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
    public partial class EmployeesForm : Form
    {
        private BindingSource bs = new BindingSource();
        private BindingSource bs1 = new BindingSource();
        private DBHelper db = new DBHelper();

        public EmployeesForm()
        {
            InitializeComponent();

            var emp = db.showEmployees();
            bs.DataSource = emp;
            var wg = db.showWorkingGroups();
            bs1.DataSource = wg;

            dataGridView1.DataSource = bs;
            dataGridView2.DataSource = bs1;

        }

    }
}
