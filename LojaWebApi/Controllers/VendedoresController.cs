using LojaWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LojaWebApi.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _vendedorService;

        public VendedoresController(VendedorService vendedorService)
        {
            _vendedorService = vendedorService;
        }

        public IActionResult Index()
        {
            var list = _vendedorService.Listar();
            return View(list);
        }
    }
}
