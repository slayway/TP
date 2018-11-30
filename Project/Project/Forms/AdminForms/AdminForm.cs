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
        private int formTrack = 0;
        private int taskId = 0;
        public AdminForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            formTrack = 1;
            showProjects();
            menuVisibleFalse();           
        }

        public void showProjects()
        {
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
            catch (Exception)
            {
                MessageBox.Show(projejctId.ToString(), "Ошибка");
            }
        }
        /// <summary>
        /// новый проект
        /// </summary>
        private void buttonCreatePj_Click(object sender, EventArgs e)
        {

        }

        private void поСоздателюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var search = db.sortTasks(projejctId, 1);
            bs1.DataSource = search;
            dataGridView2.DataSource = bs1;
        }
        /// <summary>
        /// перерисовка формы для пункта заказчики
        /// </summary>
        private void заказчикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Список заказчиков";
            label1.Location = new Point(600, 40);
            dataGridView1.Location = new Point(350, 59);
            bs = db.showCustomers();
            dataGridView1.DataSource = bs;
            buttonAdd1.Location = new Point(348, 405);
            buttonDel1.Location = new Point(897, 405);
            buttonChange1.Location = new Point(622, 405);

            this.Controls.Remove(dataGridView2);
            this.Controls.Remove(label2);           
            this.Controls.Remove(buttonAdd2);
            this.Controls.Remove(buttonShowTasksPJ);
            this.Controls.Remove(buttonDel2);
            this.Controls.Remove(buttonChange2);

            menuVisibleFalse();
            formTrack = 2;
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
        /// <summary>
        /// перерисовка формы для пункта проекты
        /// </summary>
        private void проектыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Список проектов";
            label1.Location = new Point(226, 40);
            dataGridView1.Location = new Point(21, 59);
            bs = db.showProjects();
            dataGridView1.DataSource = bs;
            buttonAdd1.Location = new Point(21, 405);
            buttonDel1.Location = new Point(568, 405);
            buttonChange1.Location = new Point(373, 405);
            buttonChange2.Location = new Point(910, 405);

            this.Controls.Add(dataGridView2);
            this.Controls.Add(label2);
            this.Controls.Add(buttonDel2);
            this.Controls.Add(buttonAdd2);
            this.Controls.Add(buttonShowTasksPJ);
            this.Controls.Add(buttonChange2);

            menuVisibleFalse();
            formTrack = 1;

            label2.Text = "Список задач";                    
            dataGridView2.DataSource = null;
        }
        /// <summary>
        /// перерисовка формы для пункта сотрудники
        /// </summary>
        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Список сотрудников";
            label1.Location = new Point(226, 40);
            dataGridView1.Location = new Point(21, 59);
            bs = db.showEmployees();
            dataGridView1.DataSource = bs;         
            buttonAdd1.Location = new Point(21, 405);
            buttonDel1.Location = new Point(568, 405);
            buttonChange1.Location = new Point(303, 405);
            buttonChange2.Location = new Point(910, 405);

            this.Controls.Add(dataGridView2);
            this.Controls.Add(label2);
            this.Controls.Add(buttonDel2);
            this.Controls.Add(buttonAdd2);
            this.Controls.Remove(buttonShowTasksPJ);
            this.Controls.Add(buttonChange2);

            label2.Text = "Рабочие группы";           
            bs1 = db.showWorkingGroups();
            dataGridView2.DataSource = bs1;

            menuVisibleFalse();
            formTrack = 3;
        }
        /// <summary>
        /// открытие формы документов
        /// </summary>     
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

        private void buttonDel1_Click(object sender, EventArgs e)
        {

        }
    }
}