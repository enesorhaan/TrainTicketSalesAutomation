using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainTicketSalesAutomation.Models;

namespace TrainTicketSalesAutomation
{
    public partial class Form2 : Form
    {
        public Form2(List<Route> _routes,Form1 _form1)
        {
            InitializeComponent();
            routes = _routes;
            form1 = _form1;
        }
        List<Route> routes;
        Form1 form1;
        Route selectedRoute;
        Session selectedSession;

        public void ListDetail(string _departure,string _destination,string _time,string _date)
        {
            int routeIndex = 0;
            if(_departure == "Istanbul")
            {
                if (_destination == "Eskisehir") 
                    routeIndex = 0;
                else
                    routeIndex = 2;
            }
            else if(_departure == "Eskisehir")
            {
                if (_destination == "Istanbul")
                    routeIndex = 1;
                else
                    routeIndex = 4;
            }
            else
            {
                if(_destination == "Istanbul")
                    routeIndex = 3;
                else
                    routeIndex = 5;
            }
            selectedRoute = routes[routeIndex];
            selectedSession = selectedRoute.sessions.Find(s => s.time == _time && s.date == _date);
            lblTime.Text = $"{_date} - {_time}";
            lblDuration.Text = selectedRoute.minute;
            lblPayment.Text = selectedRoute.price.ToString() + " TL";
            lblTrainType.Text = selectedRoute.type.ToString();
            lblRouteName.Text = selectedRoute.routeName;
            CheckChairsStatus();
        }

        private void CheckChairsStatus()
        {
            foreach (Control item in grbChairs.Controls)
            {
                if (item is Button)
                {
                    string row = item.Tag.ToString();
                    string number = item.Text;
                    item.Enabled = true;
                    foreach (Chair chair in selectedSession.chairs)
                    {
                        if(chair.row == row && chair.number == number)
                        {
                            if (chair.status)
                            {
                                item.BackColor = Color.DarkRed;
                                item.Enabled = false;
                            }
                            else
                            {
                                item.BackColor = Color.LightGreen;
                            }
                            break;
                        }
                    }
                }
            }
        }

        List<Chair> chairs = new List<Chair>();
        private void button24_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string row = button.Tag.ToString();
            string number = button.Text;
            Chair chair = selectedSession.chairs.Find(c => c.row == row && c.number == number);
            if(button.BackColor.Name != "Blue")
            {
                chairs.Add(chair);
                button.BackColor = Color.Blue;
            }
            else
            {
                chairs.Remove(chair);
                button.BackColor = Color.LightGreen;
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if(chairs.Count == 0)
            {
                MessageBox.Show("Please select at least one seat!");
                return;
            }
            Sales sales = new Sales();
            sales.routeName = selectedRoute.routeName;
            sales.count = chairs.Count;
            sales.sessionTime = $"{selectedSession.date} - {selectedSession.time}";
            sales.totalPrice = CalculatePrice();

            foreach (Chair chair in chairs)
            {
                chair.status = true;
            }

            MessageBox.Show(sales.ToString());
            ChangePage();
        }

        private void ChangePage()
        {
            cbBusiness.Checked = cbExtraLuggage.Checked = cbMeal.Checked = false;
            chairs.Clear();
            this.Hide();
            form1.Show();
        }

        private decimal CalculatePrice()
        {
            decimal price = selectedRoute.price * chairs.Count;
            if (cbBusiness.Checked)
                price += 60;
            if (cbExtraLuggage.Checked)
                price += 20;
            if (cbMeal.Checked)
                price += 40;
            return price;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ChangePage();
        }
    }
}
