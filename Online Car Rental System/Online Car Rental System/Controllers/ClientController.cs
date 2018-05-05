using Online_Car_Rental_System.Models;
using Online_Car_Rental_System.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Online_Car_Rental_System.Controllers
{
    public class ClientController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult home()
        {
            return View();
        }

        [HttpGet]
        public ActionResult register()
        {
            var cartype = db.CarType.ToList();
            ClientPreferTypes client = new ClientPreferTypes
            {
                ClientPreferType = cartype
            };
            return View(client);
        }

        [HttpPost]
        public ActionResult register(ClientPreferTypes clien)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(clien.client);
                db.SaveChanges();

                return Json(new { result = 1 });
            }

            return Json(new { result = 0 });

            /*if (!ModelState.IsValid)
            {
                var cartype = db.CarType.ToList();
                clien.ClientPreferType = cartype;
                return View("register", clien);
            }

            db.Clients.Add(clien.client);
            db.SaveChanges();
            return RedirectToAction("Index");*/
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Client client)
        {
            var user = db.Clients.Where(x => x.Email == client.Email && x.password == client.password).FirstOrDefault();
           if (user != null)
            {
                if(user.SSN != 0)
                {
                    Session["client"] = user.Name;
                    Session["client_id"] = user.ID;
                    //return Json(new { result = 1 });
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("LogIn");
                }
                
            }else
            {
                //return Json(new { result = 0 });
                return RedirectToAction("LogIn");
            }
        }

        public ActionResult LogOut()
        {
            Session.Remove("client");
            return RedirectToAction("Index");
        }

        /*Start Reham Code*/
        [HttpGet]
        public ActionResult Category()
        {
            var cartype = db.CarType.ToList();
            var Cars = from m in db.Cars
                       select m;

            ClientPreferTypes client = new ClientPreferTypes
            {
                ClientPreferType = cartype,
                cars = Cars

            };

            return View(client);

        }
        [HttpPost]
        public ActionResult Category(Car car)
        {
            var cartype = db.CarType.ToList();
            var Cars = from m in db.Cars
                       select m;

            if (!(car).Equals(null))
            {
                Cars = Cars.Where(s => s.Name.Contains(car.Name) || s.Type == car.Type ||
                s.numOfChairs == car.numOfChairs || s.Model == car.Model || s.rentAmount == car.rentAmount);

            }
            ClientPreferTypes client = new ClientPreferTypes
            {
                ClientPreferType = cartype,
                cars = Cars

            };

            return View(client);


        }
        /*End Reham Code*/
    }
}