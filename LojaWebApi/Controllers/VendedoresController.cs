using Microsoft.AspNetCore.Mvc;

namespace LojaWebApi.Controllers
{
    public class VendedoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
