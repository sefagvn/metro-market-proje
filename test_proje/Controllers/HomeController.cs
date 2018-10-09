using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_proje.Models;
using PagedList;
using PagedList.Mvc;

namespace test_proje.Controllers
{
    public class HomeController : Controller
    {
        metroDB db = new metroDB();
        // GET: Home
        public ActionResult Index(int page=1)
        {
            var urun = db.urunlers.OrderByDescending(u=>u.urunId).ToPagedList(page,6);
            return View(urun);
        }
        public ActionResult KategoriUrun(int id)
        {
            var urun = db.urunlers.Where(u => u.kategoriId==id).ToList();
            return View(urun);
        }
        public ActionResult UrunDetay(int id)
        {
            var urun = db.urunlers.Where(u=>u.urunId == id).SingleOrDefault();
            if (urun==null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }
       
        public ActionResult kategoriPartial()
        {
            return View(db.kategoris.ToList());
        }
    }
}