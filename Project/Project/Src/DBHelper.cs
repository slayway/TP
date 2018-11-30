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
        private int? logId;  

        public void setLogin(String login)
        {
            this.login = login;
        }

        public void setPassword(String password)
        {
            this.password = password;
        }

        /// <summary>
        /// авторизация
        /// </summary>
        /// <returns></returns>
        public int? signIn()
        {
            int? search = 0;
            try
            {
                using (ProjectContext db = new ProjectContext())
                {
                    search = db.Employees.Where(c => c.Login == login & c.Password == password).Select(c => c.accesslvl).First();
                    logId = search;
                }
            }
            catch (Exception)
            {

            }

            return search;
        }

        /// <summary>
        /// отображение проектов в лист
        /// </summary>
        /// <returns></returns>
        public BindingSource showProjects()
        {
            BindingSource bs = new BindingSource();
            try
            {
                using (ProjectContext db = new ProjectContext())
                {
                    db.Projects.Load();
                    var search = db.Projects.Select(c => new
                    {
                        ID = c.Id,
                        Название = c.Title,
                        Цена = c.Price,
                        Описание = c.Description,
                        ID_Заказчика = c.CustomerId,
                        ID_РабГруппы = c.WorkingGroupId                     
                    }).ToList();
                    bs.DataSource = search;
                }
            }
            catch (Exception)
            {

            }

            return bs;
        }

        /// <summary>
        /// отображение задач по проекту
        /// </summary>
        /// <returns></returns>
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
                                Описание = c.Description,
                                Дата_создания = c.DateOfCreate,
                                План_дата_заверш = c.PlanedImpDate,
                                //ActualDate = c.ActualImpDate,
                                Статус = c.Status,
                                ID_Создателя = c.CreatorId,
                                ID_Исполнителя = c.ExecutorId
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
                  
                      var search = db.Tasks
                            .Where(c => c.ProjectId == id)
                            .Select(c => new
                            {
                                ID = c.Id,
                                Описание = c.Description,
                                Дата_создания = c.DateOfCreate,
                                План_дата_заверш = c.PlanedImpDate,
                              //ActualDate = c.ActualImpDate,
                                Статус = c.Status,
                                ID_Создателя = c.CreatorId,
                                ID_Исполнителя = c.ExecutorId
                            }
                            ).OrderBy(t => t.ID_Создателя).ToList();
                        bs.DataSource = search;
                        break;

                    case 2:
                        search = db.Tasks
                            .Where(c => c.ProjectId == id)
                            .Select(c => new
                            {
                                ID = c.Id,
                                Описание = c.Description,
                                Дата_создания = c.DateOfCreate,
                                План_дата_заверш = c.PlanedImpDate,
                                //ActualDate = c.ActualImpDate,
                                Статус = c.Status,
                                ID_Создателя = c.CreatorId,
                                ID_Исполнителя = c.ExecutorId
                            }
                            ).OrderBy(t => t.Дата_создания).ToList();
                        bs.DataSource = search;
                        break;
                    case 3:
                        search = db.Tasks
                            .Where(c => c.ProjectId == id)
                            .Select(c => new
                            {
                                ID = c.Id,
                                Описание = c.Description,
                                Дата_создания = c.DateOfCreate,
                                План_дата_заверш = c.PlanedImpDate,
                                //ActualDate = c.ActualImpDate,
                                Статус = c.Status,
                                ID_Создателя = c.CreatorId,
                                ID_Исполнителя = c.ExecutorId
                            }
                            ).OrderBy(t => t.ID_Исполнителя).ToList();
                        bs.DataSource = search;
                        break;

                }
               
            }

            return bs;
        }
        

        /// <summary>
        /// отображение заказчиков
        /// </summary>
        /// <returns></returns>
        public BindingSource showCustomers()
        {
            BindingSource bs = new BindingSource();
            try
            {
                using (ProjectContext db = new ProjectContext())
                {
                    db.Customers.Load();
                    bs.DataSource = db.Customers.Select(c => new
                    {
                        ID = c.Id,
                        Организация = c.Organization
                    }).ToList();

                }
            }
            catch (Exception)
            {

            }

            return bs;
        }
        /// <summary>
        /// отображение рабочих групп
        /// </summary>
        /// <returns></returns>
        public BindingSource showWorkingGroups()
        {
            BindingSource bs = new BindingSource();
            try
            {
                using (ProjectContext db = new ProjectContext())
                {
                    db.WorkingGroups.Load();
                    bs.DataSource = db.WorkingGroups.Select(c => new
                    {
                        ID = c.Id,
                        Название = c.Title,
                    }).ToList();

                }
            }
            catch (Exception)
            {

            }

            return bs;
        }
        /// <summary>
        /// отображение сотрудников
        /// </summary>
        /// <returns></returns>
        public BindingSource showEmployees()
        {
            BindingSource bs = new BindingSource();
            try
            {
                using (ProjectContext db = new ProjectContext())
                {
                    db.Employees.Load();
                    bs.DataSource = db.Employees.Select(c => new
                    {
                        ID = c.Id,
                        Имя = c.FirstName,
                        Фамилия = c.LastName,
                        Телефон = c.Phone,
                        Ур_Доступа = c.accesslvl,
                        Id_РабГруппы = c.WorkingGroupId
                    }).ToList();

                }
            }
            catch (Exception)
            {

            }

            return bs;
        }

        public BindingSource showDocuments(int id)
        {
            BindingSource bs = new BindingSource();
            try
            {
                using (ProjectContext db = new ProjectContext())
                {
                    db.Documents.Load();
                    bs.DataSource = db.Documents.Where(c => c.TaskId == id)
                        .Select(c => new
                    {
                        ID = c.Id,
                        Название = c.Title,
                        Файл = c.FileData,
                        Описание = c.Description
                    }).ToList();

                }
            }
            catch (Exception)
            {

            }

            return bs;
        }

        
    }
}
