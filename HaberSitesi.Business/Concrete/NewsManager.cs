using HaberSitesi.Business.Abstract;
using HaberSitesi.DataAccess.Abstract;
using HaberSitesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesi.Business.Concrete
{
    public class NewsManager : INewsService
    {
        INewsDal _newsDal;
        public NewsManager(INewsDal newsDal)
        {
            _newsDal = newsDal;
        }

        public News GetByID(int id)
        {
            return _newsDal.Get(x => x.NewsID == id);
        }

        public void NewsAdd(News news)
        {
            _newsDal.Add(news);
        }

        public void NewsDelete(News news)
        {
            _newsDal.Delete(news);
        }

        public void NewsUpdate(News news)
        {
            _newsDal.Update(news);
        }

        public List<News> GetAgendaList()
        {
            return _newsDal.List(x => x.Category.CategoryName == "Gundem").OrderByDescending(x => x.NewsDate).ToList();
        }

        public List<News> GetEconomyList()
        {
            return _newsDal.List(x => x.Category.CategoryName == "Ekonomi").OrderByDescending(x => x.NewsDate).ToList();
        }

        public List<News> GetWorldList()
        {
            return _newsDal.List(x => x.Category.CategoryName == "Dunya").OrderByDescending(x => x.NewsDate).ToList();
        }

        public List<News> GetSportList()
        {
            return _newsDal.List(x => x.Category.CategoryName == "Spor").OrderByDescending(x => x.NewsDate).ToList();
        }

        public List<News> GetHealthList()
        {
            return _newsDal.List(x => x.Category.CategoryName == "Saglik").OrderByDescending(x => x.NewsDate).ToList();
        }

        public List<News> GetTechnologyList()
        {
            return _newsDal.List(x => x.Category.CategoryName == "Teknoloji").OrderByDescending(x => x.NewsDate).ToList();
        }


        public List<News> GetWeatherForecastList()
        {
            return _newsDal.List(x => x.Category.CategoryName == "Hava Durumu");
        }

        public List<News> GetList()
        {
            return _newsDal.List().OrderByDescending(x => x.NewsDate).ToList();
        }
    }
}