using AutoCare.ViewModels;

namespace AutoCare.Services.Contracts
{
    public interface ITechnicalInspectionService
    {
        Task<List<TechnicalInspectionVM>> GetAllAsync(string userId, int carId);
        Task<TechnicalInspectionVM?> GetByIdAsync(int id);
        Task AddAsync(TechnicalInspectionVM model);
        Task EditAsync(TechnicalInspectionVM model);
        Task DeleteAsync(int id);
    }
}
