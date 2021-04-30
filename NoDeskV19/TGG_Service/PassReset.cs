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

namespace NoDesk
{
    public class PassReset
    {
        public string User_email { get; set; }
        public DAO_PassReset DAO_PassReset = new DAO_PassReset();

        //send Authorization code to email
        public string SendAuthCode(string Email)
        {
            //Check if Email exists in database
            bool EmailExist = EmailExists(Email);

            if (EmailExist)
            {
                //store Email in public variable for later use.
                User_email = Email;

                //get AuthCode
                string AuthCode = GenerateAuthCode();

                //insert Authcode into database
                DAO_PassReset.InsertAuthCode(User_email, AuthCode);

                //create email
                CreateEmail(Email,AuthCode);
                return "You have send you an email with your Authcode. (It might take a few minutes to arrive in your inbox)";
            }
            else
            {
                return "Could not create Authcode or / and Email. Please check your internet connection or restart this program. ";
            }
        }

        public string GenerateAuthCode()
        {
            Random generator = new Random();
            String AuthCode = generator.Next(0, 999999).ToString("D6");
            return AuthCode;
        }

        public bool AuthorizeCode(string Email, string AuthCode)
        {
            //variables
            string user_Authcode = AuthCode;
            string user_Email = Email;

            //dictionary
            Dictionary<string, string> user = new Dictionary<string, string>();

            //get Authcode from database
            List<BsonDocument> UserPasswordList = DAO_PassReset.GetAuthCode(user_Email);

            //add value / values from Bsonlist to normal dictionary
            foreach (var document in UserPasswordList)
            {
               foreach (BsonElement element in document)
               {
                    user.Add(element.Name, element.Value.ToString());

                }
            }

            //check if dictionary contains users email
            if (user.ContainsValue(User_email))
            {
                //if it has user email get authcode from database
                string DatabaseAuthCode = user["Auth_code"];

                //check if they are the same and return value
                return DatabaseAuthCode == user_Authcode;
            }
            else

            //return value
            return false;
        }

        public void CreateEmail(string Email, string AuthCode)
        {
            //try to create and send email
            try
            {
                //SMTP mailserver 
                SmtpClient mySmtpClient = new SmtpClient("");

                // set smtp-client with basicAuthentication
                mySmtpClient.UseDefaultCredentials = false;
                System.Net.NetworkCredential basicAuthenticationInfo = new
                   System.Net.NetworkCredential("");
                mySmtpClient.Credentials = basicAuthenticationInfo;

                // add from,to mailaddresses
                MailAddress from = new MailAddress("nodesk@inholland-project.nl", "NoDesk_Service");
                MailAddress to = new MailAddress(Email, Email);
                MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                // add ReplyTo
                MailAddress replyto = new MailAddress("nodesk@inholland-project.nl");
                myMail.ReplyToList.Add(replyto);

                // set subject and encoding
                myMail.Subject = "NoDesk - PASSWORD RESET";
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                myMail.Body = "Hi, here is your 6 digit Authorization code for a Password reset. <br> Authcode: "+AuthCode+" .";
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

        //check if Email entered exists.
        public bool EmailExists(string Email)
        {
            //check if email exists in database
            //bool EmailExists = false;

            ////if email exists return true
            //if (EmailExists)
            //{
            //    return EmailExists;
            //}
            ////else return false
            //else if (EmailExists)
            //{
            //    return EmailExists;
            //}
            ////return false if something goes wrong.
            //return false;
            return true;
        }

        //insert changed password into database
        public bool InsertPassword(string Password)
        {
            //go to dao
           return DAO_PassReset.InsertPassword(User_email,Password);
        }
    }
}
