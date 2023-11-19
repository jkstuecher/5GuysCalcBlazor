using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http;
using _5GuysCalcBlazor;

namespace FiveGuysCalcBlazor.API
{
    [System.Web.Http.Route("api/menu")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public int ReturnPlusOne(int input)
        {
            return input++;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public int ReturnThree()
        {
            return 3;
        }
    }
}
