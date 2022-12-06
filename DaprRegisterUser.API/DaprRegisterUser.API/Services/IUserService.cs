namespace DaprRegisterUser.API.Services
{
    public interface IUserService
    {
        Task<Domain.User> GetUserAsync(string userId);
    }
}
