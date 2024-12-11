using EntityLayer.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminservice
    {
        Admin LoginCheck(Admin admin);

        string GetRole(string userName);
    }
}
