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
            var entity = new Car
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
            var entity = await _db.Cars.FirstOrDefaultAsync(c => c.Id == id);

            if(entity is null)
            {
                return;
            }

            _db.Cars.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(CarViewModel car)
        {
            var entity = await _db.Cars.FindAsync(car.Id);

            if(entity is null)
            {
                return;
            }
            entity.Brand = car.Brand;
            entity.Model = car.Model;
            entity.RegistrationNumber = car.RegistrationNumber;
            entity.YearOfManufacture = car.YearOfManufacture;
            await _db.SaveChangesAsync();
        }

        public async Task<List<CarViewModel>> GetAllAsync(string userId)
        {
            return await _db.Cars
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
           
        }

        public async Task<CarViewModel?> GetByIdAsync(int id)
        {
             return await _db.Cars
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
            
        }

        public async Task<bool> UserOwnsCarAsync(string userId, int carId)
        {
            return await _db.Cars.AnyAsync(c => c.Id == carId && c.UserId == userId);
        }
    }
}
