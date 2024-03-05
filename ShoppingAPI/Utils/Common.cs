using Microsoft.Extensions.Options;
using ShoppingAPI.Models;

namespace ShoppingAPI.Utils
{
    public class Common
    {
        shoppingdbContext db;
        private readonly IOptions<AppConfig> appSettings;

        public Common(shoppingdbContext _db, IOptions<AppConfig> appConfig)
        {
            db = _db;
            appSettings = appConfig;
        }

        public void LogToFile(string message)
        {
            string formattedDate = DateTime.Now.ToString("dd_MM_yyyy");
            string filePath = $"{formattedDate}_log_file.txt";
            string fullFilePath = Path.Combine(Environment.CurrentDirectory, "Logs", filePath);
            string logMessage = $"{message}\n{DateTime.Now}";

            if (File.Exists(fullFilePath))
            {
                using (StreamWriter writer = new StreamWriter(fullFilePath, true))
                {
                    writer.WriteLine(logMessage);
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(fullFilePath))
                {
                    writer.WriteLine(logMessage);
                }
            }
        }
    }
}
