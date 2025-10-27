using AutoCare.ViewModels;

namespace AutoCare.Services.Contracts
{
    public interface IOilService
    {
        Task<List<OilServiceVM>> GetAllAsync(string userId, int carId);
        Task<OilServiceVM?> GetByIdAsync(int id);
        Task AddAsync(OilServiceVM model);
        Task EditAsync(OilServiceVM model);
        Task DeleteAsync(int id);
    }
}
