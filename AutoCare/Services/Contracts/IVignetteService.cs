using AutoCare.ViewModels;

namespace AutoCare.Services.Contracts
{
    public interface IVignetteService
    {
        Task<List<VignetteVM>> GetAllAsync();
        Task<VignetteVM?> GetByIdAsync(int id);
        Task AddAsync(VignetteVM model);
        Task UpdateAsync(VignetteVM model);
        Task DeleteAsync(int id);
    }
}
