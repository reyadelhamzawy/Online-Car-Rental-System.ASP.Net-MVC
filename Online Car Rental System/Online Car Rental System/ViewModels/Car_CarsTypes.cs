using Online_Car_Rental_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Car_Rental_System.ViewModels
{
    public class Car_CarsTypes
    {
        public Car Car { get; set; }
        public IEnumerable<CarsTypes> CarsTypes { get; set; }
    }
}