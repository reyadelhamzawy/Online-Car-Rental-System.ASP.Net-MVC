using Online_Car_Rental_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Car_Rental_System.ViewModels
{
    public class ClientPreferTypes
    {
        public Client client { get; set; }
        public Car car { get; set; }
        public IEnumerable<CarsTypes> ClientPreferType { get; set; }
        public IEnumerable<Car> cars { get; set; }

    }
}