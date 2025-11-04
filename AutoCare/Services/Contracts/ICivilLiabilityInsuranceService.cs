using AutoCare.ViewModels;

namespace AutoCare.Services.Contracts
{
    public interface ICivilLiabilityInsuranceService
    {
        Task<List<CivilLiabilityInsuranceVM>> GetAllAsync(string userId, int carId);
        Task<CivilLiabilityInsuranceVM?> GetByIdAsync(int id);
        Task AddAsync(CivilLiabilityInsuranceVM model);
        Task EditAsync(CivilLiabilityInsuranceVM model);
        Task DeleteAsync(int id);
    }
}
