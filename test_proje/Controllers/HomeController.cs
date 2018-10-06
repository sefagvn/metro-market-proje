using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_proje.Models;

namespace test_proje.Controllers
{
    public class HomeController : Controller
    {
        metroDB db = new metroDB();
        // GET: Home
        public ActionResult Index()
        {
            var urun = db.urunlers.OrderByDescending(u=>u.urunId).ToList();
            return View(urun);
        }
        public ActionResult kul_giris()
        {
            return View();
        }
        public ActionResult kayit_ol()
        {
            return View();
        }
        public ActionResult kategoriPartial()
        {
            return View(db.kategoris.ToList());
        }
    }
}