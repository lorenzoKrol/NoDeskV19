using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TGG_Model;
using TGG_Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace TGG_Login
{
    public partial class Gardern_Group_desk : Form
    {
        private Ticket_Service ticket_Service;
        private ListViewColumnSorter lvwColumnSorter;
        private User_Service user_service;
        private Notifications_Service Notifications_Service = new Notifications_Service();
        private User loggedin_user;
        List<string> emaillist;
        public Gardern_Group_desk(User user)
        {
            InitializeComponent();
            //the user who is logged in
            this.loggedin_user = user;
            ticket_Service = new Ticket_Service();

            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView_incidents.ListViewItemSorter = lvwColumnSorter;

            btn_open_ticket.Enabled = false;
            //calls these methods to show overview of all incidents
            DisplayUnresolved();
            DisplayPastDeadline();
            
            
        }
        //shows number of unresolved incidents
        private void DisplayUnresolved()
        {        
            string count = ticket_Service.UnresolvedCount(ticket_Service.GetAllTickets()).ToString();
            string count2 = ticket_Service.IncidentCount(ticket_Service.GetAllTickets()).ToString();

            //sets progress bar min, max and current value of unresolved incidents
            unresolved_ProgressBar.Minimum = 0;
            unresolved_ProgressBar.Value =ticket_Service.UnresolvedCount(ticket_Service.GetAllTickets());
            unresolved_ProgressBar.Maximum = ticket_Service.IncidentCount(ticket_Service.GetAllTickets());
            unresolved_ProgressBar.Text = ticket_Service.UnresolvedCount(ticket_Service.GetAllTickets()).ToString() + "/" + ticket_Service.IncidentCount(ticket_Service.GetAllTickets());
        }
        //shows number if tickets that are past deadline and unresolved
        private void DisplayPastDeadline()
        {

            string count1 = ticket_Service.PastDeadlineCount(ticket_Service.GetAllTickets()).ToString();
            string count2 = ticket_Service.IncidentCount(ticket_Service.GetAllTickets()).ToString();

            past_deadline_circularProgressBar.Minimum = 0;
            past_deadline_circularProgressBar.Value = ticket_Service.PastDeadlineCount(ticket_Service.GetAllTickets());
            past_deadline_circularProgressBar.Maximum = ticket_Service.IncidentCount(ticket_Service.GetAllTickets());
            past_deadline_circularProgressBar.Text = ticket_Service.PastDeadlineCount(ticket_Service.GetAllTickets()).ToString()+"/"+ticket_Service.IncidentCount(ticket_Service.GetAllTickets());
            
        }
        //shows list of all incidents
        private void Show_list_btn_Click(object sender, EventArgs e)
        {
            Dashboard_panel.Hide();
            create_ticket_Panel.Hide();
            panel_incident_management.Show();

            PopulateDashboardIncidentList();
            PopulateDashboardIncidentList_Solved();
        }

        // populates listview with tickets
        private void PopulateDashboardIncidentList()
        {
            listView_incidents.Clear();

            listView_incidents.View = View.Details;
            ColumnHeader columnheader;// Used for creating column headers.

                //creating a list with column names
                List<string> columns = new List<string>();
                columns.Add("Requested By");
                columns.Add("Subject");
                columns.Add("Description");
                columns.Add("Status");
                columns.Add("Priority");
                columns.Add("Request Date");
                columns.Add("Deadline");
                columns.Add("Incident type");

            // Create some column headers for the data. 
            foreach (string col in columns)
                {
                    columnheader = new ColumnHeader();
                    columnheader.Text = col;
                    columnheader.Width = 100;
                    columnheader.TextAlign = HorizontalAlignment.Left;
                    this.listView_incidents.Columns.Add(columnheader);
                }

            foreach (Ticket t in ticket_Service.GetAllUnresolvedTickets(ticket_Service.GetAllTickets()))
            {
                ListViewItem li = new ListViewItem(t.GetRequestedBy());
                li.SubItems.Add(t.GetSubject());
                li.SubItems.Add(t.GetDescription());
                li.SubItems.Add(t.GetStatus().ToString());
                li.SubItems.Add(t.GetPriority().ToString());
                li.SubItems.Add(t.GetRequestDate().ToString("yyyy/MM/dd HH:mm:ss"));
                li.SubItems.Add(t.GetDeadline().ToString("yyyy/MM/dd HH:mm:ss"));
                li.SubItems.Add(t.GetTypeOfIncident());

                li.Tag=t;

                listView_incidents.Items.Add(li);
            }
        }

        private void btn_exportCsv_Click(object sender, EventArgs e)
        {
            string[] arr = null;
            StringBuilder csvContent = new StringBuilder();
            csvContent.AppendLine("Requested By, Subject, Description, Status, Priority, Request Date, Deadline, TypeOfIncident");
            
            foreach (Ticket t in ticket_Service.GetAllUnresolvedTickets(ticket_Service.GetAllTickets()))
            {
                string RequestedBy =t.GetRequestedBy();
                string Subject = (t.GetSubject());
                string Description = (t.GetDescription());
                string Status = (t.GetStatus().ToString());
                string Priority = (t.GetPriority().ToString());
                string RequestDate = (t.GetRequestDate().ToString("yyyy/MM/dd HH:mm:ss"));
                string Deadline = (t.GetDeadline().ToString("yyyy/MM/dd HH:mm:ss"));
                string TypeOfIncident = (t.GetTypeOfIncident());
                arr = new string[] { RequestedBy, Subject, Description, Status, Priority, RequestDate, Deadline, TypeOfIncident };
                csvContent.AppendLine(arr[0] + "," + arr[1] + "," + arr[2] + "," + arr[3] + "," + arr[4] + "," + arr[5] + "," + arr[6] + "," + arr[7]);
            }

            export_IncidentsList_ToCSV(arr, csvContent);
            MessageBox.Show("csv file exported to location: `Documents > IncidentsList`");
        }
        private void export_IncidentsList_ToCSV(string[] arr, StringBuilder csvContent)
        {
            string fileName = System.IO.Path.GetRandomFileName();
            //saving the file in a folder in "Documents" with a random name
            string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string csvPath = documents + @"\IncidentsList";

            if (!(Directory.Exists(csvPath)))
            {
                System.IO.Directory.CreateDirectory(csvPath);
            }

            csvPath += @"\Incidents_List_" + fileName + ".csv";
            File.AppendAllText(csvPath, csvContent.ToString());
        }        

        private void txtBox_filterEmail_TextChanged_1(object sender, EventArgs e)
        {
            if (txtBox_filterEmail.Text == null)
            {
                PopulateDashboardIncidentList();
            }
            else
            {
                PopulateIncidentList_ByEmail(txtBox_filterEmail.Text.ToLower());
            }

        }

        private void PopulateIncidentList_ByEmail(string filter)
        {
            listView_incidents.Clear();
            
            listView_incidents.View = View.Details;
            ColumnHeader columnheader;// Used for creating column headers.
            //creating a list with column names
            List<string> columns = new List<string>();
            columns.Add("Requested By");
            columns.Add("Subject");
            columns.Add("Status");
            columns.Add("Priority");
            columns.Add("Request Date");
            columns.Add("Deadline");

            // Create some column headers for the data. 
            foreach (string col in columns)
            {
                columnheader = new ColumnHeader();
                columnheader.Text = col;
                columnheader.Width = 100;
                columnheader.TextAlign = HorizontalAlignment.Left;
                this.listView_incidents.Columns.Add(columnheader);
            }

            foreach (Ticket t in ticket_Service.GetAllUnresolvedTickets(ticket_Service.GetAllTickets()))
            {
                if (t.GetRequestedBy().ToLower().Contains(filter))
                {
                    ListViewItem li = new ListViewItem(t.GetRequestedBy());
                    li.SubItems.Add(t.GetSubject());
                    li.SubItems.Add(t.GetDescription());
                    li.SubItems.Add(t.GetStatus().ToString());
                    li.SubItems.Add(t.GetPriority().ToString());
                    li.SubItems.Add(t.GetRequestDate().ToString("yyyy/MM/dd HH:mm:ss"));
                    li.SubItems.Add(t.GetDeadline().ToString("yyyy/MM/dd HH:mm:ss"));
                    li.Tag = t;
                    listView_incidents.Items.Add(li);
                }
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
            listView_dashboard_SolvedTickets.Columns.Add("Priority", 100, HorizontalAlignment.Left);
            listView_dashboard_SolvedTickets.Columns.Add("Type", 100, HorizontalAlignment.Left);


            foreach (Ticket t in ticket_Service.GetAllTickets_Solved())
            {
                ListViewItem li = new ListViewItem(t.GetRequestedBy());

                li.SubItems.Add(t.GetRequestDate().ToString("yyyy/MM/dd HH:mm:ss"));
                li.SubItems.Add(t.GetDeadline().ToString("yyyy/MM/dd HH:mm:ss"));
                li.SubItems.Add(t.GetSubject());
                li.SubItems.Add(t.GetDescription());
                li.SubItems.Add(t.GetStatus().ToString());
                li.SubItems.Add(t.GetPriority().ToString());
                li.SubItems.Add(t.GetTypeOfIncident());


                li.Tag = t;

                listView_dashboard_SolvedTickets.Items.Add(li);
            }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if dasboard menu item is clicked display dashboard panel and hide the rest
            ShowPanel("dashboard");
        }

        private void incidentManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanel("incident_menu");
        }
        // this method shows and hides panels
        private void ShowPanel(string panelName)
        {
           if (panelName=="dashboard")
            {
                dashboardToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
                incidentManagementToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
                userManagementToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;

                btn_open_ticket.Enabled = false;
                ClearTicketInfo();
                panel_ticketOverview.Hide();
                create_ticket_Panel.Hide();
                panel_incident_management.Hide();
                Dashboard_panel.Show();
            }
            else if(panelName == "incident_menu")
            {
                incidentManagementToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
                dashboardToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
                userManagementToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;

                btn_open_ticket.Enabled = false;
                ClearTicketInfo();
                panel_ticketOverview.Hide();
                Dashboard_panel.Hide();
                create_ticket_Panel.Hide();
                panel_incident_management.Show();
                panel_user_management.Hide();
                PopulateDashboardIncidentList();
            }
        }
        //useless buttons we accidently pressed but no code belongs to.
        private void Dash_back_btn_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void listView_dashboard_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
        // displays date and time for every tick of the clock 
        private void Clock_Tick(object sender, EventArgs e)
        {
            lbl_Clock_create_ticket.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            time_clock_display2_lbl.Text= DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
        }
        // starts the clock and sets it's ticker to every second
        private void Gardern_Group_desk_Load(object sender, EventArgs e)
        {

            Clock.Interval = 1000;
            Clock.Start();
            
        }
       //calls method from services layer and provides it with the information needed to create a ticket
        private void Create_ticket_btn_Click(object sender, EventArgs e)
        {
            if (type_name_textBox.Text!=""&& ticket_subject_textBox.Text!="" && ticket_description_TextBox.Text!=""&& select_priority_ComboBox.Text!=""&& add_incident_type_TextBox.Text!=""&& select_priority_ComboBox.Text!="")
            {
                create_ticket_Panel.Hide();
                panel_incident_management.Show();

                ticket_Service.WriteTicket_service(type_name_textBox.Text, ticket_deadlineTimePicker.Value, DateTime.Now, ticket_subject_textBox.Text, ticket_description_TextBox.Text, Status.Pending, select_priority_ComboBox.Text, add_incident_type_TextBox.Text);

                type_name_textBox.Clear();
                ticket_deadlineTimePicker.Value = DateTime.Now;
                ticket_subject_textBox.Clear();
                ticket_description_TextBox.Clear();
                add_incident_type_TextBox.Clear();

                DisplayUnresolved();
                DisplayPastDeadline();
                PopulateDashboardIncidentList();
            }
            else 
            {
                MessageBox.Show("Please check and fill any missing field");
            }
            
        }
        //return user to incident managemnt page and cancels creation of ticket
        private void Btn_cancel_of_create_ticket_Click(object sender, EventArgs e)
        {
            
            create_ticket_Panel.Hide();
            panel_incident_management.Show();

            type_name_textBox.Clear();
            ticket_deadlineTimePicker.Value = DateTime.Now;
            ticket_subject_textBox.Clear();
            ticket_description_TextBox.Clear();
            add_incident_type_TextBox.Clear();

            PopulateDashboardIncidentList();
        }

        private void Go_create_incident_BTN_Click(object sender, EventArgs e)
        {
            Dashboard_panel.Hide();
            panel_incident_management.Hide();
            create_ticket_Panel.Show();
        }
        
        private void listView_incidents_ColumnClick(object sender, ColumnClickEventArgs e)
        {

            ListView myListView = (ListView)sender;

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            myListView.Sort();
        }
        private void label14_Click(object sender, EventArgs e)
        {

        }
        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user_service = new User_Service();
            incidentManagementToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            dashboardToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            userManagementToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            panel_user_management.Show();
            panel_incident_management.Hide();
            panel_ticketOverview.Hide();
            Dashboard_panel.Hide();
            create_ticket_Panel.Hide();
            FillUsers();
            panel_add_edit_user.Hide();
            //check admin status
            if(loggedin_user.Status != "Admin")
            {
                btn_create_user.Hide();
                btn_create_user.Enabled = false;
                btn_delete_user.Hide();
                btn_delete_user.Enabled = false;
            }
        }

        private void FillUsers()
        {
            List<User> userlist = user_service.GetAllUsers();
            listview_users.Clear();
            int id = 1;

            listview_users.View = View.Details;
            ColumnHeader columnheader;// Used for creating column headers.

            //creating a list with column names
            List<string> columns = new List<string>();
            columns.Add("Id");
            columns.Add("Email");
            columns.Add("Name");
            columns.Add("Status");
            //columns.Add("Tickets");

            // Create some column headers for the data. 
            foreach (string col in columns)
            {
                columnheader = new ColumnHeader();
                columnheader.Text = col;
                columnheader.Width = 100;
                columnheader.TextAlign = HorizontalAlignment.Left;
                this.listview_users.Columns.Add(columnheader);
            }

            foreach (User u in userlist)
            {
                ListViewItem li = new ListViewItem(id.ToString());
                li.SubItems.Add(u.Email);
                li.SubItems.Add(u.Name);
                li.SubItems.Add(u.Status);
                
                li.Tag = u;

                listview_users.Items.Add(li);
                id++;
            }
        }
        private void FillUsers_ByEmail(string filter)
        {
            List<User> userlist = user_service.GetAllUsers();
            listview_users.Clear();
            int id = 1;

            listview_users.View = View.Details;
            ColumnHeader columnheader;// Used for creating column headers.

            //creating a list with column names
            List<string> columns = new List<string>();
            columns.Add("Id");
            columns.Add("Email");
            columns.Add("Name");
            columns.Add("Status");
            //columns.Add("Tickets");

            // Create some column headers for the data. 
            foreach (string col in columns)
            {
                columnheader = new ColumnHeader();
                columnheader.Text = col;
                columnheader.Width = 100;
                columnheader.TextAlign = HorizontalAlignment.Left;
                this.listview_users.Columns.Add(columnheader);
            }

            foreach (User u in userlist)
            {
                if (u.Email.ToLower().Contains(filter))
                {
                    ListViewItem li = new ListViewItem(id.ToString());
                    li.SubItems.Add(u.Email);
                    li.SubItems.Add(u.Name);
                    li.SubItems.Add(u.Status);

                    li.Tag = u;

                    listview_users.Items.Add(li);
                    id++;
                }
                
            }
        }
        // turns of clock and prevents program to countinue and run when cloased
        private void Gardern_Group_desk_FormClosing(object sender, FormClosingEventArgs e)
        {
            Clock.Stop();
            System.Environment.Exit(0);

        }
        // opens ticket info page
        private void Btn_open_ticket_Click_1(object sender, EventArgs e)
        {
            
            panel_incident_management.Hide();
            Dashboard_panel.Hide();
            panel_ticketOverview.Show();

            listView_incidents.Refresh();
        }

        private void ListView_incidents_Click(object sender, EventArgs e)
        {

        }

        private void Label16_Click(object sender, EventArgs e)
        {

        }
        //passes all ticket values to ticket info page and deselects previously selected item
        private void listView_incidents_Click(object sender, EventArgs e)
        {
            btn_open_ticket.Enabled = true;

            ClearTicketInfo();

            if (listView_incidents.SelectedItems.Count>0)
            {
                lbl_ticket_info_reportedBy.Text = listView_incidents.SelectedItems[0].SubItems[0].Text;
                lbl_ticket_info_subject.Text = listView_incidents.SelectedItems[0].SubItems[1].Text;
                lbl_ticket_info_description.Text = listView_incidents.SelectedItems[0].SubItems[2].Text;
                lbl_ticket_info_status.Text = listView_incidents.SelectedItems[0].SubItems[3].Text;
                lbl_ticket_info_priority.Text = listView_incidents.SelectedItems[0].SubItems[4].Text;
                lbl_ticket_info_deadline.Text = listView_incidents.SelectedItems[0].SubItems[6].Text;
                lbl_ticket_info_whenTicketWasSbmt.Text = listView_incidents.SelectedItems[0].SubItems[5].Text;
                lbl_ticket_tyoe_of_incident.Text = listView_incidents.SelectedItems[0].SubItems[7].Text;
            }
        }
        //clears all info of ticket
        private void ClearTicketInfo()
        {

            lbl_ticket_info_reportedBy.Text ="";
            lbl_ticket_info_subject.Text = "";
            lbl_ticket_info_description.Text = "";
            lbl_ticket_info_status.Text = "";
            lbl_ticket_info_priority.Text = "";
            lbl_ticket_info_deadline.Text = "";
            lbl_ticket_info_whenTicketWasSbmt.Text = "";
            lbl_ticket_tyoe_of_incident.Text = "";

        }

        private void btn_Incidentmanagement_ShowSolvedTickets_Click(object sender, EventArgs e)
        {
            listView_incidents.Hide();
            listView_dashboard_SolvedTickets.Show();
            PopulateDashboardIncidentList_Solved();
            btn_incidentmangement_ShowAllTickers.Show();
            btn_Incidentmanagement_ShowSolvedTickets.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView_incidents.Show();
            listView_dashboard_SolvedTickets.Hide();
            btn_incidentmangement_ShowAllTickers.Hide();
            btn_Incidentmanagement_ShowSolvedTickets.Show();
        }

        private void btn_Ticketstatistics_UpdateTicketStatus_Click(object sender, EventArgs e)
        {
            try
            {
                string updatedticketstatus = comboBox_change_ticket_status.SelectedItem.ToString();
                string UserEmail = lbl_ticket_info_reportedBy.Text;
                string TicketSubject = lbl_ticket_info_subject.Text;

                ticket_Service.UpdateTicketStatus(TicketSubject, updatedticketstatus);

                panel_ticketOverview.Hide();
                panel_incident_management.Show();

                Notifications_Service notifications = new Notifications_Service();
                notifications.CreateEmail(UserEmail, updatedticketstatus);

                MessageBox.Show("Your ticket status has been changed to " + updatedticketstatus, "Success!!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong with changing you ticket status. Make sure you have a stable internet connection and try again.", "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }


        private void txtBox_filterEmail_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void btn_create_user_Click(object sender, EventArgs e)
        {
           
            panel_add_edit_user.Show();
            if (listview_users.SelectedItems.Count == 1)
            {
                User selectedUser = user_service.GetUser(listview_users.SelectedItems[0].SubItems[1].Text);
                //fill text box with listview data
                lbl_user_management_original_email.Text = listview_users.SelectedItems[0].SubItems[1].Text;
                txtbox_user_management_email.Text = listview_users.SelectedItems[0].SubItems[1].Text;
                txtbox_user_management_name.Text = listview_users.SelectedItems[0].SubItems[2].Text;
                //get password from database beceause not stored in listview
                txtbox_user_management_password.Text = selectedUser.Password;
                txtbox_user_management_status.Text = listview_users.SelectedItems[0].SubItems[3].Text;
                //user is selected for edit, so add not allowed
                btn_user_management_add.Enabled = false;
            }
            else if(listview_users.SelectedItems.Count > 1)
            {
                MessageBox.Show("Oops, you are not able to edit multiple users at the same time. please make sure you have one user selected.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                btn_user_management_edit.Enabled = false;
            }
        }

        private void btn_user_management_edit_Click(object sender, EventArgs e)
        {
            try
            {
                // fill variables with user input data
                string originalEmail = lbl_user_management_original_email.Text;
                string email = txtbox_user_management_email.Text;
                string name = txtbox_user_management_name.Text;
                string password = txtbox_user_management_password.Text;
                string status = txtbox_user_management_status.Text;
                user_service.UpdateUser(originalEmail, email, name, password, status);
                //show succes message
                MessageBox.Show("User data has been changed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //hide panel
                panel_add_edit_user.Hide();
                //fill list again
                FillUsers();


                //Send email notification if used is succesfully editted
                Notifications_Service.Email_UserAddEdit(email, name, password, status, "Editted");
            }
            catch (Exception)
            {
                MessageBox.Show("Oops, something went wrong. please try again.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void btn_user_management_add_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtbox_user_management_email.Text;
                string name = txtbox_user_management_name.Text;
                string password = txtbox_user_management_password.Text;
                string status = txtbox_user_management_status.Text;
                user_service.AddUser(email, name, password, status);

                MessageBox.Show("User has been added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //hide panel
                panel_add_edit_user.Hide();
                //fill list again
                FillUsers();

                //Send email notification if used is succesfully added
                Notifications_Service.Email_UserAddEdit(email, name, password, status, "Added");
            }
            catch (Exception)
            {
                MessageBox.Show("Oops, something went wrong. please try again.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btn_delete_user_Click(object sender, EventArgs e)
        {
            try
            {
                if (listview_users.SelectedItems.Count == 1)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete user?", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        string email = listview_users.SelectedItems[0].SubItems[1].Text;
                        user_service.DeleteUser(email);
                        FillUsers();
                        listview_users.SelectedItems.Clear();

                        //Send email notification if used is succesfully added
                        Notifications_Service.Email_UserDelete(email);
                    }
                }
                else
                {
                    MessageBox.Show("Oops, you are not able to delete multiple users at the same time. please make sure you have one user selected.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Oops, something went wrong. please try again.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtbox_filter_user_management_TextChanged(object sender, EventArgs e)
        {
            if (txtbox_filter_user_management.Text == null)
            {
                FillUsers();
            }
            else
            {
                FillUsers_ByEmail(txtbox_filter_user_management.Text);
            }
        }

        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        // Goes back to incident management
        private void View_ticket_GoBack_btn_Click(object sender, EventArgs e)
        {
            panel_ticketOverview.Hide();
            PopulateDashboardIncidentList();
            panel_incident_management.Show();
        }
        // same with the one for the unresolved tickets above but this one for the solved tickets
        private void ListView_dashboard_SolvedTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_open_ticket.Enabled = true;

            ClearTicketInfo();

            if (listView_dashboard_SolvedTickets.SelectedItems.Count > 0)
            {
                lbl_ticket_info_reportedBy.Text = listView_dashboard_SolvedTickets.SelectedItems[0].SubItems[0].Text;
                lbl_ticket_info_subject.Text = listView_dashboard_SolvedTickets.SelectedItems[0].SubItems[1].Text;
                lbl_ticket_info_description.Text = listView_dashboard_SolvedTickets.SelectedItems[0].SubItems[2].Text;
                lbl_ticket_info_status.Text = listView_dashboard_SolvedTickets.SelectedItems[0].SubItems[3].Text;
                lbl_ticket_info_priority.Text = listView_dashboard_SolvedTickets.SelectedItems[0].SubItems[4].Text;
                lbl_ticket_info_deadline.Text = listView_dashboard_SolvedTickets.SelectedItems[0].SubItems[6].Text;
                lbl_ticket_info_whenTicketWasSbmt.Text = listView_dashboard_SolvedTickets.SelectedItems[0].SubItems[5].Text;
                lbl_ticket_tyoe_of_incident.Text = listView_dashboard_SolvedTickets.SelectedItems[0].SubItems[7].Text;
            }
        }
    }
}
