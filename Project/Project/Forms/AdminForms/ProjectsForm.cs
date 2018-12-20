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

            menuvisibleFalse();
        }

        private void menuvisibleFalse()
        {
            menuStrip1.Visible = false;
        }

        private void menuvisibleTrue()
        {
            menuStrip1.Visible = true;
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
                    {
                        dataGridView2.DataSource = bs1;
                        menuvisibleTrue();
                    }
                    else
                    {
                        MessageBox.Show("Задачи для данного проекта отсутствуют", "Сообщение");
                        menuvisibleFalse();
                    }

                    
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

        private void buttonAdd1_Click(object sender, EventArgs e)
        {
            AddProjectForm f = new AddProjectForm();
            f.Text = "Добавление проекта";
            DialogResult result = f.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            if(result == DialogResult.OK)
            {
                

                if (f.textBox1.TextLength != 0 && f.textBox2.TextLength != 0 && f.textBox3.TextLength != 0)
                {
                    Project project = new Project();
                    project.Title = f.textBox1.Text;                   
                    project.Description = f.textBox3.Text;
                    project.WorkingGroupId = f.idWg;
                    project.CustomerId = f.idCustomer;
                    decimal price;
                    if (decimal.TryParse(f.textBox2.Text, out price))
                    {
                        project.Price = price;
                        if (db.addProject(project))
                        {
                            MessageBox.Show("Проект успешно добавлен", "Сообщение");
                            bs.DataSource = db.showProjects();
                            dataGridView1.DataSource = bs;
                        }
                        else
                            MessageBox.Show("Ошибка добавления", "Ошибка");
                    }
                    else
                        MessageBox.Show("Неверно указан формат в поле 'Цена'", "Ошибка");
                }
                else
                    MessageBox.Show("Заполните все поля!", "Ошибка");
            }
        }

        private void buttonDel1_Click(object sender, EventArgs e)
        {
            int projectId;
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int index = dataGridView1.SelectedRows[0].Index;


                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out projectId);
                if (!converted)
                    return;

                if (db.deleteProject(projectId)){ 
                    MessageBox.Show("Проект успешно удалён", "Сообщение");
                    bs = db.showProjects();
                    dataGridView1.DataSource = bs;
                }
                else
                    MessageBox.Show("Ошибка удаления", "Ошибка");
                
            }
            else
            {
                MessageBox.Show("Ошибка! Вы не можете выбрать больше одной строки.", "Ошибка");
            }
        }

        private void buttonChange1_Click(object sender, EventArgs e)
        {
            int projectId;
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int index = dataGridView1.SelectedRows[0].Index;


                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out projectId);
                if (!converted)
                    return;

                AddProjectForm f = new AddProjectForm();
                f.Text = "Изменение проекта";
                Project project = db.getProjectById(projectId);
                f.textBox1.Text = project.Title;
                f.textBox2.Text = project.Price.ToString();
                f.textBox3.Text = project.Description;

                DialogResult result = f.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                if (result == DialogResult.OK)
                {


                    if (f.textBox1.TextLength != 0 && f.textBox2.TextLength != 0 && f.textBox3.TextLength != 0)
                    {

                        project.Title = f.textBox1.Text;
                        project.Description = f.textBox3.Text;
                        project.WorkingGroupId = f.idWg;
                        project.CustomerId = f.idCustomer;
                        decimal price;
                        if (decimal.TryParse(f.textBox2.Text, out price))
                        {
                            project.Price = price;
                            if (db.changeProject(project))
                            {
                                MessageBox.Show("Проект успешно обновлен", "Сообщение");
                                bs.DataSource = db.showProjects();
                                dataGridView1.DataSource = bs;
                            }
                            else
                                MessageBox.Show("Ошибка обновления", "Ошибка");
                        }
                        else
                            MessageBox.Show("Неверно указан формат в поле 'Цена'", "Ошибка");
                    }
                    else
                        MessageBox.Show("Заполните все поля!", "Ошибка");
                }

            }
            else
            {
                MessageBox.Show("Ошибка! Вы не можете выбрать больше одной строки.", "Ошибка");
            }
        }

        private void buttonAdd2_Click(object sender, EventArgs e)
        {
            int projectId;
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int index = dataGridView1.SelectedRows[0].Index;


                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out projectId);
                if (!converted)
                    return;
                AddTaskForm f = new AddTaskForm();
                f.Text = "Новая задача";
                DialogResult result = f.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                if (result == DialogResult.OK)
                {
                    if (f.textBox1.TextLength != 0)
                    {
                        Task task = new Task();
                        task.Description = f.textBox1.Text;
                        task.CreatorId = db.getLogId();
                        task.DateOfCreate = DateTime.Now;
                        task.ProjectId = projectId;
                        task.Status = "Не завершена";
                        task.PlanedImpDate = f.impDate;
                        task.ExecutorId = f.idEmp;
                        task.ActualImpDate = null;
                        
                        if (db.addTask(task))
                        {
                            MessageBox.Show("Задача успешно добавлена", "Сообщение");
                            bs1.DataSource = db.showTasksPJ(projectId);
                            dataGridView2.DataSource = bs1;
                        }
                        else
                            MessageBox.Show("Ошибка добавления", "Ошибка");
                    }
                    else
                        MessageBox.Show("Заполните все поля!", "Ошибка");
                }
            }
        }
    }
}
