using AutoCare.Services.Contracts;
using AutoCare.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoCare.Controllers
{
    [Authorize]
    public class VignettesController : Controller
    {
        private readonly IVignetteService _service;
        private readonly ICarAccessService _carAccessService;

        public VignettesController(IVignetteService service, ICarAccessService carAccessService)
        {
            _service = service;
            _carAccessService = carAccessService;
        }

        public async Task<IActionResult> Index(int carId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            var owns = await _carAccessService.UserOwnsCarAsync(userId, carId);
            if (!owns)
            {
                return Forbid();
            }

            ViewBag.CarId = carId;

            var model = await _service.GetAllAsync(userId, carId);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int carId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            var owns = await _carAccessService.UserOwnsCarAsync(userId, carId);
            if (!owns)
            {
                return Forbid();
            }

            return View(new VignetteVM { CarId = carId });
        }

        [HttpPost]
        public async Task<IActionResult> Create(VignetteVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            var owns = await _carAccessService.UserOwnsCarAsync(userId, vm.CarId);
            if (!owns)
            {
                return Forbid();
            }

            await _service.AddAsync(vm);
            return RedirectToAction(nameof(Index), new { carId = vm.CarId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vm = await _service.GetByIdAsync(id);
            if (vm == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            var owns = await _carAccessService.UserOwnsCarAsync(userId, vm.CarId);
            if (!owns)
            {
                return Forbid();
            }

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VignetteVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            var owns = await _carAccessService.UserOwnsCarAsync(userId, vm.CarId);
            if (!owns)
            {
                return Forbid();
            }

            await _service.EditAsync(vm);
            return RedirectToAction(nameof(Index), new { carId = vm.CarId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var vm = await _service.GetByIdAsync(id);
            if (vm == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            var owns = await _carAccessService.UserOwnsCarAsync(userId, vm.CarId);
            if (!owns)
            {
                return Forbid();
            }

            await _service.DeleteAsync(id);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
