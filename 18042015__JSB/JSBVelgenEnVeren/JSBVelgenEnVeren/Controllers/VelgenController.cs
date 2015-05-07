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
    public class VelgenController : Controller
    {
        private JSBVelgenEnVerenContext db = new JSBVelgenEnVerenContext();

        // GET: Velgen
        public ActionResult Index()
        {
            return View(db.Velgens.ToList());
        }

        // GET: Velgen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Velgen velgen = (Velgen)db.Products.Find(id);
            if (velgen == null)
            {
                return HttpNotFound();
            }
            return View(velgen);
        }

        // GET: Velgen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Velgen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Naam,Merk,Type,CategorieId,Prijs,Omschrijving,Unit,Url,VelgId,Grootte,Breedte,Steekmaat,Offset,Naafgat,AutoId")] Velgen velgen, HttpPostedFileBase file)
        {
            string ImageName = System.IO.Path.GetFileName(file.FileName);
            string physicalPath = Server.MapPath("~/Images/Velgen/" + ImageName);

            file.SaveAs(physicalPath);
            if (ModelState.IsValid)
            {
                velgen.Url = ImageName;
                db.Velgens.Add(velgen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(velgen);
        }

        // GET: Velgen/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Velgen velgen = (Velgen)db.Products.Find(id);
            if (velgen == null)
            {
                return HttpNotFound();
            }
            return View(velgen);
        }

        // POST: Velgen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Naam,Merk,Type,CategorieId,Prijs,Omschrijving,Unit,Url,VelgId,Grootte,Breedte,Steekmaat,Offset,Naafgat,AutoId")] Velgen velgen, HttpPostedFileBase file)
        {
            string ImageName = System.IO.Path.GetFileName(file.FileName);
            string physicalPath = Server.MapPath("~/Images/Velgen/" + ImageName);
            if(file!=null)
            {
                
                file.SaveAs(physicalPath);
                
            }

            
            if (ModelState.IsValid)
            {
                velgen.Url = ImageName;
                db.Entry(velgen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(velgen);
        }

        // GET: Velgen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Velgen velgen = (Velgen)db.Products.Find(id);
            if (velgen == null)
            {
                return HttpNotFound();
            }
            return View(velgen);
        }

        // POST: Velgen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Velgen velgen = (Velgen)db.Products.Find(id);
            db.Products.Remove(velgen);
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
