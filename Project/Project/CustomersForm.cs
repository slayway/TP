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
    public partial class CustomersForm : Form
    {
        private BindingSource bs = new BindingSource();
        private DBHelper db = new DBHelper();
        public CustomersForm()
        {
            InitializeComponent();

            var customers = db.showCustomers();
            bs.DataSource = customers;
            dataGridView1.DataSource = bs;
        }

        private void buttonAdd1_Click(object sender, EventArgs e)
        {

        }
    }
}
