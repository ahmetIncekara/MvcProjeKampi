﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminservice
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public bool LoginCheck(Admin admin)
        {
            var adminValue = _adminDal.Get(x=>x.AdminUserName == admin.AdminUserName 
            && x.AdminPassword == admin.AdminPassword);
            return adminValue != null;
        }
    }
}
