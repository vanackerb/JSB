using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JSBVelgenEnVeren.Models;

namespace JSBVelgenEnVeren.Controllers
{
    public class HomeController : Controller
    {
        JSBVelgenEnVerenContext db = new JSBVelgenEnVerenContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            
            return View();
        }

        public ActionResult Contact()
        {
            
            return View();
        }

        public ActionResult Velgen()
        {
            return View(db.Velgens.GroupBy(u=>u.Url).Select(g => g.FirstOrDefault()).ToList());
        }

        public ActionResult Veren()
        {
            return View();
        }

        public ActionResult Tires()
        {
            return View(db.Bandens.GroupBy(u=>u.Url).Select(g=>g.FirstOrDefault()).ToList());
        }

        public ActionResult Tips()
        {
            return View();
        }

        public ActionResult FAQ()
        {
            return View();
        }
        public ActionResult Adminhome()
        {
            return View();
        }

        public ActionResult Facturatie()
        {
            return View();
        }

        public ActionResult Stock()
        {
            return View();
        }

        public ActionResult Rapport()
        {
            return View();
        }

        public ActionResult SiteBeheer()
        {
            return View();
        }
    }
}