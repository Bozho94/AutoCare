using AutoCare.Data;
using AutoCare.Data.Models;
using AutoCare.Services.Contracts;
using AutoCare.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AutoCare.Services
{
    public class CarService : ICarService
    {
        private readonly AutoCareDbContext _db;

        public CarService(AutoCareDbContext db)
        {
            _db = db;
        }
        public async Task AddAsync(CarViewModel car, string userId)
        {
            Car? entity = new Car
            {
                Brand = car.Brand,
                Model = car.Model,
                RegistrationNumber = car.RegistrationNumber,
                YearOfManufacture = car.YearOfManufacture,
                UserId = userId
            };

            _db.Cars.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Car? entity = await _db.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if(entity != null)
            {
                _db.Cars.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task EditAsync(CarViewModel car)
        {
            Car? entity = await _db.Cars.FindAsync(car.Id);

            if(entity != null)
            {
                entity.Brand = car.Brand;
                entity.Model = car.Model;
                entity.RegistrationNumber = car.RegistrationNumber;
                entity.YearOfManufacture = car.YearOfManufacture;
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<CarViewModel>> GetAllAsync(string userId)
        {
            List<CarViewModel> list = await _db.Cars
                .AsNoTracking()
                .Where(c => c.UserId == userId)
                .Select(c => new CarViewModel
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Model = c.Model,
                    RegistrationNumber = c.RegistrationNumber,
                    YearOfManufacture = c.YearOfManufacture,
                    HasOilAndFilters = _db.OilServiceRecords.Any(r => r.CarId == c.Id),
                    HasBeltsAndRollers = _db.BeltServiceRecords.Any(r => r.CarId == c.Id),
                    HasVignette = _db.VignetteRecords.Any(r => r.CarId == c.Id),
                    HasTechnicalInspection = _db.TechnicalInspectionRecords.Any(r => r.CarId == c.Id)
                })
                .ToListAsync();
            return list;
        }

        public async Task<CarViewModel?> GetByIdAsync(int id)
        {
            CarViewModel? viewModel = await _db.Cars
                 .AsNoTracking()
                 .Where(c => c.Id == id)
                 .Select(c => new CarViewModel
                 {
                     Id = c.Id,
                     Brand = c.Brand,
                     Model = c.Model,
                     RegistrationNumber = c.RegistrationNumber,
                     YearOfManufacture = c.YearOfManufacture
                 })
                 .FirstOrDefaultAsync();
            return viewModel;
        }

        public async Task<bool> UserOwnsCarAsync(string userId, int carId)
        {
            return await _db.Cars.AnyAsync(c => c.Id == carId && c.UserId == userId);
        }
    }
}
