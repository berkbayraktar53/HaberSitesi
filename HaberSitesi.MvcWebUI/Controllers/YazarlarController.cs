using HaberSitesi.Business.Concrete;
using HaberSitesi.DataAccess.Concrete.EntityFramework;
using HaberSitesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberSitesi.MvcWebUI.Controllers
{
    public class YazarlarController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        NewsManager newsManager = new NewsManager(new EfNewsDal());
        public ActionResult Index()
        {
            var writerValues = writerManager.GetList();
            return View(writerValues);
        }
        public ActionResult YazarDetay(int id)
        {
            var writerValues = newsManager.GetList().Where(x => x.WriterID == id).ToList();
            var writerName = writerValues.Select(x => x.Writer.WriterName).ToList();
            var writerSurname = writerValues.Select(x => x.Writer.WriterSurname).ToList();
            ViewBag.WriterFullName = writerName[0] + " " + writerSurname[0];
            ViewBag.WriterNewsCount = writerValues.Count();
            return View(writerValues);
        }
    }
}