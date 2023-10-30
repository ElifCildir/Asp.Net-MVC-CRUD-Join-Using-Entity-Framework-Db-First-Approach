using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationLibrary.Models;
using System.Data.Entity;


namespace WebApplicationLibrary.Controllers
{
    public class ActivitiesController : Controller
    {
        // GET: Activities

        LibraryEntities db = new LibraryEntities();

        public ActionResult Index()
        {

            var result = db.Activities.Include(n => n.Book).Include(a => a.Student).ToList();

            return View(result);
        }

        public ActionResult New()
        {

            List<SelectListItem> data = (from x in db.Books.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.BookTitle,
                                             Value = x.BookID.ToString(),


                                         }).ToList();

             ViewBag.Data = data;

            List<SelectListItem> data2 = (from x in db.Students.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.NameSurname,
                                              Value = x.StudentID.ToString(),


                                          }).ToList();

            ViewBag.Data2 = data2;



            return View();


        }

        [HttpPost]
        public ActionResult New(Activity activity)
        {
            try
            {
                db.Activities.Add(activity);
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
         
            List<SelectListItem> data = (from x in db.Books.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.BookTitle,
                                             Value = x.BookID.ToString(),

                                         }).ToList();

            ViewBag.Data = data;
  


            List<SelectListItem> data2 = (from x in db.Students.ToList()
                                       select new SelectListItem
                                         {
                                             Text = x.NameSurname,
                                             Value = x.StudentID.ToString(),


                                         }).ToList();

            ViewBag.Data2 = data2;
           



            var result = db.Activities.Find(id);
            return View(result);

        }

        [HttpPost]
        public ActionResult Edit(int id, Activity activity) 
        {
          db.Entry(activity).State=System.Data.Entity.EntityState.Modified;
          db.SaveChanges();
           return RedirectToAction("Index");


        }

        public ActionResult Delete(int id)
        {
            List<SelectListItem> data = (from x in db.Books.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.BookTitle,
                                             Value = x.BookID.ToString(),

                                         }).ToList();

            ViewBag.Data = data;



            List<SelectListItem> data2 = (from x in db.Students.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.NameSurname,
                                              Value = x.StudentID.ToString(),


                                          }).ToList();

            ViewBag.Data2 = data2;




            var result = db.Activities.Find(id);
            return View(result);

        }

        [HttpPost]
        public ActionResult Delete(int id, Activity activity)
        {
            var result=db.Activities.Find(id);
            db.Activities.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        public ActionResult Search(string x)
        {
            List<SelectListItem> data = (from b in db.Books.ToList()
                                         select new SelectListItem
                                         {
                                             Text = b.BookTitle,
                                             Value = b.BookID.ToString(),

                                         }).ToList();

            ViewBag.Data = data;

            List<SelectListItem> data2 = (from c in db.Students.ToList()
                                          select new SelectListItem
                                          {
                                              Text = c.NameSurname,
                                              Value = c.StudentID.ToString(),


                                          }).ToList();

            ViewBag.Data2 = data2;

            var search = from a in db.Activities select a;
            if(x!= null)
            {
                search = search.Where(m => m.Book.BookTitle.Contains(x));

            }

            return View(search.ToList());
                

        }

   






    }
}