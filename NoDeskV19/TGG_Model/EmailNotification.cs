using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGG_Model
{
    public class EmailNotification : Notification
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public EmailNotification(string ToEmail, string Subject, string Message)
        {
            this.ToEmail = ToEmail;
            this.Subject = Subject;
            this.Message = Message;
        }
    }
}
