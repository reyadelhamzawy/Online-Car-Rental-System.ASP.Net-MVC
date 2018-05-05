using Online_Car_Rental_System.Models;
using Online_Car_Rental_System.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Car_Rental_System.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            var cars = db.Cars;
            return View(cars);
        }


        public ActionResult Users()
        {
            var users = db.Clients;
            return View(users);
        }
        //------------------------------------------------------------


        [HttpGet]
        public ActionResult AddCar()
        {
            var carTypes = db.CarType.ToList();
            Car_CarsTypes cct = new Car_CarsTypes
            {
                CarsTypes = carTypes
            };

            return View(cct);
        }

        [HttpPost]
        public ActionResult AddCar(Car_CarsTypes cct, HttpPostedFileBase upload)
        {

            if (ModelState.IsValid)
            {
                // string path = Server.MapPath("~/images/") + upload.FileName;
                string path = Path.Combine(Server.MapPath("~/Content/images"), upload.FileName);
                upload.SaveAs(path);
                cct.Car.Img = upload.FileName;
                db.Cars.Add(cct.Car);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                var typs = db.CarType.ToList();
                cct.CarsTypes = typs;
                return View("AddCar", cct);
            }



        }

        public ActionResult Details(int id)
        {
            var data = db.Cars.SingleOrDefault(c => c.ID == id);
            return View(data);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var CarData = db.Cars.SingleOrDefault(x => x.ID == id);
            Car_CarsTypes cct = new Car_CarsTypes
            {
                Car = CarData,
                CarsTypes = db.CarType
            };
            return View(cct);
        }
        /////////////////////////////////////////////////


        public ActionResult Edit(Car_CarsTypes cct, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null)
                {
                    string path = Path.Combine(Server.MapPath("~/Content/images"), upload.FileName);
                    upload.SaveAs(path);
                    cct.Car.Img = upload.FileName;
                    db.Entry(cct.Car).State = EntityState.Modified;
                    db.SaveChanges();
                    
                    return RedirectToAction("Index");
                }
                else
                {

                    // var get_id = db.Cars.SingleOrDefault(c => c.ID == cct.Car.ID);
                    //var getimgname = get_id.Img;
                    // string path2 = Path.Combine(Server.MapPath("~/images"), getimgname);
                    // upload.SaveAs(path2);
                    db.Entry(cct.Car).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                var typs = db.CarType.ToList();
                cct.CarsTypes = typs;
                return View("Edit", cct);
            }

            //return View(cct);
        }
        public ActionResult Delete(int id)
        {
            var item = db.Cars.SingleOrDefault(c => c.ID == id);
            db.Cars.Remove(item);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult DeleteUser(int id)
        {
            var item = db.Clients.SingleOrDefault(c => c.ID == id);
            db.Clients.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Users");
        }

        public ActionResult block(int id)
        {
            var item = db.Clients.SingleOrDefault(c => c.ID == id);
            item.SSN = 0;
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Users");
        }

        public ActionResult unblock(int id)
        {
            var item = db.Clients.SingleOrDefault(c => c.ID == id);
            item.SSN = 1;
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Users");
        }
    }
}