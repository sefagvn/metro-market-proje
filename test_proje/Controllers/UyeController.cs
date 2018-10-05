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
        public ActionResult Index()
        {
            return View();
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
    }
}