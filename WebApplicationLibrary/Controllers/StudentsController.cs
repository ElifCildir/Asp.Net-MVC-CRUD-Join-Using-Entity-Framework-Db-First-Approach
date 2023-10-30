using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationLibrary.Models;

namespace WebApplicationLibrary.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students

        LibraryEntities db= new LibraryEntities();
        public ActionResult Index()
        {
            var result = db.Students.ToList();

            return View(result);
        }

        public ActionResult Create()
        { 
            
            
            return View(); }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            catch
            {
                return View();
            }

         
        }


        public ActionResult Edit(int id)
        {
            var result = db.Students.Find(id);
            return View(result);    

        }

        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            db.Entry(student).State= System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

        }



        [HttpGet]
        public ActionResult Delete(int id)
        {
            var delete = db.Students.Find(id);
            return View(delete);


        }

        [HttpPost]
        public ActionResult Delete(int id, Student student)
        {
            var delete = db.Students.Find(id);
            db.Students.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Index");

        }






    }
}