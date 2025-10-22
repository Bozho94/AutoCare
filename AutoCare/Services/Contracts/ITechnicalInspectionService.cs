using AutoCare.ViewModels;

namespace AutoCare.Services.Contracts
{
    public interface ITechnicalInspectionService
    {
        Task<List<TechnicalInspectionVM>> GetAllAsync();
        Task<TechnicalInspectionVM?> GetByIdAsync(int id);
        Task AddAsync(TechnicalInspectionVM model);
        Task UpdateAsync(TechnicalInspectionVM model);
        Task DeleteAsync(int id);
    }
}
