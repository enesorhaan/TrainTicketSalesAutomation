using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTicketSalesAutomation.Enums;
using TrainTicketSalesAutomation.Models;

namespace TrainTicketSalesAutomation.Helpers
{
    public class Helper
    {
        public static List<Route> CreateRoutes()
        {
            return new List<Route>()
            {
                new Route()
                {
                    routeName = "Istanbul - Eskisehir",
                    type = TrainType.High_Speed_Train,
                    minute = "3 hours 35 minutes",
                    price = 200,
                },
                new Route()
                {
                    routeName = "Eskisehir - Istanbul",
                    type = TrainType.High_Speed_Train,
                    minute = "3 hours 35 minutes",
                    price = 200,
                },
                new Route()
                {
                    routeName = "Istanbul - Malatya",
                    type = TrainType.Optima,
                    minute = "12 hours 13 minutes",
                    price = 450,
                },
                new Route()
                {
                    routeName = "Malatya - Istanbul",
                    type = TrainType.Optima,
                    minute = "12 hours 13 minutes",
                    price = 450,
                },
                new Route()
                {
                    routeName = "Eskisehir - Malatya",
                    type = TrainType.High_Speed_Train,
                    minute = "8 hours 52 minutes",
                    price = 330,
                },
                new Route()
                {
                    routeName = "Malatya - Eskisehir",
                    type = TrainType.High_Speed_Train,
                    minute = "8 hours 52 minutes",
                    price = 330,
                },
            };
        }
    }
}
