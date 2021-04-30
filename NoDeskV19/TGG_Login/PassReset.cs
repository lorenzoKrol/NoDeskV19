using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;

namespace NoDesk
{
    public partial class Form1 : Form
    {
        //create new password reset
        PassReset passReset = new PassReset();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_PassReset_Email_SendButton_Click(object sender, EventArgs e)
        {

            //Create and send Authcode. You get a response back (Succes or error message)
            string Popup_Message = passReset.SendAuthCode(tb_Passreset_Email_Input.Text);

            //if response is success create message box popup with succes message
            if (Popup_Message == "You have send you an email with your Authcode. (It might take a few minutes to arrive in your inbox)")
            {
                MessageBox.Show(Popup_Message, "Succes!!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //if no succes create message box popup with error message
            else
            {
                MessageBox.Show(Popup_Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //store user email for later use
            passReset.User_email = tb_Passreset_Email_Input.Text;

            //hide ResetPasssword Email panel
            pnl_ResetPassword_Email.Hide();
            //show code input panel
            pnl_ResetPassword_CodeInput.Show();
        }

        private void btn_ResetPass_CodeInput_Authorize_Click(object sender, EventArgs e)
        {

            //show error message if input field is empty
            if (tb_ResetPass_CodeInput_Authcode.Text == null)
            {
                MessageBox.Show("Field is empty, please fill in your authorization code before authorizing.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //if input field isn't empty
            else if(tb_ResetPass_CodeInput_Authcode.Text != null)
            {
                //get authcode from textbox
                string AuthCode_Input = tb_ResetPass_CodeInput_Authcode.Text;

                if (passReset.User_email == null)
                {
                    MessageBox.Show("Couldn't authorize code. No Email entered.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //authorization okay?
                   bool Authorization = passReset.AuthorizeCode(passReset.User_email, AuthCode_Input);
                    //if authorization failed show error message
                    if (Authorization == false)
                    {
                        MessageBox.Show("Authorization failed. Your AuthCode is not correct. Please try another code", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //if authorization is okay remove panel and go to new panel.
                    else
                    {
                        pnl_ResetPassword_CodeInput.Hide();
                        pnl_ResetPassword_ChangePass.Show();
                    }
                }
            }
        }

        private void tb_PassReset_ChangePass_PassInput1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_PassReset_ChangePass_ChangePassword_Click(object sender, EventArgs e)
        {
            if (tb_PassReset_ChangePass_PassInput1.Text == null || tb_PassReset_ChangePass_PassInput2.Text == null || tb_PassReset_ChangePass_PassInput1.Text == "" || tb_PassReset_ChangePass_PassInput2.Text == "")
            {
                MessageBox.Show("Passwords are not the same. Please make sure both passwords are the same and try again.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (tb_PassReset_ChangePass_PassInput1.Text == tb_PassReset_ChangePass_PassInput2.Text)
                {
                    //get password from field
                    string password = tb_PassReset_ChangePass_PassInput1.Text;

                    //update password in database
                    if (passReset.InsertPassword(password) == false)
                    {
                        //show error message
                        MessageBox.Show("Password cannot be changed. Please check your Internet connection and try again", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else

                    //show success message
                    MessageBox.Show("Your password has changed!", "Succes",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //close panel
                    pnl_ResetPassword_ChangePass.Hide();
                }
                else
                {
                    //show error message
                    MessageBox.Show("Passwords are not the same. Please make sure both passwords are the same and try again", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
