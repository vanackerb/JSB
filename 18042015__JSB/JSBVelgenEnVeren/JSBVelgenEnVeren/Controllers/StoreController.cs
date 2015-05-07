using JSBVelgenEnVeren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JSBVelgenEnVeren.Controllers
{
    public class StoreController : Controller
    {

        JSBVelgenEnVerenContext storeDB = new JSBVelgenEnVerenContext();

        public ActionResult Browse(string category)
        {
            var categoryModel = storeDB.Categories.Include("Products").Single(c => c.Naam == category);
            return View(categoryModel);
        }
        // GET: Store
        public ActionResult Detail(Int32 id)
        {
            var product = storeDB.Products.Find(id);
            return View(product);
        }
        public ActionResult Index()
        {
            var categories = storeDB.Categories.ToList();
            return View(categories);
        }

        // GET: /Store/CategoryMenu
        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            var categories = storeDB.Categories.ToList();
            return PartialView(categories);
        }

    }
}