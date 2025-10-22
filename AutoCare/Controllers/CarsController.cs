using AutoCare.Services.Contracts;
using AutoCare.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoCare.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {
        private readonly ICarService _carService;

        public CarsController(ICarService service)
        {
            _carService = service;
        }

        [HttpGet]
        public async Task <IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await _carService.GetAllAsync(userId);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CarViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarViewModel carVm)
        {
            if (!ModelState.IsValid)
            {
                return View(carVm);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
            if (userId == null)
            {
                return Challenge(); 
            }

            await _carService.AddAsync(carVm, userId); 
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            CarViewModel? model = await _carService.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarViewModel carVm)
        {
            if (!ModelState.IsValid)
            {
                return View(carVm);
            }
            await _carService.EditAsync(carVm);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _carService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }



    }
}
