using BusinessLayer.Abstract;
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

        public string GetRole(string userName)
        {
            var adminValue = _adminDal.Get(x=>x.AdminUserName == userName);
            return adminValue.AdminRole;
        }

        public Admin LoginCheck(Admin admin)
        {
            var adminValue = _adminDal.Get(x=>x.AdminUserName == admin.AdminUserName 
            && x.AdminPassword == admin.AdminPassword);
            return adminValue;
        }
    }
}
