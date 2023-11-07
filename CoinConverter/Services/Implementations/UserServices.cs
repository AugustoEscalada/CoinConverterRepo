using CoinConverter.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoinConverter.Services.Implementations
{
    using CoinConverter.Services;
    using Microsoft.AspNetCore.Mvc;

   
        [ApiController]
        [Route("api/[controller]")]
        public class UserController : Controller
        {
            private readonly UserServices _userServices;

            public UserController(UserServices userServices)
            {
                _userServices = userServices;
            }
        }
    
}
