using HaberSitesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesi.DataAccess.Concrete.EntityFramework
{
    public class Context : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}