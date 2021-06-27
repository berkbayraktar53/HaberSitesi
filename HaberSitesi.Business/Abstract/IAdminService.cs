using HaberSitesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesi.Business.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetList();
        Admin GetByID(int id);
        Admin GetByAdmin(string email, string password);
        void AdminUpdate(Admin admin);
    }
}