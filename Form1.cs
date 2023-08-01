using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainTicketSalesAutomation.Helpers;
using TrainTicketSalesAutomation.Models;

namespace TrainTicketSalesAutomation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Route> routes;
        DateTime currentDate = DateTime.Now;
        DateTime useDate;
        Form2 form2;
        private void Form1_Load(object sender, EventArgs e)
        {
            useDate = currentDate;
            lblDate.Text = useDate.ToShortDateString();
            routes = Helper.CreateRoutes();
            form2 = new Form2(routes, this);
        }

        private void ListControl()
        {
            lblDate.Visible = btnNext.Visible = btnPrevious.Visible = true;
            Size buttonSize = new Size(90, 40);
            int buttonX = 510;
            int buttonY = 380;
            for (int i = 0; i < 2; i++)
            {
                Button button = new Button();
                button.Text = routes[i].sessions[i].time;
                button.Location = new Point(buttonX, buttonY);
                button.Size = buttonSize;
                button.Tag = i;
                button.Click += new EventHandler(button_Click);
                this.Controls.Add(button);
                buttonY += 50;
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string departureCity = cmbDeparture.Text;
            string destinationCity = cmbDestination.Text;
            string sessionTime = button.Text;
            string sessionDate = lblDate.Text;
            if(DateTime.Parse($"{sessionDate} {sessionTime}") < DateTime.Now)
            {
                MessageBox.Show("You missed the selected expedition, please choose another expedition.");
                return;
            }
            this.Hide();
            form2.Show();
            form2.ListDetail(departureCity,destinationCity,sessionTime,sessionDate);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDeparture.Text == "")
                    MessageBox.Show("Please select the departure city!");
                else if (cmbDestination.Text == "")
                    MessageBox.Show("Please select the destination city!");
                else
                {
                    ListControl();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void cmbDeparture_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbDeparture.Text == "Istanbul")
            {
                cmbDestination.Items.Clear();
                cmbDestination.Items.Add("Eskisehir");
                cmbDestination.Items.Add("Malatya");
            }
            else if (cmbDeparture.Text == "Eskisehir")
            {
                cmbDestination.Items.Clear();
                cmbDestination.Items.Add("Istanbul");
                cmbDestination.Items.Add("Malatya");
            }
            else if (cmbDeparture.Text == "Malatya")
            {
                cmbDestination.Items.Clear();
                cmbDestination.Items.Add("Istanbul");
                cmbDestination.Items.Add("Eskisehir");
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            useDate = useDate.AddDays(1);
            lblDate.Text = useDate.ToShortDateString();
            btnPrevious.Enabled = true;
            if(currentDate.AddDays(2) == useDate)
                btnNext.Enabled = false;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            useDate = useDate.AddDays(-1);
            lblDate.Text = useDate.ToShortDateString();
            btnNext.Enabled = true;
            if(currentDate == useDate)
                btnPrevious.Enabled = false;
        }
    }
}
