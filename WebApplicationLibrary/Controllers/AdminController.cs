using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationLibrary.Models;

namespace WebApplicationLibrary.Controllers
{
    public class AdminController : Controller
    {


        // GET: Admin

        LibraryEntities db = new LibraryEntities();
        public ActionResult Index()
        {
            return View();
        }
    }
}