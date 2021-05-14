using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        Context context = new Context();
        // GET: Istatistik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Istatistik()
        {
            var list=cm.GetCategoryList();

            ViewBag.KategoriSay = list.Count();
            using (var heading=new Context())
            {
                
                var result = heading.Headings.Where(h => h.CategoryID == 15).Count();
                ViewBag.Baslik = result;

            }
            using (var writers = new Context())
            {
                var result = writers.Writers.Where(w => w.Writername.StartsWith("A")).Count();
                ViewBag.YazarAd = result;
            }
            using (var categories = new Context())
            {
                int result = categories.Categories.Where(x => x.CategoryStatus == true).Count();
                int result2 = categories.Categories.Where(x => x.CategoryStatus == false).Count();

                ViewBag.StatusSayi = result - result2;
            }
            //En çok başlığa sahip kategori
          /*  var item = from h in context.Headings
                       join a in context.Categories on h.CategoryID equals a.CategoryID                
*/
                     
            

            return View();
        }
    }
}