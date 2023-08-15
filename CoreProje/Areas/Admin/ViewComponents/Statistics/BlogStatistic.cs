using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Areas.Admin.ViewComponents.Statistics
{
    public class BlogStatistic : ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View(); 
        }
    }
}
