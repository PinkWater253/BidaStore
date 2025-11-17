namespace BidaStore.Client.Services
{
    public interface IAuthService
    {
        Task<bool> Login(string email, string password);
        Task Logout();
    }
}
