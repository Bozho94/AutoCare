using AutoCare.Services.Contracts;
using AutoCare.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoCare.Controllers
{
    public class TechnicalInspectionsController : Controller
    {
        private readonly ITechnicalInspectionService _service;

        public TechnicalInspectionsController(ITechnicalInspectionService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(int carId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var model = await _service.GetAllAsync(userId, carId);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create(int carId)
        {
            return View(new TechnicalInspectionVM { CarId = carId });
        }

        [HttpPost]
        public async Task<IActionResult> Create(TechnicalInspectionVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            await _service.AddAsync(vm);
            return RedirectToAction(nameof(Index), new { carId = vm.CarId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vm = await _service.GetByIdAsync(id);
            if (vm == null)
                return NotFound();

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TechnicalInspectionVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            await _service.EditAsync(vm);
            return RedirectToAction(nameof(Index), new { carId = vm.CarId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
