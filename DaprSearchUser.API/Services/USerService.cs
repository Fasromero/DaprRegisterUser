using Dapr.Client;
using DaprSearchUser.API.Domain;
using User = DaprSearchUser.API.Domain.User;

namespace DaprSearchUser.API.Services
{
    public class UserService : IUserService
    {
        private readonly DaprClient _daprClient;
        private static readonly string storeName = "statestore";
        public UserService(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }

        public async Task<Domain.User> GetUserAsync(string userName)
        {
            var user = await _daprClient.GetStateAsync<Domain.User>(storeName, userName.ToString());

            user ??= new Domain.User()
                {
                    UserName = userName
                };

            return user;
        }
        public async Task AddUserAsync(string userPartialName, Domain.User user)
        {
            Domain.User userToBeAdded = await GetUserAsync(userPartialName);

            if (!userToBeAdded.UserName.Contains(user.UserName))
            {
                await _daprClient.SaveStateAsync(storeName, user.UserName, user);
            }
        }

    }
}
