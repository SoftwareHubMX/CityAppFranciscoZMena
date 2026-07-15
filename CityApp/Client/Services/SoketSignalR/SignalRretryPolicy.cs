using Microsoft.AspNetCore.SignalR.Client;

namespace CityApp.Client.Services.SoketSignalR
{
    public class SignalRretryPolicy : IRetryPolicy
    {
        public TimeSpan? NextRetryDelay(RetryContext retryContext)
        {
            return TimeSpan.FromSeconds(10);
        }
    }
}
