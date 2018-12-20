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
        public int id;
        private DBHelper db = new DBHelper();

        public AuthorizationForm()
        {
            InitializeComponent();      
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            signIn();

        }

        private void buttonSignIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                signIn();
            }
                
        }

        private void signIn()
        {
            string login;
            String password;

            if (textBoxLogin.TextLength != 0 && textBoxPass.TextLength != 0)
            {
                login = textBoxLogin.Text;
                password = textBoxPass.Text;

                db.setLogin(login);
                db.setPassword(password);
                var search = db.signIn();             

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

                    case 0:
                        MessageBox.Show("Неверный логин или пароль!", "Ошибка");
                        break;
                }

            }
            else
            {
                MessageBox.Show("Ошибка! Все поля должны быть заполнены.", "Ошибка");
            }
        }

        private void textBoxPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                signIn();
            }
        }
    }
}
