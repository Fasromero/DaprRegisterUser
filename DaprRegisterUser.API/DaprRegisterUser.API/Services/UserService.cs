using Dapr.Client;
using DaprRegisterUser.API.Domain;

namespace DaprRegisterUser.API.Services
{
    public class UserService : IUserService
    {

        private readonly DaprClient _daprClient;
        private static readonly string storeName = "statestore";

        public UserService(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }
        async Task<Domain.User> IUserService.GetUserAsync(string userName)
        {
            var user = await _daprClient.GetStateAsync<Domain.User>(storeName, userName.ToString());
            if (user == null)
            {
                user = new Domain.User()
                {
                    UserName = userName
                };
            }

            return user;
        }

    }
}
