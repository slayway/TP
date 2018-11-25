using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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


    }
}
