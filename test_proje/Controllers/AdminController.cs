using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_proje.Models;

namespace test_proje.Controllers
{
    public class AdminController : Controller
    {
        metroDB db = new metroDB();
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.UrunSayisi = db.urunlers.Count();
            ViewBag.KategoriSayisi = db.kategoris.Count();
            ViewBag.UyeSayisi = db.uyes.Count();
            return View();
        }
    }
}