using AutoCare.Data;
using AutoCare.Data.Models;
using AutoCare.Services.Contracts;
using AutoCare.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AutoCare.Services
{
    public class OilService : IOilService
    {
        private readonly AutoCareDbContext _db;

        public OilService(AutoCareDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(OilServiceVM model)
        {
            var entity = new OilServiceRecord
            {
                CarId = model.CarId,
                OilChangeDate = model.OilChangeDate,
                OdometerKm = model.OdometerKm,
                OilViscosity = model.OilViscosity,
                OilAndFiltersBrand = model.OilAndFiltersBrand
            };

            _db.OilServiceRecords.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.OilServiceRecords.FirstOrDefaultAsync(o => o.Id == id);

            if (entity is null)
            {
                return;
            }

            _db.OilServiceRecords.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(OilServiceVM model)
        {
            var entity = await _db.OilServiceRecords.FindAsync(model.Id);

            if (entity is null)
            {
                return;
            }

            entity.CarId = model.CarId;
            entity.OilChangeDate = model.OilChangeDate;
            entity.OdometerKm = model.OdometerKm;
            entity.OilViscosity = model.OilViscosity;
            entity.OilAndFiltersBrand = model.OilAndFiltersBrand;
            await _db.SaveChangesAsync();

        }

        public async Task<List<OilServiceVM>> GetAllAsync(string userId, int carId)
        {
            return await _db.OilServiceRecords
                .AsNoTracking()
                .Where(r => r.Car.UserId == userId && r.CarId == carId)
                .Select(r => new OilServiceVM
                {
                    Id = r.Id,
                    CarId = r.CarId,
                    OilChangeDate = r.OilChangeDate,
                    OdometerKm = r.OdometerKm,
                    OilViscosity = r.OilViscosity,
                    OilAndFiltersBrand = r.OilAndFiltersBrand
                })
                .ToListAsync();

        }

        public async Task<OilServiceVM?> GetByIdAsync(int id)
        {
            return await _db.OilServiceRecords
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(r => new OilServiceVM
                {
                    Id = r.Id,
                    CarId = r.CarId,
                    OilChangeDate = r.OilChangeDate,
                    OdometerKm = r.OdometerKm,
                    OilViscosity = r.OilViscosity,
                    OilAndFiltersBrand = r.OilAndFiltersBrand
                })
                .FirstOrDefaultAsync();
        }
    }
}
