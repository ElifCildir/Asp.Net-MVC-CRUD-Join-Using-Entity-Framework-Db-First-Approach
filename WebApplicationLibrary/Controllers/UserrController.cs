using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationLibrary.Models;

namespace WebApplicationLibrary.Controllers
{
    public class UserrController : Controller
    {

        LibraryEntities db = new LibraryEntities();

        // GET: User
        public ActionResult Index()

        {

            var result = db.Userrs.ToList();

            return View(result);
        }

        public ActionResult Create()

        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Userr userr)

        {


            try
            {
                db.Userrs.Add(userr);
                db.SaveChanges();
                return RedirectToAction("Index");


            }

            catch
            {

                return View();

            }




        }



        public ActionResult Edit(int id )

        {
            var update= db.Userrs.Find(id);



            return View(update);
        }

        [HttpPost]
        public ActionResult Edit( Userr userr )

        {
            db.Entry(userr).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

        }



   
        public ActionResult Delete(int id)

        {
            var remove = db.Userrs.Find(id);

            return View(remove);

        }

        [HttpPost]
        public ActionResult Delete(int id, Userr userr)

        {
            var remove = db.Userrs.Find(id);
            db.Userrs.Remove(remove);
            db.SaveChanges();
            return RedirectToAction("Index");



        }





    }
}