using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using test_proje.Models;

namespace test_proje.Controllers
{
    public class AdminUrunController : Controller
    {
        metroDB db = new metroDB();
        // GET: AdminUrun
        public ActionResult Index()
        {
            var urunler = db.urunlers.ToList();
            return View(urunler);
        }

        // GET: AdminUrun/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminUrun/Create
        public ActionResult Create()
        {
            ViewBag.kategoriId = new SelectList(db.kategoris,"kategoriId","kategoriAdi");
            return View();
        }

        // POST: AdminUrun/Create
        [HttpPost]
        public ActionResult Create(urunler urun,HttpPostedFileBase Foto)
        {
            try
            {
                // TODO: Add insert logic here
                if (Foto != null)
                {
                    WebImage img = new WebImage(Foto.InputStream);
                    FileInfo fotoinfo = new FileInfo(Foto.FileName);

                    string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(700,400);
                    img.Save("~/Uploads/UrunFoto/" + newfoto);
                    urun.foto = "/Uploads/UrunFoto/" + newfoto;

                    
                    
                }
                db.urunlers.Add(urun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(urun);
            }
        }

        // GET: AdminUrun/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminUrun/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminUrun/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminUrun/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
