using AutoCare.ViewModels;

namespace AutoCare.Services.Contracts
{
    public interface IBeltService
    {
        Task<List<BeltServiceVM>> GetAllAsync();
        Task<BeltServiceVM?> GetByIdAsync(int id);
        Task AddAsync(BeltServiceVM model);
        Task UpdateAsync(BeltServiceVM model);
        Task DeleteAsync(int id);
    }
}
