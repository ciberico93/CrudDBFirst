using AppCrudAdo_0209.Models;
using AppCrudAdo_0209.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppCrudAdo_0209.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IContactoRepository<Contacto> _contactoRepository;

        public HomeController(ILogger<HomeController> logger, IContactoRepository<Contacto> contactoRepository)
        {
            _logger = logger;
            _contactoRepository = contactoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var contactos = await _contactoRepository.GetAll();
            return View(contactos);
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(Contacto contacto)
        {
            var entity = await _contactoRepository.Create(contacto);

            if (entity == null)
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Actualizar(int id)
        {
            var entity = await _contactoRepository.GetbyID(id);
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(Contacto entity)
        {
            var contacto = await _contactoRepository.Update(entity);
            if (contacto == null)
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var entity = await _contactoRepository.GetbyID(id);
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            var entity = await _contactoRepository.Delete(id);
            if (entity == null)
            {
                return View();
            }
            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}