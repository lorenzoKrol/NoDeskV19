using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGG_DAL;
using TGG_Model;


namespace TGG_Service
{
    public class Ticket_Service
    {
        private Ticket_DAO DAO_Tickets = new Ticket_DAO();

        //calls method in dao layer to get all incident tickets
        public List<Ticket> GetAllTickets()
        {
            try
            {
                return DAO_Tickets.db_TicketsList();
            }
            catch (Exception e)
            {
                throw new Exception(" " + e.Message);
            }
            
        }
        //returns all unresolved tickets from a list of tickets
        public List<Ticket> GetAllUnresolvedTickets(List<Ticket> all_tickets)
        {
            List<Ticket> tickets = new List<Ticket>();

            foreach(Ticket t in all_tickets)
            {
                if (t.GetStatus() == Status.Pending || t.GetStatus() == Status.PastDeadline)
                {
                    tickets.Add(t);
                }
            }
            return tickets;
        }
        //calls method in dao layer to get all incident tickets
        public List<Ticket> GetAllTickets_Solved()
        {
            try
            {
                return DAO_Tickets.db_TicketsList_Solved();
            }
            catch (Exception e)
            {
                throw new Exception(" " + e.Message);
            }

        }
        // returns total count of incident tickets
        public int IncidentCount(List<Ticket> incidents)
        {
            int count=incidents.Count;
            
            return count;
        }
        //returns total count of unresolved tickets
        public int UnresolvedCount(List<Ticket> incidents)
        {
            int count = 0;
            foreach (Ticket t in incidents)
            {
                if (t.GetStatus()==Status.Pending||t.GetStatus()==Status.PastDeadline)
                {
                    count++;
                }
               
            }
            return count;
        }
        //returns total count of tickets which are past their deadline
        public int PastDeadlineCount(List<Ticket> incidents)
        {
            int count = 0;
            foreach (Ticket t in incidents)
            {
                if (t.GetStatus() == Status.PastDeadline)
                {
                    count++;
                }

            }
            return count;
        }
        //creates a ticket and then passes it to database layer from where it is written in database
        public void WriteTicket_service(string requestedBy, DateTime deadline, DateTime requestDate, string subject, string description, Status status, string priority,string typeOfIncident)
        {
            //class object that creates id for ticket
            IdGenerator id = new IdGenerator();

            Ticket ticket = new Ticket(id.GetId(), requestedBy, deadline, requestDate, subject, description, status, SetTicketPriority(priority), typeOfIncident);

            try
            {
                DAO_Tickets.DB_Write_ticket(ticket);
            }
            catch (Exception e)
            {
                throw new Exception(" " + e.Message);
            }
        }
        //converts string input into enum Priority value 
        private Priority SetTicketPriority(string input)
        {
            Priority priority= new Priority();

            if (input=="Very Low")
            {
                priority = Priority.VeryLow;
            }
            else if (input == "Low")
            {
                priority = Priority.Low;
            }
            else if (input == "Normal")
            {
                priority = Priority.Normal;
            }
            else if (input == "High")
            {
                priority = Priority.High;
            }
            else if (input == "Very High")
            {
                priority = Priority.VeryHigh;
            }
            return priority;
        }
        // 
        public void UpdateTicketStatus(string TicketSubject, string status)
        {
            DAO_Tickets.UpdateTicketStatus(TicketSubject, status);
        }
    }
}
