using AutoCare.Data;
using AutoCare.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AutoCare.Services
{
    public class CarAccessService : ICarAccessService
    {
        private readonly AutoCareDbContext _db;

        public CarAccessService(AutoCareDbContext db)
        {
            _db = db;
        }

        public async Task<bool> UserOwnsCarAsync(string userId, int carId)
        {
            return await _db.Cars.AnyAsync(c => c.Id == carId && c.UserId == userId);
        }
    }
}
