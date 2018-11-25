using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Forms;

namespace Project
{
    public class DBHelper
    {
        private String login { get; set; }
        private String password { get; set; }

        public void setLogin(String login)
        {
            this.login = login;
        }

        public void setPassword(String password)
        {
            this.password = password;
        }

        //авторизация
        public int? signIn()
        {
            int? search = 0;
            try
            {
                using (ProjectContext db = new ProjectContext())
                {
                    search = db.Employees.Where(c => c.Login == login & c.Password == password).Select(c => c.accesslvl).First();
                }
            }
            catch (Exception)
            {

            }

            return search;
        }

        //отображение проектов в лист
        public List<Project> showProjects()
        {
            List<Project> list = null;
            try
            {
                using (ProjectContext db = new ProjectContext())
                {
                    db.Projects.Load();
                    list = db.Projects.Local.ToList();

                }
            }
            catch (Exception)
            {

            }

            return list;
        }


        //отображение задач по проекту
        public BindingSource showTasksPJ(Int32 id)
        {
     
            BindingSource bs = new BindingSource();
            try
            {
                using (ProjectContext db = new ProjectContext())
                {

                   /* var search = db.Tasks.Join(
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
                           }).Where(p => p.ID == id).ToList(); */
                   var search = 

                    //bs.DataSource = search;
                    
                }
            }
            catch (Exception ex)
            {

            }

            return bs;
        }


    }
}
