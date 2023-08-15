using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Areas.Admin.ViewComponents.Statistics
{
    public class AdminStatistic : ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View(); 
        }
    }
}
