using AutoCare.ViewModels;

namespace AutoCare.Services.Contracts
{
    public interface ICarService
    {
        Task<List<CarViewModel>> GetAllAsync(string userId);
        Task<CarViewModel?> GetByIdAsync(int id);
        Task AddAsync(CarViewModel model, string userId);
        Task EditAsync(CarViewModel model);
        Task DeleteAsync(int id);
        Task<bool> UserOwnsCarAsync(string userId, int carId);
    }
}
