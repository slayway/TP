using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Forms;
using System.IO;

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
                    var projects = (from pj in db.Projects
                                    join c in db.Customers on pj.CustomerId equals c.Id
                                    join w in db.WorkingGroups on pj.WorkingGroupId equals w.Id
                                    select new
                                    {
                                        ID = pj.Id,
                                        Название = pj.Title,
                                        Цена = pj.Price,
                                        Описание = pj.Description,
                                        Заказчик = c.Organization,
                                        Рабочая_Группа = w.Title
                                    }).ToList();

                    bs.DataSource = projects;
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
                    var tasks = (from t in db.Tasks
                                 join c in db.Employees on t.CreatorId equals c.Id
                                 join e in db.Employees on t.ExecutorId equals e.Id
                                 where t.ProjectId == id
                                 select new
                                 {
                                     ID = t.Id,
                                     Описание = t.Description,
                                     Дата_создания = t.DateOfCreate,
                                     План_дата_заверш = t.PlanedImpDate,
                                     ДатаЗавершения = t.ActualImpDate,
                                     Статус = t.Status,
                                     Создатель = c.LastName,
                                     Исполнитель = e.LastName
                                 }).ToList();

                   bs.DataSource = tasks;
                    
                }
            }
            catch (Exception)
            {

            }

            return bs;
        }
        /// <summary>
        /// сортировка задач по заданному фильтру
        /// </summary>
        /// <returns></returns>
        public BindingSource sortTasks(Int32 id, int choise)
        {
            BindingSource bs = new BindingSource();

            using (ProjectContext db = new ProjectContext())
            {
                switch (choise)
                {
                    case 1:

                        var search = (from t in db.Tasks
                                     join c in db.Employees on t.CreatorId equals c.Id
                                     join e in db.Employees on t.ExecutorId equals e.Id
                                     where t.ProjectId == id
                                     orderby t.CreatorId
                                     select new
                                     {
                                         ID = t.Id,
                                         Описание = t.Description,
                                         Дата_создания = t.DateOfCreate,
                                         План_дата_заверш = t.PlanedImpDate,
                                         ДатаЗавершения = t.ActualImpDate,
                                         Статус = t.Status,
                                         Создатель = c.LastName,
                                         Исполнитель = e.LastName
                                     }).ToList();
                        bs.DataSource = search;
                        break;

                    case 2:
                        search = (from t in db.Tasks
                                  join c in db.Employees on t.CreatorId equals c.Id
                                  join e in db.Employees on t.ExecutorId equals e.Id
                                  where t.ProjectId == id
                                  orderby t.DateOfCreate
                                  select new
                                  {
                                      ID = t.Id,
                                      Описание = t.Description,
                                      Дата_создания = t.DateOfCreate,
                                      План_дата_заверш = t.PlanedImpDate,
                                      ДатаЗавершения = t.ActualImpDate,
                                      Статус = t.Status,
                                      Создатель = c.LastName,
                                      Исполнитель = e.LastName
                                  }).ToList();
                        bs.DataSource = search;
                        break;
                    case 3:
                        search = (from t in db.Tasks
                                  join c in db.Employees on t.CreatorId equals c.Id
                                  join e in db.Employees on t.ExecutorId equals e.Id
                                  where t.ProjectId == id
                                  orderby t.ExecutorId
                                  select new
                                  {
                                      ID = t.Id,
                                      Описание = t.Description,
                                      Дата_создания = t.DateOfCreate,
                                      План_дата_заверш = t.PlanedImpDate,
                                      ДатаЗавершения = t.ActualImpDate,
                                      Статус = t.Status,
                                      Создатель = c.LastName,
                                      Исполнитель = e.LastName
                                  }).ToList();
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

                    var emp = (from empl in db.Employees
                               join w in db.WorkingGroups on empl.WorkingGroupId equals w.Id
                               select new
                               {
                                   ID = empl.Id,
                                   Имя = empl.FirstName,
                                   Фамилия = empl.LastName,
                                   Телефон = empl.Phone,
                                   Ур_Доступа = empl.accesslvl,
                                   Рабочая_Группа = w.Title
                               }).ToList();

                    bs.DataSource = emp;

                }
            }
            catch (Exception)
            {

            }

            return bs;
        }
        /// <summary>
        /// отображение документов
        /// </summary>
        /// <returns></returns>
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
                        Описание = c.Description
                    }).ToList();

                }
            }
            catch (Exception)
            {

            }

            return bs;
        }
        /// <summary>
        /// проверка существует ли задача с таким id
        /// </summary>
        /// <returns></returns>
        public bool checkTaskId(int id)
        {
            bool result = false;
            try
            {
                using (ProjectContext db = new ProjectContext())
                {
                    db.Documents.Load();
                    var search = db.Tasks.Where(c => c.Id == id)
                        .Select(c => c.Id).First();
                    if (search != 0)
                        result = true;
                }
            }
            catch (Exception)
            {

            }
            
            return result;
        }     
        /// <summary>
        /// добавить документ в бд
        /// </summary>
        /// <returns></returns>
        public bool addDocument(Document doc)
        {
            bool result = false;
            try
            {
                using (ProjectContext db = new ProjectContext())
                {
                    db.Documents.Add(doc);
                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception)
            {

            }

            return result;
        }
        /// <summary>
        /// сохранение документа на компьютер
        /// </summary>
        /// <param name="id"></param>
        public bool saveDoc(int id, string path)
        {
            bool result = false;
            try
            {
                using (ProjectContext db = new ProjectContext())
                {
                    Document e = db.Documents.FirstOrDefault(f => f.Id == id);
                    if(e != null)
                    {                   
                        FileStream fs = new FileStream(path, FileMode.CreateNew);
                        fs.Write(e.FileData, 0, e.FileData.Length);
                        fs.Close();
                        result = true;
                        
                    }
                }
            }
            catch (Exception)
            {

            }
            return result;
        }
        /// <summary>
        /// получение расширения документа
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public String getExt(int id)
        {
            String result = null;
            try
            {
                using (ProjectContext db = new ProjectContext())
                {
                    Document e = db.Documents.FirstOrDefault(f => f.Id == id);
                    if (e != null)
                    {
                        result = e.ext;

                    }
                }
            }
            catch (Exception)
            {

            }
            return result;
        }

        public bool deleteDoc(int id)
        {
            bool result = false;
            try
            {
                using (ProjectContext db = new ProjectContext())
                {
                    Document e = db.Documents.FirstOrDefault(f => f.Id == id);
                    db.Documents.Remove(e);
                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception)
            {

            }

            return result;
        }
    }
}
