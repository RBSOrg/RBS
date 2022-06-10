using Microsoft.AspNetCore.Mvc.Filters;
using RBS.API.Controllers;
using System.Security.Claims;

namespace RBS.API.Filters
{
    public class UserActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Controller is ApiControllerBase c && c.User != null)
            {
                c.UserModel = new Domain.UserModel()
                {
                    UserId = Convert.ToInt32(c.User.FindFirstValue(ClaimTypes.NameIdentifier)),
                    UserName = c.User.FindFirstValue(ClaimTypes.Name),
                };
            }
        }
    }
}
