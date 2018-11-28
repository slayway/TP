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
        private int projejctId = 0;
        public AdminForm()
        {
            InitializeComponent();
            DoubleBuffered = true;


            menuVisibleFalse();

            bs.DataSource = db.showProjects();
            if (bs != null)
                dataGridView1.DataSource = bs;
            else
                MessageBox.Show("Проекты отсутсвуют", "Сообщение");

        }
        
        public void menuVisibleTrue()
        {
            menuStrip1.Visible = true;
        }
        
        public void menuVisibleFalse()
        {
            menuStrip1.Visible = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit();

        }

        private void buttonShowTasksPJ_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                  

                    bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out projejctId);
                    if (!converted)
                        return;

                    var search = db.showTasksPJ(projejctId);
                    bs1.DataSource = search;

                    if (bs1.Count > 0)
                        dataGridView2.DataSource = bs1;
                    else
                        MessageBox.Show("Задачи для данного проекта отсутствуют" + projejctId.ToString(), "Сообщение");

                    menuVisibleTrue();
                }
                else
                {
                    MessageBox.Show("Ошибка! Вы не можете выбрать больше одной строки.", "Ошибка");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(projejctId.ToString(), "Ошибка");
            }                                  
        }

        private void buttonCreatePj_Click(object sender, EventArgs e)
        {

        }

        private void поСоздателюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var search = db.sortTasks(projejctId, 1);
            bs1.DataSource = search;
            dataGridView2.DataSource = bs1;
        }

        private void заказчикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Список заказчиков";
            label1.Location = new Point(600, 40);
            dataGridView1.Location = new Point(350, 59);
            dataGridView1.DataSource = db.showCustomers();
            buttonCreatePj.Location = new Point(348, 405);

            this.Controls.Remove(dataGridView2);
            this.Controls.Remove(label2);
            menuVisibleFalse();
            this.Controls.Remove(button3);
            this.Controls.Remove(buttonShowTasksPJ);           
        }

        private void поДатеСозданияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var search = db.sortTasks(projejctId, 2);
            bs1.DataSource = search;
            dataGridView2.DataSource = bs1;
        }

        private void поТекущемуИспЛицуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var search = db.sortTasks(projejctId, 3);
            bs1.DataSource = search;
            dataGridView2.DataSource = bs1;
        }

        private void проектыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Список проектов";
            label1.Location = new Point(226, 40);
            dataGridView1.Location = new Point(21, 59);
            dataGridView1.DataSource = db.showProjects();
            buttonCreatePj.Location = new Point(21, 405);

            this.Controls.Add(dataGridView2);
            this.Controls.Add(label2);
            menuVisibleFalse();
            this.Controls.Add(button3);
            this.Controls.Add(buttonShowTasksPJ);
        }
    }
}
