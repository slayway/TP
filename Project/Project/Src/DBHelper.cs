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
        private String login;
        private String password;
        private int logId;  

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
                    logId = db.Employees.Where(c => c.Login == login & c.Password == password).Select(c => c.Id).First();
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
                           
                   var search = db.Tasks
                        .Where(c => c.ProjectId == id)
                        .Select(c => new 
                        {
                                ID = c.Id,
                                Desc = c.Description,
                                CreateDate = c.DateOfCreate,
                                PlanedDate = c.PlanedImpDate,
                                //ActualDate = c.ActualImpDate,
                                TaskStatus = c.Status
                        }
                        ).ToList();

                   bs.DataSource = search;
                    
                }
            }
            catch (Exception ex)
            {

            }

            return bs;
        }

        public BindingSource sortTasks(Int32 id, int choise)
        {
            BindingSource bs = new BindingSource();

            using (ProjectContext db = new ProjectContext())
            {
                switch (choise)
                {
                    case 1:
                        var search = db.Tasks.Join(
                            db.Employees,
                            t => t.CreatorId,
                            e => e.Id,
                            (task, emp) => new //c => c.ProjectId == id
                            {
                                ID = task.Id,
                                Desc = task.Description,
                                CreateDate = task.DateOfCreate,
                                PlanedDate = task.PlanedImpDate,
                                //ActualDate = c.ActualImpDate,
                                Creator = emp.LastName,
                                Executor = emp.LastName,
                                TaskStatus = task.Status,
                                ProjectID = task.ProjectId
                            }
                            ).Where(t => t.ProjectID == id)
                            .OrderBy(t => t.Creator).ToList();
                        bs.DataSource = search;
                        break;
                }

                
            }

            return bs;
        }

        public BindingSource showCustomers()
        {
            BindingSource bs = new BindingSource();
            try
            {
                using (ProjectContext db = new ProjectContext())
                {
                    db.Customers.Load();
                    bs.DataSource = db.Customers.Local.ToList();

                }
            }
            catch (Exception)
            {

            }

            return bs;
        }


    }
}
