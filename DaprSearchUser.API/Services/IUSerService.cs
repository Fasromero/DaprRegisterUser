namespace DaprSearchUser.API.Services
{
    public interface IUserService
    {
        Task AddUserAsync(string userPartialName, Domain.User user);
        Task<Domain.User> GetUserAsync(string userId);
    }
}
