﻿using HaberSitesi.DataAccess.Abstract;
using HaberSitesi.DataAccess.Concrete.Repositories;
using HaberSitesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesi.DataAccess.Concrete.EntityFramework
{
    public class EfAdminDal : GenericRepository<Admin>, IAdminDal
    {

    }
}