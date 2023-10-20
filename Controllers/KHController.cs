using Microsoft.AspNetCore.Mvc; 
using System.Text.Encodings.Web;
namespace BTL.Controllers
{
    public class KHController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}


