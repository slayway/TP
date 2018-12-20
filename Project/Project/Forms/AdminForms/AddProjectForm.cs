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
    public partial class AddProjectForm : Form
    {
        public int idCustomer;
        public int idWg;
        public AddProjectForm()
        {
            InitializeComponent();
        }

        private void buttonAdd2_Click(object sender, EventArgs e)
        {
            ChooseCustomerForm f = new ChooseCustomerForm();
            DialogResult result = f.ShowDialog();

            if(result == DialogResult.OK)
            {
                if(f.idCustomer != 0)
                    idCustomer = f.idCustomer;
                else
                {
                    MessageBox.Show("Вы не выбрали заказчика", "Ошибка");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChooseWGForm f = new ChooseWGForm();
            DialogResult result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                if(f.idWG != 0)
                    idWg = f.idWG;
                else
                    MessageBox.Show("Вы не выбрали рабочую группу", "Ошибка");
            }
        }
    }
}
