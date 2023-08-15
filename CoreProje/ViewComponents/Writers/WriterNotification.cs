using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.ViewComponents.Writers
{
    public class WriterNotification : ViewComponent
    {
        INotificationService _notificationService = new NotificationManager(new EFNotificationDal());
        public IViewComponentResult Invoke()
        {
            var Values = _notificationService.GetAll().TakeLast(3);
            return View(Values);
        }
    }
}
