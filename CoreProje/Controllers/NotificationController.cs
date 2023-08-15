using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
    public class NotificationController : Controller
    {
        INotificationService _notificationService = new NotificationManager(new EFNotificationDal());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllNotification()
        {
            var Values = _notificationService.GetAll();
            return View(Values);
        }
    }
}
