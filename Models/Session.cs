﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTicketSalesAutomation.Models
{
    public class Session
    {
        public Session()
        {
            SetDefaultChairs();
        }
        public string date { get; set; }
        public string time { get; set; }
        public List<Chair> chairs { get; set; }

        private void SetDefaultChairs()
        {
            chairs = new List<Chair>();
            string[] wagons = {"1","2","3"};
            string[] rows = { "a", "b", "c", "d" };
            string[] numbers = { "1", "2", "3", "4", "5", "6" };
            foreach (string wagon in wagons)
            {
                foreach (string row in rows)
                {
                    foreach (string number in numbers)
                    {
                        Chair chair = new Chair(wagon, row, number);
                        chairs.Add(chair);
                    }
                }
            }
        }
    }
}
