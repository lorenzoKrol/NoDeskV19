using System;
using System.Windows.Forms;
using TGG_Model;
using TGG_Service;
using NoDesk;

namespace TGG_App
{
    public partial class Login : Form
    {
        User_Service user_Service = new User_Service();
        public Login()
        {
            InitializeComponent();
           // UnameTxtbox.Focus();
        }

        private void Login_Load(object sender, System.EventArgs e)
        {
            ActiveControl = UnameTxtbox;
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            User oneUser = user_Service.verifyUserCredentials(UnameTxtbox.Text,PasswdTxtbox.Text);
            if (oneUser!= null)
            {
                //get user and login
                GoToDashboard(oneUser);
            }
            else
            {
              MessageBox.Show("Username or Password incorrect");
            }

        }

        private void RemMeCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ForgorPassLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 PassResetForm = new Form1();
            PassResetForm.Show();
        }
        private void GoToDashboard(User user)
        {
            this.Hide();
            TGG_Login.Gardern_Group_desk dashboard = new TGG_Login.Gardern_Group_desk(user);
            dashboard.Show();
            
        }

       
    }
}
