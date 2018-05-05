using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Car_Rental_System.Models
{
    public class Car
    {
        //basic info
        public int ID { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int numOfChairs { get; set; }
        public float rentAmount { get; set; }
        public string Color { get; set; }
        public string Img { get; set; }

        //forgien key fron Client table
        //the relation between tow class in one to many from client to car 
        //because the client can rent many cars but hte car rened by one client
        public Client ownerClient { get; set; }
        public int? ownerClientID { get; set; }
    }
}