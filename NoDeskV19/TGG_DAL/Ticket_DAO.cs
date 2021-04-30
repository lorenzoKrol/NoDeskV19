using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGG_DAL;
using TGG_Model;
using MongoDB.Driver;
using MongoDB.Bson;
using NoDesk;
using MongoDB.Driver.Linq;



namespace TGG_DAL
{
    public class Ticket_DAO
    {
        private Config config;

        //constructor sets new connection with database
        public Ticket_DAO()
        {
            config = new Config();
        }
        //returns list to service layer
        public List<Ticket> db_TicketsList()
        {
            return GetALLTicketsList();
        }

        //returns list to service layer
        public List<Ticket> db_TicketsList_Solved()
        {
            return GetTicketList_Solved();
        }

        // gets all tickets from database 
        private List<Ticket> GetALLTicketsList()
        {
            //create ticket list that will returned
            List<Ticket> tickets = new List<Ticket>();
            
            //sets connection with database and ticket collection
            var database = config.dbClient.GetDatabase("NoDesk");
            var collection = database.GetCollection<BsonDocument>("Tickets");

            //gets all documents from collection and stores them in a list
            var filter = Builders<BsonDocument>.Filter.Empty;
            var result = collection.Find(filter).ToList();
            try
            {
                foreach (var r in result)
                {
                    //stores each ticket in ticket object and adds it to ticket list
                    Ticket ticket = new Ticket(r.GetValue("_id").AsObjectId, r.GetValue("requestedBy").AsString, r.GetValue("deadline").ToUniversalTime(), r.GetValue("requestDate").ToUniversalTime(), r.GetValue("subject").AsString, r.GetValue("description").AsString, ConvertStatus(r.GetValue("status").AsString), SetTicketPriority(r.GetValue("priority").AsString), r.GetValue("type").AsString);
                    tickets.Add(ticket);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error : " + e);//added exception code
            }
            //list of tickets is returned
            return tickets;
        }

        // gets all tickets from database 
        private List<Ticket> GetTicketList_Solved()
        {
            //create ticket list that will returned
            List<Ticket> tickets = new List<Ticket>();

            //sets connection with database and ticket collection
            var database = config.dbClient.GetDatabase("NoDesk");
            var collection = database.GetCollection<BsonDocument>("Tickets");

            //gets all documents from collection and stores them in a list
            var filter = Builders<BsonDocument>.Filter.Empty;
            var result = collection.Find(filter).ToList();

            //stores each ticket in ticket object and adds it to ticket list
            foreach (var r in result)
            {
                if (r.GetValue("status") == "Solved")
                {
                    Ticket ticket = new Ticket(r.GetValue("_id").AsObjectId, r.GetValue("requestedBy").AsString, r.GetValue("deadline").ToUniversalTime(), r.GetValue("requestDate").ToUniversalTime(), r.GetValue("subject").AsString, r.GetValue("description").AsString, ConvertStatus(r.GetValue("status").AsString), SetTicketPriority(r.GetValue("priority").AsString), r.GetValue("type").AsString);
                    tickets.Add(ticket);
                }
            }
            //list of tickets is returned
            return tickets;
        }

        // converts string data from db into status enum and returns it
        private Status ConvertStatus(string s)
        {
            Status state=Status.Pending;

            if (s=="Solved")
            {
                return state = Status.Solved;
            }
            return state;
        }
        // writes new ticket in database
        public void DB_Write_ticket(Ticket ticket)
        {
            var database = config.dbClient.GetDatabase("NoDesk");
            var collection = database.GetCollection<BsonDocument>("Tickets");

            var document = new BsonDocument
            {
                {"_id",ticket.GetId()},
                {"requestedBy",ticket.GetRequestedBy().ToString()},
                {"deadline",ticket.GetDeadline()},
                {"requestDate",ticket.GetRequestDate()},
                {"subject",ticket.GetSubject().ToString()},
                {"description",ticket.GetDescription().ToString()},
                {"status",ticket.GetStatus().ToString()},
                {"priority",ticket.GetPriority().ToString() },
                {"type",ticket.GetTypeOfIncident().ToString() }
            };
            try
            {
                collection.InsertOneAsync(document);
            }
            catch (Exception e)
            {
                throw new Exception("Error : " + e);//added exception code
            }   
        }
        //converts priority string from database to enum Priority for ticket
        private Priority SetTicketPriority(string input)
        {
            Priority priority = new Priority();

            if (input == "VeryLow")
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
            else if (input == "VeryHigh")
            {
                priority = Priority.VeryHigh;
            }
            return priority;
        }
        public void UpdateTicketStatus(string TicketSubject, string status)
        {
            //select database and collection
            var database = config.dbClient.GetDatabase("NoDesk");
            var collection = database.GetCollection<BsonDocument>("Tickets");
            //create filter
            var filter = Builders<BsonDocument>.Filter.Eq("subject", TicketSubject);
            //update in database
            var update = Builders<BsonDocument>.Update.Set("status", status);
            collection.UpdateOne(filter, update);
        }
    }
}
