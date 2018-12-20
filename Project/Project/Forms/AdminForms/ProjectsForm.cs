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
    public partial class ProjectsForm : Form
    {
        private BindingSource bs = new BindingSource();
        private BindingSource bs1 = new BindingSource();
        private DBHelper db = new DBHelper();
        private int projejctId = 0;
        private int taskId = 0;

        public ProjectsForm()
        {
            InitializeComponent();

            var pj = db.showProjects();
            bs.DataSource = pj;
            dataGridView1.DataSource = bs;
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

                    //menuVisibleTrue();
                }
                else
                {
                    MessageBox.Show("Ошибка! Вы не можете выбрать больше одной строки.", "Ошибка");
                }
            }
            catch (Exception)
            {
                MessageBox.Show(projejctId.ToString(), "Ошибка");
            }
        }

        private void документыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedRows.Count == 1)
                {
                    int index = dataGridView2.SelectedRows[0].Index;


                    bool converted = Int32.TryParse(dataGridView2[0, index].Value.ToString(), out taskId);
                    if (!converted)
                        return;

                    Documents f = new Documents(taskId);
                    DialogResult result = f.ShowDialog(this);

                    if (result == DialogResult.Cancel)
                        return;
                }
                else
                {
                    MessageBox.Show("Ошибка! Вы не можете выбрать больше одной строки.", "Ошибка");
                }
            }
            catch (Exception)
            {
                MessageBox.Show(taskId.ToString(), "Ошибка");
            }
        }

        private void поСоздателюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var search = db.sortTasks(projejctId, 1);
            bs1.DataSource = search;
            dataGridView2.DataSource = bs1;
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
    }
}
