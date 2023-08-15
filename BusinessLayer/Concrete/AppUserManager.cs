using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private IAppUserDal _appuserDal;

        public AppUserManager(IAppUserDal appuserDal)
        {
            _appuserDal = appuserDal;
        }

        public List<AppUser> GetAll()
        {
            return _appuserDal.GetAll();
        }

        public AppUser GetByID(int Id)
        {
            return _appuserDal.GetByID(Id);
        }

        public List<AppUser> GetByUserName(string p)
        {
            return _appuserDal.GetAll(x => x.UserName == p);
        }
    }
}
