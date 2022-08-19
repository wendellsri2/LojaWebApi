using LojaWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaWebApi.Controllers
{
    public class DepartmentsController1 : Controller
    {
        public IActionResult Index()
        {
            List<Department> list = new List<Department>();
            list.Add(new Department { Id = 1, Name = "Celulares" });
            list.Add(new Department { Id = 2, Name = "Linha Branca" });


            return View(list);
        }
    }
}
