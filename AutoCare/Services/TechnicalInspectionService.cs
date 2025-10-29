using AutoCare.Data;
using AutoCare.Data.Models;
using AutoCare.Services.Contracts;
using AutoCare.ViewModels;
using Microsoft.EntityFrameworkCore;
using static AutoCare.EntityValidationConstants.ValidationConstants;

namespace AutoCare.Services
{
    public class TechnicalInspectionService : ITechnicalInspectionService
    {
        private readonly AutoCareDbContext _db;

        public TechnicalInspectionService(AutoCareDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(TechnicalInspectionVM model)
        {
            var entity = new TechnicalInspectionRecord
            {
                CarId = model.CarId,
                InspectionDate = model.InspectionDate
            };

            _db.TechnicalInspectionRecords.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.TechnicalInspectionRecords.FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                return;
            }

            _db.TechnicalInspectionRecords.Remove(entity);
            await _db.SaveChangesAsync();

        }

        public async Task EditAsync(TechnicalInspectionVM model)
        {
            var entity = await _db.TechnicalInspectionRecords.FindAsync(model.Id);

            if (entity is null)
            {
                return;
            }
            entity.CarId = model.CarId;
            entity.InspectionDate = model.InspectionDate;

            await _db.SaveChangesAsync();
        }

        public async Task<List<TechnicalInspectionVM>> GetAllAsync(string userId, int carId)
        {
            return await _db.TechnicalInspectionRecords
                .AsNoTracking()
                .Where(r => r.Car.UserId == userId && r.CarId == carId)
                .Select(r => new TechnicalInspectionVM
                {
                    Id = r.Id,
                    CarId = r.CarId,
                    InspectionDate = r.InspectionDate
                })
                .ToListAsync();
        }

        public async Task<TechnicalInspectionVM?> GetByIdAsync(int id)
        {
            return await _db.TechnicalInspectionRecords
               .AsNoTracking()
               .Where(r => r.Id == id)
               .Select(r => new TechnicalInspectionVM
               {
                   Id = r.Id,
                   CarId = r.CarId,
                   InspectionDate = r.InspectionDate
               })
               .FirstOrDefaultAsync();
        }
    }
}
