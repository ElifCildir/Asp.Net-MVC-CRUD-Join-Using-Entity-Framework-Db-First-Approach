using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationLibrary.Models;

namespace WebApplicationLibrary.Controllers
{
    public class JoinController : Controller
    {


        LibraryEntities db = new LibraryEntities();

        // GET: Join


        public ActionResult ActStudent()
        {
            var data = (from b in db.Books join
                         a in db.Activities on b.BookID equals a.BookID 
                        join s in db.Students on a.StudentID equals s.StudentID
                        select new ActStudent
                        {

                            BookID=a.BookID.Value,
                            BookTitle=b.BookTitle,
                            Duedate=a.DueDate.Value,
                            StudentID=s.StudentID,
                            NameSurname=s.NameSurname,
                            Class=s.Class,
                            Phone=s.Phone,


                          


                        }).ToList();







            return View(data);
        }
    }
}