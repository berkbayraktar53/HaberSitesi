using FluentValidation.Results;
using HaberSitesi.Business.Concrete;
using HaberSitesi.Business.ValidationRules;
using HaberSitesi.DataAccess.Concrete.EntityFramework;
using HaberSitesi.Entities.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberSitesi.MvcWebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        NewsManager newsManager = new NewsManager(new EfNewsDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterValidator writerValidator = new WriterValidator();
        NewsValidator newsValidator = new NewsValidator();
        public ActionResult Haberler(int sayfa = 1)
        {
            var values = newsManager.GetList().ToPagedList(sayfa, 5);
            return View(values);
        }
        [HttpGet]
        public ActionResult HaberEkle()
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();

            List<SelectListItem> valueWriter = (from x in writerManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurname,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();

            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;
            return View();
        }
        [HttpPost]
        public ActionResult HaberEkle(News news)
        {
            ValidationResult results = newsValidator.Validate(news);
            if (results.IsValid)
            {
                news.NewsDate = DateTime.Now;
                newsManager.NewsAdd(news);
                return RedirectToAction("Haberler");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult HaberDetay(int id)
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            List<SelectListItem> valueWriter = (from x in writerManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WriterName + " " + x.WriterSurname,
                                                      Value = x.WriterID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;
            var managerDetail = newsManager.GetByID(id);
            return View(managerDetail);
        }
        [HttpPost]
        public ActionResult HaberDetay(News news)
        {
            ValidationResult results = newsValidator.Validate(news);
            if (results.IsValid)
            {
                news.NewsDate = DateTime.Now;
                newsManager.NewsUpdate(news);
                return RedirectToAction("Haberler");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult HaberSil(int id)
        {
            var values = newsManager.GetByID(id);
            newsManager.NewsDelete(values);
            return RedirectToAction("Haberler");
        }
        public ActionResult Yazarlar(int sayfa = 1)
        {
            var values = writerManager.GetList().ToPagedList(sayfa, 5);
            return View(values);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(Writer writer)
        {
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                writerManager.WriterAdd(writer);
                return RedirectToAction("Yazarlar");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult YazarDetay(int id)
        {
            var managerDetail = writerManager.GetByID(id);
            return View(managerDetail);
        }
        [HttpPost]
        public ActionResult YazarDetay(Writer writer)
        {
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                writerManager.WriterUpdate(writer);
                return RedirectToAction("Yazarlar");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult YazarSil(int id)
        {
            var values = writerManager.GetByID(id);
            writerManager.WriterDelete(values);
            return RedirectToAction("Yazarlar");
        }
        public ActionResult Ayarlar()
        {
            var values = adminManager.GetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AdminDetay(int id)
        {
            var managerDetail = adminManager.GetByID(id);
            return View(managerDetail);
        }
        [HttpPost]
        public ActionResult AdminDetay(Admin admin)
        {
            AdminValidator adminValidator = new AdminValidator();
            ValidationResult results = adminValidator.Validate(admin);
            if (results.IsValid)
            {
                adminManager.AdminUpdate(admin);
                return RedirectToAction("Ayarlar");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}