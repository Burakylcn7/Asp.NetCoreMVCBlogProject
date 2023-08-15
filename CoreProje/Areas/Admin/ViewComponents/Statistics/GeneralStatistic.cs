using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CoreProje.Areas.Admin.ViewComponents.Statistics
{
    public class GeneralStatistic : ViewComponent
    {
        CoreBlogDbContext _context = new CoreBlogDbContext();
        public IViewComponentResult Invoke() 
        {
            string api = "b319a16b9259cb51852e71ef53c0a903";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.heat = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View(); 
        }
    }
}
