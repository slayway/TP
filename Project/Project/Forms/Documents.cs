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
    public partial class Documents : Form
    {
        private BindingSource bs = new BindingSource();
        private DBHelper db = new DBHelper();
        private OpenFileDialog openFile = new OpenFileDialog();       
        DialogResult result = new DialogResult();

        public void visibleFalse()
        {
            label1.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            buttonOkAdd.Visible = false;
            buttonOpenFile.Visible = false;
        }

        public void visibleTrue()
        {
            label1.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            buttonOkAdd.Visible = true;
            buttonOpenFile.Visible = true;
        }


        public Documents()
        {
            InitializeComponent();
            visibleFalse();
        }
        public Documents(int id)
        {
            InitializeComponent();
            bs = db.showDocuments(id);
            dataGridView1.DataSource = bs;
            visibleFalse();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            visibleTrue();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            result = openFile.ShowDialog(this);
                
        }

        private void buttonOkAdd_Click(object sender, EventArgs e)
        {
            visibleFalse();
            String tittle;
            String description;
            int taskId;
            byte[] fileData;
            

            if (textBox1.TextLength != 0 && textBox2.TextLength != 0 && textBox3.TextLength != 0)
            {
                if (openFile != null)
                {

                }
                else
                    MessageBox.Show("Выберите файл", "Ошибка");
            }
            else
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка");
        }
    }
}
