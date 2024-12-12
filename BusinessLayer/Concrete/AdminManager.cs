using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            var hashedPassword = ComputeSha1Hash(admin.AdminPassword);
            var adminValue = _adminDal.Get(x=>x.AdminUserName == admin.AdminUserName 
            && x.AdminPassword == hashedPassword);
            return adminValue;
        }

        private string ComputeSha1Hash(string password)
        {
            using (var sha1 = SHA1.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hashBytes = sha1.ComputeHash(bytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
