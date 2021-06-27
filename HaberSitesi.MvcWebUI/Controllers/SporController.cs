using HaberSitesi.Business.Concrete;
using HaberSitesi.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberSitesi.MvcWebUI.Controllers
{
    public class SporController : Controller
    {
        NewsManager newsManager = new NewsManager(new EfNewsDal());
        public ActionResult Index()
        {
            var newsValues = newsManager.GetSportList();
            return View(newsValues);
        }
        public ActionResult Haber(int id)
        {
            var newsValues = newsManager.GetByID(id);
            return View(newsValues);
        }
    }
}