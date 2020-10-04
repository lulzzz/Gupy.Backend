using System.Net;
using Gupy.Api.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Gupy.Api.Controllers.Api
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        public override OkObjectResult Ok(object value)
        {
            var response = new ApiResponse<object>(HttpStatusCode.OK, value);
            return base.Ok(response);
        }

        public override CreatedAtActionResult CreatedAtAction(string actionName, object routeValues, object value)
        {
            var response = new ApiResponse<object>(HttpStatusCode.Created, value);
            return base.CreatedAtAction(actionName, routeValues, response);
        }
    }
}