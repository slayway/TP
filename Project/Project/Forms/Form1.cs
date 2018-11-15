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
    public partial class AuthorizationForm : Form
    {
        
        public AuthorizationForm()
        {
            InitializeComponent();        
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {

            /*String login;
            String password;

            if (textBoxLogin.TextLength != 0 && textBoxPass.TextLength != 0)
            {
                login = textBoxLogin.Text;
                password = textBoxPass.Text;

                using (LoginContext db = new LoginContext())
                {
                    var search = db.Employee.Where(c => c.Login == login);
                    if (search != null)
                    {
                        MessageBox.Show("работает");
                    }
                    else
                    {
                        MessageBox.Show("не найдено");
                    }
                }
            }
            else
            {
                MessageBox.Show("Ошибка! Все поля должны быть заполнены.", "Ошибка");
            }*/


            AdminForm f = new AdminForm();
            f.Show();
            this.Hide();

        }
    }
}
