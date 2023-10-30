using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationLibrary.Models;
using System.Data.Entity;
using System.Xml.XPath;

namespace WebApplicationLibrary.Controllers
{
    public class AuthorsController : Controller
    {

        // GET: Authors

        LibraryEntities db = new LibraryEntities();
        public ActionResult Index()
        {
            var result = db.Authors.ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult Create()
        {

           
            return View();


        }

        [HttpPost]
        public ActionResult Create(Author author)
        {

            try
            {
                db.Authors.Add(author);
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
           
            return View(db.Authors.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Author author)
        {
           db.Entry(author).State= System.Data.Entity.EntityState.Modified;
           db.SaveChanges();
           return RedirectToAction("Index");
            
        }


        public ActionResult Delete(int id) 
        {
            return View(db.Authors.Find(id));

        }



        [HttpPost]
        public ActionResult Delete(int id, Author author)
        {
            var result = db.Authors.Find(id);
            db.Authors.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        public ActionResult Search(string x)
        {

            var search = from d in db.Authors select d;
            if (x != null)
            {
                search = search.Where(m => m.AuthorNameSurname.Contains(x));

            }

            return View(search.ToList());


        }



    }
}