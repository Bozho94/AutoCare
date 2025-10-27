using AutoCare.Data;
using AutoCare.Data.Models;
using AutoCare.Services.Contracts;
using AutoCare.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AutoCare.Services
{
    public class BeltService : IBeltService
    {
        private readonly AutoCareDbContext _db;

        public BeltService(AutoCareDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(BeltServiceVM model)
        {
            var entity = new BeltServiceRecord
            {
                CarId = model.CarId,
                ServiceDate = model.ServiceDate,
                OdometerKm = model.OdometerKm,
                BeltsPumpBrand = model.BeltsPumpBrand
            };

            _db.BeltServiceRecords.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.BeltServiceRecords.FirstOrDefaultAsync(r => r.Id == id);
            if (entity != null)
            {
                _db.BeltServiceRecords.Remove(entity);
                await _db.SaveChangesAsync();

            }
        }

        public async Task EditAsync(BeltServiceVM model)
        {
            var entity = await _db.BeltServiceRecords.FindAsync(model.Id);
            if (entity != null)
            {
                entity.CarId = model.CarId;
                entity.ServiceDate = model.ServiceDate;
                entity.OdometerKm = model.OdometerKm;
                entity.BeltsPumpBrand = model.BeltsPumpBrand;
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<BeltServiceVM>> GetAllAsync(string userId, int carId)
        {
            return await _db.BeltServiceRecords
                .AsNoTracking()
                .Where(r => r.Car.UserId == userId && r.CarId == carId)
                .Select(r => new BeltServiceVM
                {
                    Id = r.Id,
                    CarId = r.CarId,
                    ServiceDate = r.ServiceDate,
                    OdometerKm = r.OdometerKm,
                    BeltsPumpBrand = r.BeltsPumpBrand

                })
                .ToListAsync();
        }

        public async Task<BeltServiceVM?> GetByIdAsync(int id)
        {
            return await _db.BeltServiceRecords
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(r => new BeltServiceVM
                {
                    Id = r.Id,
                    CarId = r.CarId,
                    ServiceDate = r.ServiceDate,
                    OdometerKm = r.OdometerKm,
                    BeltsPumpBrand = r.BeltsPumpBrand

                })
                .FirstOrDefaultAsync();
        }
    }
}
