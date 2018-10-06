using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_proje.Models;

namespace test_proje.Controllers
{
    public class UyeController : Controller
    {
        metroDB db = new metroDB();

        // GET: Uye
        public ActionResult Index(int id)
        {
            var uye = db.uyes.Where(u=>u.uyeId==id).SingleOrDefault();
            if (Convert.ToInt32(Session["uyeid"])!=uye.uyeId)
            {
                return HttpNotFound();
            }
            return View(uye);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(uye uye)
        {
            var login = db.uyes.Where(u=>u.kullaniciAdi==uye.kullaniciAdi).SingleOrDefault();
            if (login.kullaniciAdi==uye.kullaniciAdi && login.email==uye.email && login.sifre==uye.sifre)
            {
                Session["uyeid"] = login.uyeId;
                Session["kullaniciadi"] = login.kullaniciAdi;
                Session["yetkiid"] = login.yetkiId;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Uyari = "Kullanıcı Adı, Mail ya da Şifrenizi Kontrol Ediniz!!";
                return View();
            }
            
        }
        public ActionResult Logout()
        {
            Session["uyeid"] = null;
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(uye uye)
        {
            if (ModelState.IsValid)
            {
                if (uye != null)
                {
                    uye.yetkiId = 2;
                    db.uyes.Add(uye);
                    db.SaveChanges();
                    Session["uyeid"] = uye.uyeId;
                    Session["kullaniciadi"] = uye.kullaniciAdi;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("üye", "Bilgileri Doldurunuz");
                }
            }
            return View(uye);
        }
        public ActionResult Edit(int id)
        {
            var uye = db.uyes.Where(u=>u.uyeId == id).SingleOrDefault();
            if (Convert.ToInt32(Session["uyeid"])!=uye.uyeId)
            {
                return HttpNotFound();
            }
            return View(uye);
        }
        [HttpPost]
        public ActionResult Edit(uye uye, int id)
        {
            if (ModelState.IsValid)
            {
                var uyee = db.uyes.Where(u => u.uyeId == id).SingleOrDefault();
                if (uye!=null)
                {
                    uyee.kullaniciAdi = uye.kullaniciAdi;
                    uyee.adi = uye.adi;
                    uyee.soyadi = uye.soyadi;
                    uyee.sifre = uye.sifre;
                    uyee.email = uye.email;
                    db.SaveChanges();
                    Session["kullaniciadi"] = uye.kullaniciAdi;
                    return RedirectToAction("Index", new { id=uyee.uyeId});

                }
                else
                {
                    uyee.kullaniciAdi = uye.kullaniciAdi;
                    uyee.adi = uye.adi;
                    uyee.soyadi = uye.soyadi;
                    uyee.sifre = uye.sifre;
                    uyee.email = uye.email;
                    db.SaveChanges();
                    Session["kullaniciadi"] = uye.kullaniciAdi;
                    return RedirectToAction("Index", new { id = uyee.uyeId });
                }
            }
            return View();
        }
    }
}