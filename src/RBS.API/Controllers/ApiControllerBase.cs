using Microsoft.AspNetCore.Mvc;

namespace RBS.API.Controllers
{
    [ApiController]
    [Filters.UserActionFilter]
    [Produces("application/json")]
    public class ApiControllerBase : ControllerBase
    {
        public Domain.UserModel UserModel { get; set; }
    }
}
