using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.ViewComponents.Writers
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        IWriterService _writerService = new WriterManager(new EFWriterDal());

        public IViewComponentResult Invoke()
        {
            var loginUser = _writerService.GetByMail(User.Identity.Name).Select(x => x.WriterID).FirstOrDefault();
            var Values = _writerService.GetWriterByID(loginUser);
            return View(Values);
        }
    }
}
