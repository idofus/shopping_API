using Microsoft.Extensions.Options;
using ShoppingAPI.Controllers;
using ShoppingAPI.Models;
using ShoppingAPI.Utils;
using static ShoppingAPI.Utils.Entity;

namespace ShoppingAPI.Services
{
    public class LoginServices
    {
        shoppingdbContext db;
        ILogger<LoginController> logger;
        private readonly IOptions<AppConfig> appSettings;
        Utilities _Utils;
        Common cmn;

        public LoginServices(shoppingdbContext _db, ILogger<LoginController> _logger, IOptions<AppConfig> appConfig)
        {
            db = _db;
            logger = _logger;
            appSettings = appConfig;
            _Utils = new Utilities(appConfig);
        }

        public ResponseObj<object> GetUserDetails()
        {
            var responseObj = new ResponseObj<object>();
            try
            {
                var userDetails = (from q in db.Admindetails
                                    select new
                                    {
                                       q.Id,
                                       q.UserName, 
                                       q.Password,
                                       q.MobileNumber,
                                    }).ToList();

                responseObj.responseCode = 200;
                responseObj.isSuccess = true;
                responseObj.data = userDetails;
                return responseObj;
            }
            catch (Exception ex)
            {
                responseObj.responseCode = 500;
                responseObj.isSuccess = false;
                responseObj.data = ex.Message;
                return responseObj;
            }
        }
    

    }
}
