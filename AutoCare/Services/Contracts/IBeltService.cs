using AutoCare.ViewModels;

namespace AutoCare.Services.Contracts
{
    public interface IBeltService
    {
        Task<List<BeltServiceVM>> GetAllAsync(string userId, int carId);
        Task<BeltServiceVM?> GetByIdAsync(int id);
        Task AddAsync(BeltServiceVM model);
        Task EditAsync(BeltServiceVM model);
        Task DeleteAsync(int id);
    }
}
