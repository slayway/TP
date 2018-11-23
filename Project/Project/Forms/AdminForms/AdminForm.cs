using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Project
{
    public partial class AdminForm : Form
    {
        private BindingSource bs = new BindingSource();
        private BindingSource bs1 = new BindingSource();
        public AdminForm()
        {
            InitializeComponent();
            try
            {
                using (ProjectContext db = new ProjectContext())
                {
                    db.Projects.Load();
                    List<Project> list = new List<Project>(db.Projects.Local.ToList());                 

                    bs.DataSource = list;
                    dataGridView1.DataSource = bs;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка");
            }
            
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
                    showTasksPJ(id);

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

        private void showTasksPJ(Int32 id)
        {
            try
            {
                using (ProjectContext db = new ProjectContext())
                {

                    var search = db.Tasks.Join(
                            db.Projects,
                            p => p.Id,
                            t => t.TaskId,
                            (task, project) => new
                            {
                                ID = project.TaskId,
                                Описание = task.Description,
                                ДатаСоздания = task.DateOfCreate,
                                ПлановаяДатаРеализации = task.PlanedImpDate,
                                ФактическаяДатаРеализации = task.ActualImpDate,
                                Статус = task.Status,
                            }).Where(p => p.ID == id);

                    bs1.DataSource = search.ToList();
                    if (bs1.Count > 0)
                        dataGridView2.DataSource = bs1;
                    else
                        MessageBox.Show("Задачи для данного проекта отсутствуют", "Сообщение");
                }
            }          
            catch (Exception ex)
            {
                 MessageBox.Show(ex.ToString(), "Ошибка");
            }           
        }
    }
}
