using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationLibrary.Models;

namespace WebApplicationLibrary.Controllers
{
    public class PublishersController : Controller
    {
        // GET: Publishers

        LibraryEntities db=new LibraryEntities();
        public ActionResult Index()

        {

            var result = db.Publishers.ToList();

            return View(result);
        }


       public ActionResult Create()
        {

            return View();

        }


        [HttpPost]
        public ActionResult Create(Publisher publisher)
        {

            try
            {
                db.Publishers.Add(publisher);
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
          var result = db.Publishers.Find(id);
            return View(result);
       
        
        }

        [HttpPost]
        public ActionResult Edit(int id, Publisher publisher)
        {
        
            db.Entry(publisher).State=System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        public ActionResult Delete(int id)
        {
            var result = db.Publishers.Find(id);
            return View(result);


        }

        [HttpPost]
        public ActionResult Delete(int id,Publisher publisher)
        {
            var result = db.Publishers.Find(id);
            db.Publishers.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");


        }


        public ActionResult Search(string x)
        {

            var search = from d in db.Publishers select d;
            if (x != null)
            {
                search = search.Where(m => m.PublisherName.Contains(x));

            }

            return View(search.ToList());


        }




    }
}