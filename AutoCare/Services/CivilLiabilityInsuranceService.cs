using AutoCare.Data;
using AutoCare.Data.Models;
using AutoCare.Services.Contracts;
using AutoCare.ViewModels;
using Microsoft.EntityFrameworkCore;
using static AutoCare.EntityValidationConstants.ValidationConstants;

namespace AutoCare.Services
{
    public class CivilLiabilityInsuranceService : ICivilLiabilityInsuranceService
    {
        private readonly AutoCareDbContext _db;

        public CivilLiabilityInsuranceService(AutoCareDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(CivilLiabilityInsuranceVM model)
        {
            var entity = new Data.Models.CivilLiabilityInsurance
            {
                CarId = model.CarId,
                InsuranceCompanyName = model.InsuranceCompanyName,
                IssueDate = model.IssueDate,
                ExpiryDate = model.ExpiryDate,
            };

            _db.CivilLiabilityInsurances.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = _db.CivilLiabilityInsurances.FirstOrDefault(c => c.Id == id);
            
            if(entity is null)
            {
                return;
            }

            _db.CivilLiabilityInsurances.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(CivilLiabilityInsuranceVM model)
        {
            var entity = await _db.CivilLiabilityInsurances.FindAsync(model.Id);

            if(entity is null)
            {
                return;
            }
            entity.CarId = model.CarId;
            entity.InsuranceCompanyName = model.InsuranceCompanyName;
            entity.IssueDate = model.IssueDate;
            entity.ExpiryDate = model.ExpiryDate;
            await _db.SaveChangesAsync();
        }

        public async Task<List<CivilLiabilityInsuranceVM>> GetAllAsync(string userId, int carId)
        {
            return await _db.CivilLiabilityInsurances
                .AsNoTracking()
                .Where(c => c.Car.UserId == userId && c.CarId == carId)
                .Select(c => new CivilLiabilityInsuranceVM
                {
                    Id = c.Id,
                    CarId = c.CarId,
                    InsuranceCompanyName = c.InsuranceCompanyName,
                    IssueDate = c.IssueDate,
                    ExpiryDate = c.ExpiryDate

                })
                .ToListAsync();
        }

        public async Task<CivilLiabilityInsuranceVM?> GetByIdAsync(int id)
        {
            return await _db.CivilLiabilityInsurances
               .AsNoTracking()
               .Where(c => c.Id == id)
               .Select(c => new CivilLiabilityInsuranceVM
               {
                   Id = c.Id,
                   CarId = c.CarId,
                   InsuranceCompanyName = c.InsuranceCompanyName,
                   IssueDate = c.IssueDate,
                   ExpiryDate = c.ExpiryDate
               })
               .FirstOrDefaultAsync();
                
        }
    }
}
