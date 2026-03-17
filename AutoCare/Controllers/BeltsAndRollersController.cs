using AutoCare.Services;
using AutoCare.Services.Contracts;
using AutoCare.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoCare.Controllers
{
    [Authorize]
    public class BeltsAndRollersController : Controller
    {
        private readonly IBeltService _service;
        private readonly ICarAccessService _carAccessService;

        public BeltsAndRollersController(IBeltService service, ICarAccessService carAccessService)
        {
            _service = service;
            _carAccessService = carAccessService;
        }

        public async Task<IActionResult> Index(int carId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            if (userId == null)
            {
                return Unauthorized();
            }
         
            var owns = await _carAccessService.UserOwnsCarAsync(userId, carId);
            if (!owns)
            {
                return Forbid();
            }
            var model = await _service.GetAllAsync(userId, carId);
            ViewBag.CarId = carId;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int carId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            if (userId == null)
            {
                return Unauthorized();
            }

            var owns = await _carAccessService.UserOwnsCarAsync(userId, carId);
            if (!owns)
            {
                return Forbid();
            }
            return View(new BeltServiceVM { CarId = carId });
        }

        [HttpPost]
        public async Task<IActionResult> Create(BeltServiceVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
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

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
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
        public async Task<IActionResult> Edit(BeltServiceVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            if (userId == null)
            {
                return Unauthorized();
            }

            var vm = await _service.GetByIdAsync(id);
            if (vm == null)
            {
               return NotFound();
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
