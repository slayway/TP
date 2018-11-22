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
    public partial class AuthorizationForm : Form
    {
        
        public AuthorizationForm()
        {
            InitializeComponent();        
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {

            string login;
            String password;

            if (textBoxLogin.TextLength != 0 && textBoxPass.TextLength != 0)
            {
                login = textBoxLogin.Text;
                password = textBoxPass.Text;

                try
                {
                    using (ProjectContext db = new ProjectContext())
                    {
                        var search = db.Employees.Where(c => c.Login == login & c.Password == password).Select(c => c.accesslvl).First();
                        
                        switch (search)
                        {
                            case 1:
                                WorkerForm w = new WorkerForm();
                                w.Show();
                                this.Hide();
                                break;
                              
                            case 2:
                                ManagerForm m = new ManagerForm();
                                m.Show();
                                this.Hide();
                                break;
                                
                            case 3:
                                AdminForm f = new AdminForm();
                                f.Show();
                                this.Hide();
                                break;
                        }                                         
                        
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Неверный логин или пароль" + ex, "Ошибка");
                    textBoxPass.Clear();
                }
                
            }
            else
            {
                MessageBox.Show("Ошибка! Все поля должны быть заполнены.", "Ошибка");
            }
        }
    }
}
