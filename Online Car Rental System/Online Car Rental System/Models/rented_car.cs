using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Car_Rental_System.Models
{
    public class rented_car
    {
        public int ID { get; set; }
        public int days_num { get; set; }
        public String payment_type { get; set; }
        public Car car_fk { get; set; }
        public int? car_fkID { get; set; }
        public Client clint { get; set; }
        public int? clintID { get; set; }

    }
}