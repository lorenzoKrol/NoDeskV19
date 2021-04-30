using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGG_Model;
using TGG_Service;

namespace TGG_Login
{
    public partial class Dashboard : Form
    {
        private Ticket_Service ticket_Service;
        public Dashboard()
        {
            InitializeComponent();

            ticket_Service = new Ticket_Service();
            
            //calls these methods to show overview of all incidents
            DisplayUnresolved();
            DisplayPastDeadline();
        }
        //shows number of unresolved incidents
        private void DisplayUnresolved()
        {        
            string count = ticket_Service.UnresolvedCount(ticket_Service.GetAllTickets()).ToString();
            string count2 = ticket_Service.IncidentCount(ticket_Service.GetAllTickets()).ToString();

            unresolved_incidents_TXT.Text = count + "/" + count2;
        }
        //shows number if tickets that are past deadline and unresolved
        private void DisplayPastDeadline()
        {

            string count1 = ticket_Service.PastDeadlineCount(ticket_Service.GetAllTickets()).ToString();
            string count2 = ticket_Service.IncidentCount(ticket_Service.GetAllTickets()).ToString();

            past_deadline_TXT.Text = count1 + "/" + count2;
        }
        //shows list of all incidents
        private void Show_list_btn_Click(object sender, EventArgs e)
        {
            Dashboard_panel.Hide();
            panel_dashboardViewTicketList.Show();
            PopulateDashboardIncidentList();
            PopulateDashboardIncidentList_Solved();
        }
        // populates listview with tickets
        private void PopulateDashboardIncidentList()
        {
            listView_dashboard.Clear();

            listView_dashboard.View = View.Details;

            listView_dashboard.Columns.Add("Requested By", 100, HorizontalAlignment.Left);
            listView_dashboard.Columns.Add("Request Date", 100, HorizontalAlignment.Left);
            listView_dashboard.Columns.Add("Deadline", 100, HorizontalAlignment.Left);
            listView_dashboard.Columns.Add("subject", 100, HorizontalAlignment.Left);
            listView_dashboard.Columns.Add("description", 100, HorizontalAlignment.Left);
            listView_dashboard.Columns.Add("status", 100, HorizontalAlignment.Left);

            foreach (Ticket t in ticket_Service.GetAllTickets())
            {
                ListViewItem li = new ListViewItem(t.GetRequestedBy());

                li.SubItems.Add(t.GetRequestDate().ToString("yyyy/MM/dd HH:mm:ss"));
                li.SubItems.Add(t.GetDeadline().ToString("yyyy/MM/dd HH:mm:ss"));
                li.SubItems.Add(t.GetSubject());
                li.SubItems.Add(t.GetDescription());
                li.SubItems.Add(t.GetStatus().ToString());

                li.Tag=t;

                listView_dashboard.Items.Add(li);
            }
        }

        // populates listview with tickets
        private void PopulateDashboardIncidentList_Solved()
        {
            listView_dashboard_SolvedTickets.Clear();

            listView_dashboard_SolvedTickets.View = View.Details;

            listView_dashboard_SolvedTickets.Columns.Add("Requested By", 100, HorizontalAlignment.Left);
            listView_dashboard_SolvedTickets.Columns.Add("Request Date", 100, HorizontalAlignment.Left);
            listView_dashboard_SolvedTickets.Columns.Add("Deadline", 100, HorizontalAlignment.Left);
            listView_dashboard_SolvedTickets.Columns.Add("subject", 100, HorizontalAlignment.Left);
            listView_dashboard_SolvedTickets.Columns.Add("description", 100, HorizontalAlignment.Left);
            listView_dashboard_SolvedTickets.Columns.Add("status", 100, HorizontalAlignment.Left);

            foreach (Ticket t in ticket_Service.GetAllTickets_Solved())
            {
                ListViewItem li = new ListViewItem(t.GetRequestedBy());

                li.SubItems.Add(t.GetRequestDate().ToString("yyyy/MM/dd HH:mm:ss"));
                li.SubItems.Add(t.GetDeadline().ToString("yyyy/MM/dd HH:mm:ss"));
                li.SubItems.Add(t.GetSubject());
                li.SubItems.Add(t.GetDescription());
                li.SubItems.Add(t.GetStatus().ToString());

                li.Tag = t;

                listView_dashboard_SolvedTickets.Items.Add(li);
            }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if dasboard menu item is clicked display dashboard panel and hide the rest
            Dashboard_panel.Show();
            panel_dashboardViewTicketList.Hide();
        }

        private void incidentManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if incident management menu item is clicked display panel and hide the rest
            panel_dashboardViewTicketList.Show();
            Dashboard_panel.Hide();

            //populate lists if panel gets selected
            PopulateDashboardIncidentList();
            PopulateDashboardIncidentList_Solved();
        }



        //useless buttons we accidently pressed but no code belongs to.
        private void Dash_back_btn_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void listView_dashboard_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
