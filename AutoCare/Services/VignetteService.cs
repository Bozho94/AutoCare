using AutoCare.Data;
using AutoCare.Data.Models;
using AutoCare.Services.Contracts;
using AutoCare.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AutoCare.Services
{
    public class VignetteService : IVignetteService
    {
        private readonly AutoCareDbContext _db;

        public VignetteService(AutoCareDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(VignetteVM model)
        {
            var entity = new VignetteRecord
            {
                CarId = model.CarId,
                PurchaseDate = model.PurchaseDate,
                ExpiryDate = model.ExpiryDate
            };

            _db.VignetteRecords.Add(entity);
            await _db.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var entity = _db.VignetteRecords.FirstOrDefault(r => r.Id == id);

            if (entity is null)
            {
                return;
            }

            _db.VignetteRecords.Remove(entity);
            await _db.SaveChangesAsync();
        }



        public async Task EditAsync(VignetteVM model)
        {
            var entity = await _db.VignetteRecords.FindAsync(model.Id);

            if (entity is null)
            {
                return;
            }

            entity.CarId = model.CarId;
            entity.PurchaseDate = model.PurchaseDate;
            entity.ExpiryDate = model.ExpiryDate;
            await _db.SaveChangesAsync();
        }

        public async Task<List<VignetteVM>> GetAllAsync(string userId, int carId)
        {
            return await _db.VignetteRecords
                .AsNoTracking()
                .Where(r => r.Car.UserId == userId && r.CarId == carId)
                .Select(r => new VignetteVM
                {
                    Id = r.Id,
                    CarId = r.CarId,
                    PurchaseDate = r.PurchaseDate,
                    ExpiryDate = r.ExpiryDate
                })
                .ToListAsync();
        }

        public async Task<VignetteVM?> GetByIdAsync(int id)
        {
            return await _db.VignetteRecords
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(r => new VignetteVM
                {
                    Id = r.Id,
                    CarId = r.CarId,
                    PurchaseDate = r.PurchaseDate,
                    ExpiryDate = r.ExpiryDate
                })
                .FirstOrDefaultAsync();
        }
    }
}
