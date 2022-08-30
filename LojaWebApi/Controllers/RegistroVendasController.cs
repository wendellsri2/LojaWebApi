using LojaWebApi.Models;
using LojaWebApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace LojaWebApi.Controllers
{
    public class RegistroVendasController : Controller
    {
        private readonly RegistroVendaService _registroVendaService;

        public RegistroVendasController(RegistroVendaService registroVendaService)
        {
            _registroVendaService = registroVendaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Pesquisa(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("dd-MM-yyyy");
            ViewData["maxDate"] = maxDate.Value.ToString("dd-MM-yyyy");
            var result = await _registroVendaService.ProcurarDataAsync(minDate, maxDate);

            return View("pesquisa", result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _registroVendaService.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);
        }
    }
}