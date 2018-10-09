using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using test_proje.Models;

namespace test_proje.Controllers
{
    public class AdminUyeController : Controller
    {
        private metroDB db = new metroDB();

        // GET: AdminUye
        public ActionResult Index()
        {
            var uyes = db.uyes.Include(u => u.yetki);
            return View(uyes.ToList());
        }

        // GET: AdminUye/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            uye uye = db.uyes.Find(id);
            if (uye == null)
            {
                return HttpNotFound();
            }
            return View(uye);
        }

        // GET: AdminUye/Create
        public ActionResult Create()
        {
            ViewBag.yetkiId = new SelectList(db.yetkis, "yetkiId", "yetki1");
            return View();
        }

        // POST: AdminUye/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "uyeId,kullaniciAdi,email,sifre,adi,soyadi,yetkiId")] uye uye)
        {
            if (ModelState.IsValid)
            {
                db.uyes.Add(uye);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.yetkiId = new SelectList(db.yetkis, "yetkiId", "yetki1", uye.yetkiId);
            return View(uye);
        }

        // GET: AdminUye/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            uye uye = db.uyes.Find(id);
            if (uye == null)
            {
                return HttpNotFound();
            }
            ViewBag.yetkiId = new SelectList(db.yetkis, "yetkiId", "yetki1", uye.yetkiId);
            return View(uye);
        }

        // POST: AdminUye/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "uyeId,kullaniciAdi,email,sifre,adi,soyadi,yetkiId")] uye uye)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uye).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.yetkiId = new SelectList(db.yetkis, "yetkiId", "yetki1", uye.yetkiId);
            return View(uye);
        }

        // GET: AdminUye/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            uye uye = db.uyes.Find(id);
            if (uye == null)
            {
                return HttpNotFound();
            }
            return View(uye);
        }

        // POST: AdminUye/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            uye uye = db.uyes.Find(id);
            db.uyes.Remove(uye);
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
