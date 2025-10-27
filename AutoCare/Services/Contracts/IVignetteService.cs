using AutoCare.ViewModels;

namespace AutoCare.Services.Contracts
{
    public interface IVignetteService
    {
        Task<List<VignetteVM>> GetAllAsync(string userId, int carId);
        Task<VignetteVM?> GetByIdAsync(int id);
        Task AddAsync(VignetteVM model);
        Task EditAsync(VignetteVM model);
        Task DeleteAsync(int id);
    }
}
