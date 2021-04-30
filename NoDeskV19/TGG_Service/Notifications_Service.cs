using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using MongoDB.Driver;
using MongoDB.Bson;

namespace TGG_Service
{
    public class Notifications_Service
    {
        public void CreateEmail(string ToEmail, string status)
        {
            //create empty message
            string Message = "";

            if (status == "PastDeadline")
            {
                Message = "Dear" + ToEmail+ ", \n" +
                    "Unfortunatly your ticket has expired passed it's deadline. Therefor it has received status:'" + status.ToString() + ". \n" +
                    "We try to solve you ticket as soon as possible. If your ticket isn't solved within 48 hours please contact the helpdesk."
                    ;
            }
            else if (status == "Pending")
            {
                Message = "Dear" + ToEmail + ", \n" +
                    "Good news! We are currently working on your ticket. Your ticket status is currently: '" + status.ToString() + "'.";
                    ;
            }
            else if (status == "Solved")
            {
                Message = "Dear" + ToEmail + ", \n" +
                    "Good news! Your ticket has status:'" + status.ToString() + "'. That means that your ticket should be solved! If your problem isn't fixed please contact the helpdesk.";
            }

            if (Message != "")
            {
                //try to create and send email
                try
                {
                    //SMTP mailserver 
                    SmtpClient mySmtpClient = new SmtpClient("mail.inholland-project.nl");

                    // set smtp-client with basicAuthentication
                    mySmtpClient.UseDefaultCredentials = false;
                    System.Net.NetworkCredential basicAuthenticationInfo = new
                       System.Net.NetworkCredential("nodesk@inholland-project.nl", "Pindakaas01");
                    mySmtpClient.Credentials = basicAuthenticationInfo;

                    // add from,to mailaddresses
                    MailAddress from = new MailAddress("nodesk@inholland-project.nl", "NoDesk_Service");
                    MailAddress to = new MailAddress(ToEmail, ToEmail);
                    MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                    // add ReplyTo
                    MailAddress replyto = new MailAddress("nodesk@inholland-project.nl");
                    myMail.ReplyToList.Add(replyto);

                    // set subject and encoding
                    myMail.Subject = "NoDESK Ticket Status Change";
                    myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                    // set body-message and encoding
                    myMail.Body = Message;
                    myMail.BodyEncoding = System.Text.Encoding.UTF8;
                    // text or html
                    myMail.IsBodyHtml = true;

                    //send email
                    mySmtpClient.Send(myMail);
                }

                //catch exception if one occurs
                catch (SmtpException ex)
                {
                    throw new ApplicationException
                      ("SmtpException has occured: " + ex.Message);
                }

                //throw exeption back as error message.
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Email_UserAddEdit(string ToEmail, string Username, string Userpassword, string Userstatus, string UsermanagementAction)
        {
            //create empty message
            string Message = "";

            if (UsermanagementAction == "Added")
            {
                Message = "Dear" + Username + "\n" +
                    "Welcome to NoDesk. Your account just as been added to our system. You'll find your account details below: \n" +
                    "Email: " + ToEmail + "\n" +
                    "Username: " + Username + "\n" +
                    "Password: " + Userpassword + "\n" +
                    "Account status: " + Userstatus + "\n" +
                    "Ps. We reccommand changing you, by admin made password into your own password";
                    ;
            }
            else if (UsermanagementAction == "Editted")
            {
                Message = "Dear" + Username + "\n" +
                    "Your account has been editted by a NoDesk Admin. Below you'll find you new / editted account details: \n" +
                    "Email: " + ToEmail + "\n" +
                    "Username: " + Username + "\n" +
                    "Password: " + Userpassword + "\n" +
                    "Account status: " + Userstatus + "\n";
            }
            else if (UsermanagementAction == "Deleted")
            {
                Message = "Dear" + Username + "\n" +
                    "Your NoDesk account has been deleted. It's not possible to use the NoDesk applications from now on.";
            }

            if (Message != "")
            {
                //try to create and send email
                try
                {
                    //SMTP mailserver 
                    SmtpClient mySmtpClient = new SmtpClient("mail.inholland-project.nl");

                    // set smtp-client with basicAuthentication
                    mySmtpClient.UseDefaultCredentials = false;
                    System.Net.NetworkCredential basicAuthenticationInfo = new
                       System.Net.NetworkCredential("nodesk@inholland-project.nl", "Pindakaas01");
                    mySmtpClient.Credentials = basicAuthenticationInfo;

                    // add from,to mailaddresses
                    MailAddress from = new MailAddress("nodesk@inholland-project.nl", "NoDesk_Service");
                    MailAddress to = new MailAddress(ToEmail, ToEmail);
                    MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                    // add ReplyTo
                    MailAddress replyto = new MailAddress("nodesk@inholland-project.nl");
                    myMail.ReplyToList.Add(replyto);

                    // set subject and encoding
                    myMail.Subject = "NoDESK Account "+ UsermanagementAction;
                    myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                    // set body-message and encoding
                    myMail.Body = Message;
                    myMail.BodyEncoding = System.Text.Encoding.UTF8;
                    // text or html
                    myMail.IsBodyHtml = true;

                    //send email
                    mySmtpClient.Send(myMail);
                }

                //catch exception if one occurs
                catch (SmtpException ex)
                {
                    throw new ApplicationException
                      ("SmtpException has occured: " + ex.Message);
                }

                //throw exeption back as error message.
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Email_UserDelete(string ToEmail)
        {
            //create empty message
            string Message = "Dear NoDesk User, \n"+
                "your account has been deleted from out system. It is not possible to use the NoDesk Software anymore. Please contact an Admin for them to add you.";

            if (Message != "")
            {
                //try to create and send email
                try
                {
                    //SMTP mailserver 
                    SmtpClient mySmtpClient = new SmtpClient("mail.inholland-project.nl");

                    // set smtp-client with basicAuthentication
                    mySmtpClient.UseDefaultCredentials = false;
                    System.Net.NetworkCredential basicAuthenticationInfo = new
                       System.Net.NetworkCredential("nodesk@inholland-project.nl", "Pindakaas01");
                    mySmtpClient.Credentials = basicAuthenticationInfo;

                    // add from,to mailaddresses
                    MailAddress from = new MailAddress("nodesk@inholland-project.nl", "NoDesk_Service");
                    MailAddress to = new MailAddress(ToEmail, ToEmail);
                    MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                    // add ReplyTo
                    MailAddress replyto = new MailAddress("nodesk@inholland-project.nl");
                    myMail.ReplyToList.Add(replyto);

                    // set subject and encoding
                    myMail.Subject = "NoDESK Account Deleted";
                    myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                    // set body-message and encoding
                    myMail.Body = Message;
                    myMail.BodyEncoding = System.Text.Encoding.UTF8;
                    // text or html
                    myMail.IsBodyHtml = true;

                    //send email
                    mySmtpClient.Send(myMail);
                }

                //catch exception if one occurs
                catch (SmtpException ex)
                {
                    throw new ApplicationException
                      ("SmtpException has occured: " + ex.Message);
                }

                //throw exeption back as error message.
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
