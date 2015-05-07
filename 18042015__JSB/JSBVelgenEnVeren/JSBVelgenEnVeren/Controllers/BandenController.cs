using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JSBVelgenEnVeren.Models;

namespace JSBVelgenEnVeren.Controllers
{
    public class BandenController : Controller
    {
        private JSBVelgenEnVerenContext db = new JSBVelgenEnVerenContext();

        // GET: Banden
        public ActionResult Index()
        {
            return View(db.Bandens.ToList());
        }

        // GET: Banden/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banden banden = (Banden)db.Products.Find(id);
            if (banden == null)
            {
                return HttpNotFound();
            }
            return View(banden);
        }

        // GET: Banden/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banden/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Naam,Merk,Type,CategorieId,Prijs,Omschrijving,Unit,Url,BandenId,Hoogte,Breedte,LaadIndex,Diameter,SnelheidsCode,AutoId")] Banden banden, HttpPostedFileBase file)
        {

            string ImageName = System.IO.Path.GetFileName(file.FileName);
            string physicalPath = Server.MapPath("~/Images/Banden/" + ImageName);

            file.SaveAs(physicalPath);

            if (ModelState.IsValid)
            {
                banden.Url = ImageName;
                db.Products.Add(banden);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(banden);
        }

        // GET: Banden/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banden banden = (Banden)db.Products.Find(id);
            if (banden == null)
            {
                return HttpNotFound();
            }
            return View(banden);
        }

        // POST: Banden/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Naam,Merk,Type,CategorieId,Prijs,Omschrijving,Unit,Url,BandenId,Hoogte,Breedte,LaadIndex,Diameter,SnelheidsCode,AutoId")] Banden banden, HttpPostedFileBase file)
        {

            string ImageName = System.IO.Path.GetFileName(file.FileName);
            string physicalPath = Server.MapPath("~/Images/Banden/" + ImageName);
            if (file != null)
            {

                file.SaveAs(physicalPath);

            }

            if (ModelState.IsValid)
            {
                banden.Url = ImageName;
                db.Entry(banden).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(banden);
        }

        // GET: Banden/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banden banden = (Banden)db.Products.Find(id);
            if (banden == null)
            {
                return HttpNotFound();
            }
            return View(banden);
        }

        // POST: Banden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Banden banden = (Banden)db.Products.Find(id);
            db.Products.Remove(banden);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
