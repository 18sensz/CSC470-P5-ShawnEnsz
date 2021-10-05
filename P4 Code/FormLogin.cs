using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P3_Code
{
    public partial class FormLogin : Form
    {
        public AppUser authenticatedUser;
        private FakeAppUserRepository appRepo = new FakeAppUserRepository();
        public FormLogin()
        {
            InitializeComponent();
        }





        private void loginButton_Click(object sender, EventArgs e)
        {
            bool isAuthenticated;
            isAuthenticated = appRepo.Login(this.usernameTextbox.Text, this.passwordTextbox.Text);
            if (isAuthenticated)
            {
                appRepo.SetAuthentication(this.usernameTextbox.Text, true);
                this.DialogResult = DialogResult.OK;
                authenticatedUser = appRepo.GetByUserName(this.usernameTextbox.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect UserName or Password.", "Attention");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            //Create a default app user so it doesnt return null and cause exception
            authenticatedUser = new AppUser();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
