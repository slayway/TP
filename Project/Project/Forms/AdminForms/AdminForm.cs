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
        private BindingSource bs = new BindingSource();
        private BindingSource bs1 = new BindingSource();
        private DBHelper db = new DBHelper();

        public AdminForm()
        {
            InitializeComponent();

            bs.DataSource = db.showProjects();
            if (bs != null)
                dataGridView1.DataSource = bs;
            else
                MessageBox.Show("Проекты отсутсвуют", "Сообщение");

        }
     

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit();

        }

        private void buttonShowTasksPJ_Click(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                  

                    bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                    if (!converted)
                        return;

                    var search = db.showTasksPJ(id);
                    bs1.DataSource = search;

                    if (bs1.Count > 0)
                        dataGridView2.DataSource = bs1;
                    else
                        MessageBox.Show("Задачи для данного проекта отсутствуют" + id.ToString(), "Сообщение");

                }
                else
                {
                    MessageBox.Show("Ошибка! Вы не можете выбрать больше одной строки.", "Ошибка");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(id.ToString(), "Ошибка");
            }                                  
        }
        
    }
}
