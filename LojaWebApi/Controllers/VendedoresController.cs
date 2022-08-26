using LojaWebApi.Models;
using LojaWebApi.Models.ViewModels;
using LojaWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LojaWebApi.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _vendedorService;
        private readonly DepartamentoService _departamentoService;

        public VendedoresController(VendedorService vendedorService, DepartamentoService departamentoService)
        {
            _vendedorService = vendedorService;
            _departamentoService = departamentoService;
        }

        public IActionResult Index()
        {
            var list = _vendedorService.Listar();
            return View(list);
        }

        public IActionResult Create()
        {
            var departamentos = _departamentoService.ListarAll();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _vendedorService.Inserir(vendedor);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _vendedorService.Procurar(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _vendedorService.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var obj = _vendedorService.Procurar(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _vendedorService.Procurar(id.Value);
            if (id == null)
            {
                return NotFound();
            }
            List<Departamento> departamentos = _departamentoService.ListarAll();
            VendedorFormViewModel viewModel = new VendedorFormViewModel
            { Vendedor = obj, Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor)
        {
            if (id != vendedor.VendedorId)
            {
                return BadRequest();
            }
            try
            { 
            _vendedorService.Atualizar(vendedor);
            return RedirectToAction(nameof(Index));
            }
            catch (NotImplementedException)
            {
                return NotFound();
            }
            catch (DBConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}
