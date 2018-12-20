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
    public partial class ChooseEmployeeForm : Form
    {
        private BindingSource bs = new BindingSource();
        private DBHelper db = new DBHelper();
        public int idEmp;
        public ChooseEmployeeForm()
        {
            InitializeComponent();
            bs.DataSource = db.showEmployees();
            dataGridView1.DataSource = bs;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int index = dataGridView1.SelectedRows[0].Index;


                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out idEmp);
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
