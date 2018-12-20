using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class AddTaskForm : Form
    {
        public int idEmp;
        public DateTime impDate;
        public AddTaskForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChooseEmployeeForm f = new ChooseEmployeeForm();
            DialogResult result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (f.idEmp != 0)
                    idEmp = f.idEmp;
                else
                    MessageBox.Show("Вы не выбрали сотрудника", "Ошибка");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            impDate = monthCalendar1.SelectionStart;
        }
    }
}
