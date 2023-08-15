using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAppUserService
    {
        List<AppUser> GetAll();
        AppUser GetByID(int Id);
        List<AppUser> GetByUserName(string p);
    }
}
