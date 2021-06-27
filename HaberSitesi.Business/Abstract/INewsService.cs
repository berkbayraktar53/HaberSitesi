using HaberSitesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesi.Business.Abstract
{
    public interface INewsService
    {
        List<News> GetList();
        List<News> GetAgendaList();
        List<News> GetEconomyList();
        List<News> GetWorldList();
        List<News> GetSportList();
        List<News> GetHealthList();
        List<News> GetTechnologyList();
        List<News> GetWeatherForecastList();
        News GetByID(int id);
        void NewsAdd(News news);
        void NewsDelete(News news);
        void NewsUpdate(News news);
    }
}