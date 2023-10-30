using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationLibrary.Models;
using System.Data.Entity;
using System.EnterpriseServices;

namespace WebApplicationLibrary.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books

        LibraryEntities db=new LibraryEntities();

        public ActionResult Index()
        {
            var result= db.Books.Include(n=> n.Author).Include(a=>a.Publisher).ToList();
            return View(result);
        }


        public ActionResult Create()
        {
            List<SelectListItem> data = (from a in db.Authors.ToList()
                                         select new SelectListItem
                                         {
                                             Text= a.AuthorNameSurname,
                                             Value= a.AuthorID.ToString(),

                                         }).ToList();

            ViewBag.Data = data;

            List<SelectListItem> data2 = (from b in db.Publishers.ToList()
                                          select new SelectListItem
                                          {
                                              Text = b.PublisherName,
                                              Value = b.PublisherID.ToString(),
                                          }).ToList();
            ViewBag.Data2 = data2;


            return View(); 
        
        }



        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {

                db.Books.Add(book);
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
            List<SelectListItem> data = (from a in db.Authors.ToList()
                                         select new SelectListItem
                                         {
                                             Text = a.AuthorNameSurname,
                                             Value = a.AuthorID.ToString(),

                                         }).ToList();

            ViewBag.Data = data;

            List<SelectListItem> data2 = (from b in db.Publishers.ToList()
                                          select new SelectListItem
                                          {
                                              Text = b.PublisherName,
                                              Value = b.PublisherID.ToString(),
                                          }).ToList();
            ViewBag.Data2 = data2;


            var result = db.Books.Find(id);
            return View(result);   

        }


        [HttpPost]
        public ActionResult Edit(int id, Book book)
        {
            db.Entry(book).State= System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

        }



        public ActionResult Delete(int id)
        {
            List<SelectListItem> data = (from a in db.Authors.ToList()
                                         select new SelectListItem
                                         {
                                             Text = a.AuthorNameSurname,
                                             Value = a.AuthorID.ToString(),

                                         }).ToList();

            ViewBag.Data = data;

            List<SelectListItem> data2 = (from b in db.Publishers.ToList()
                                          select new SelectListItem
                                          {
                                              Text = b.PublisherName,
                                              Value = b.PublisherID.ToString(),
                                          }).ToList();
            ViewBag.Data2 = data2;


            var result = db.Books.Find(id);
            return View(result);

        }

        [HttpPost]
        public ActionResult Delete(int id,Book book)
        {
            var result=db.Books.Find(id);
            db.Books.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        public ActionResult Search(string x)
        {
            List<SelectListItem> data = (from a in db.Authors.ToList()
                                         select new SelectListItem
                                         {
                                             Text = a.AuthorNameSurname,
                                             Value = a.AuthorID.ToString(),

                                         }).ToList();

            ViewBag.Data = data;

            List<SelectListItem> data2 = (from b in db.Publishers.ToList()
                                          select new SelectListItem
                                          {
                                              Text = b.PublisherName,
                                              Value = b.PublisherID.ToString(),
                                          }).ToList();
            ViewBag.Data2 = data2;

            var search = from d in db.Books select d;
            if(x!= null)
            {
                search = search.Where(m => m.BookTitle.Contains(x));

            }

            return View(search.ToList()) ;


        }







    }





}