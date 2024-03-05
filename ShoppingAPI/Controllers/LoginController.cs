using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ShoppingAPI.Models;
using ShoppingAPI.Services;
using ShoppingAPI.Utils;
using static ShoppingAPI.Utils.Entity;

namespace ShoppingAPI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IOptions<AppConfig> appSettings;
        shoppingdbContext db;
        LoginServices _loginServices;
        IWebHostEnvironment env;
        private IConfiguration _config;
        private readonly ILogger<LoginController> _logger;
        Common cmn;

        public LoginController(IOptions<AppConfig> appConfig, shoppingdbContext dbContext, IWebHostEnvironment env, IConfiguration config, ILogger<LoginController> logger)
        {
            appSettings = appConfig;
            db = dbContext;
            _loginServices = new LoginServices(dbContext, logger, appSettings);
            this.env = env;
            _config = config;
            _logger = logger;
            cmn = new Common(dbContext, appConfig);
        }

        [HttpGet]
        [Route("api/Login/GetUserDetails")]
        public async Task<object> GetUserDetails()
        {
            try
            {
                cmn.LogToFile("API Name : api/Login/GetUserDetails | " + "req : none " );

                var response = await Task.FromResult(_loginServices.GetUserDetails());

                if (response.isSuccess == true)
                {
                    cmn.LogToFile("API Name : api/Login/GetUserDetails | " + "Message : Success");
                }

                else if (response.isSuccess == false)
                {
                    cmn.LogToFile("API Name : api/Login/GetUserDetails | " + "Message : Failed");
                }

                cmn.LogToFile("API Name : api/Login/GetUserDetails | " + "Response Data : " + response.data);

                return new
                {
                    status = response.isSuccess,
                    statusCode = response.responseCode,
                    time = DateTime.Now,
                    data = response.data,
                };

            }
            catch (Exception ex)
            {
                cmn.LogToFile("API Name : api/Login/GetUserDetails | " + "Message : " + ex.Message);

                Response.StatusCode = 500;
                return new { status = appSettings.Value.errorMessage, time = DateTime.Now, data = ex.Message, data2 = ex.StackTrace };
            }
        }



    }
}
