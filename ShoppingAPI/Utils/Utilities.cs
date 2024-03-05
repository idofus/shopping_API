using Microsoft.Extensions.Options;

namespace ShoppingAPI.Utils
{
    public class Utilities
    {
        private readonly IOptions<AppConfig> appSettings;

        public Utilities(IOptions<AppConfig> appConfig)
        {
            appSettings = appConfig;
        }
    }
}
