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