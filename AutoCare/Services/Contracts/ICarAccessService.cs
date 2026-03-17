namespace AutoCare.Services.Contracts
{
    public interface ICarAccessService
    {
        Task<bool> UserOwnsCarAsync(string userId, int carId);
    }
}
