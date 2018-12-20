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
    public partial class ChooseCustomerForm : Form
    {
        private BindingSource bs = new BindingSource();
        private DBHelper db = new DBHelper();
        public int idCustomer;
        public ChooseCustomerForm()
        {
            InitializeComponent();
            bs.DataSource = db.showCustomers();
            dataGridView1.DataSource = bs;
        }

        private void buttonAdd2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int index = dataGridView1.SelectedRows[0].Index;


                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out idCustomer);
                if (!converted)
                    return;
            }
            else
            {
                MessageBox.Show("Вы не можете выбрать больше одной строки.", "Ошибка");
            }
        }
    }
}
