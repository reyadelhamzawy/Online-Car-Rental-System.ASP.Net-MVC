
using Online_Car_Rental_System.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Car_Rental_System.Controllers
{

    public class CarsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Cars
        public ActionResult Index()
        {
            var cars = db.Cars;
            return View(cars);
        }

        public ActionResult Details(int id)
        {
            var data = db.Cars.SingleOrDefault(c => c.ID == id);
            return View(data);
        }

        /**/

        [HttpGet]
        public ActionResult Rent(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Rent(rented_car car, int? carid, string payment)
        {
            //var car_data = db.Cars.SingleOrDefault(c => c.ID == carid);
            //var user_data = db.Clients.SingleOrDefault(c => c.ID == userid);
            //< input type = "hidden" name = "userid" value = @Session["client_id"] >
            car.clintID = (int)Session["client_id"];
            car.payment_type = payment;
            car.car_fkID = carid;

            db.rented_car.Add(car);
            db.SaveChanges();

            var cardata = db.Cars.SingleOrDefault(x => x.ID == carid);
            cardata.ownerClientID = (int)Session["client_id"];
            db.Entry(cardata).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("index");
        }

        /**/
    }
}