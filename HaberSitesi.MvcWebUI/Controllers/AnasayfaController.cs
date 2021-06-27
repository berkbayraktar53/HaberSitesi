using HaberSitesi.Business.Concrete;
using HaberSitesi.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberSitesi.MvcWebUI.Controllers
{
    public class AnasayfaController : Controller
    {
        NewsManager newsManager = new NewsManager(new EfNewsDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult SonDakika()
        {
            var values = newsManager.GetList().Take(10).ToList();
            return PartialView(values);
        }
        public PartialViewResult Slider()
        {
            var values = newsManager.GetList().Take(10).ToList();
            return PartialView(values);
        }
        public PartialViewResult SonHaberler()
        {
            var values = newsManager.GetList().Take(5).ToList();
            return PartialView(values);
        }
        public PartialViewResult Spor()
        {
            var values = newsManager.GetSportList().Take(4).ToList();
            return PartialView(values);
        }
        public PartialViewResult Saglik()
        {
            var values = newsManager.GetHealthList().Take(4).ToList();
            return PartialView(values);
        }
        public PartialViewResult Ekonomi()
        {
            var values = newsManager.GetEconomyList().Take(4).ToList();
            return PartialView(values);
        }
        public PartialViewResult EkonomiEk()
        {
            var values = newsManager.GetEconomyList().Take(1).ToList();
            return PartialView(values);
        }
        public PartialViewResult Dunya()
        {
            var values = newsManager.GetWorldList().Take(4).ToList();
            return PartialView(values);
        }
        public PartialViewResult DunyaEk()
        {
            var values = newsManager.GetWorldList().Take(1).ToList();
            return PartialView(values);
        }
        public PartialViewResult Yazarlar()
        {
            var values = writerManager.GetList().Take(4).ToList();
            return PartialView(values);
        }
        public PartialViewResult Gundem()
        {
            var values = newsManager.GetAgendaList().Take(4).ToList();
            return PartialView(values);
        }
        public PartialViewResult GundemEk()
        {
            var values = newsManager.GetAgendaList().Take(1).ToList();
            return PartialView(values);
        }
        public PartialViewResult Teknoloji()
        {
            var values = newsManager.GetTechnologyList().Take(3).ToList();
            return PartialView(values);
        }
        public PartialViewResult TeknolojiEk()
        {
            var values = newsManager.GetTechnologyList().Take(1).ToList();
            return PartialView(values);
        }
    }
}