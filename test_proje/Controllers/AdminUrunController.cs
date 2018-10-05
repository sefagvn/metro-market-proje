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
            var urun = db.urunlers.Where(u => u.urunId == id).SingleOrDefault();
            if (urun == null)
            {
                return HttpNotFound();
            }
            ViewBag.kategoriId = new SelectList(db.kategoris,"kategoriId","kategoriAdi",urun.kategoriId);
            return View(urun);
        }

        // POST: AdminUrun/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HttpPostedFileBase Foto, urunler urun)
        {
            try
            {
                // TODO: Add update logic here
                var uruns = db.urunlers.Where(u => u.urunId == id).SingleOrDefault();
                if (Foto!=null)
                {
                    if (System.IO.File.Exists(Server.MapPath(uruns.foto)))
                    {
                        System.IO.File.Delete(Server.MapPath(uruns.foto));
                    }
                    WebImage img = new WebImage(Foto.InputStream);
                    FileInfo fotoinfo = new FileInfo(Foto.FileName);

                    string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(700, 400);
                    img.Save("~/Uploads/UrunFoto/" + newfoto);
                    uruns.foto = "/Uploads/UrunFoto/" + newfoto;
                    uruns.urunAdi = urun.urunAdi;
                    uruns.icerik = urun.icerik;
                    uruns.kategoriId = urun.kategoriId;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    uruns.urunAdi = urun.urunAdi;
                    uruns.icerik = urun.icerik;
                    uruns.kategoriId = urun.kategoriId;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                //return View();
            }
            catch
            {
                ViewBag.kategoriId = new SelectList(db.kategoris, "kategoriId", "kategoriAdi", urun.kategoriId);
                return View(urun);
            }
        }

        // GET: AdminUrun/Delete/5
        public ActionResult Delete(int id)
        {
            var urun = db.urunlers.Where(u => u.urunId == id).SingleOrDefault();
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        // POST: AdminUrun/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                var uruns = db.urunlers.Where(u => u.urunId == id).SingleOrDefault();
                if (uruns == null)
                {
                    return HttpNotFound();
                }
                if (System.IO.File.Exists(Server.MapPath(uruns.foto)))
                {
                    System.IO.File.Delete(Server.MapPath(uruns.foto));
                }
                db.urunlers.Remove(uruns);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
