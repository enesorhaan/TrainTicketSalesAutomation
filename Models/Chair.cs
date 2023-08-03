using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTicketSalesAutomation.Models
{
    public class Chair
    {
        public Chair(string _wagon, string _row,string _number)
        {
            wagon = _wagon;
            row = _row;
            number = _number;
        }
        public string wagon { get; set; }
        public string row { get; set; }
        public string number { get; set; }
        public bool status { get; set; }
        public bool check { get; set; }

    }
}
