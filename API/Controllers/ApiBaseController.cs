using API.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public abstract class ApiBaseController : ControllerBase
    {
        public bool IsSystemAdmin => HttpContext.IsSystemAdmin();

        protected string AccountId => HttpContext.GetAccountId();

        public string UserEmail => HttpContext.GetEmail();

        public string UserName => HttpContext.GetName();

        public string UserCurrentRole => HttpContext.GetRole();

        /// <summary>
        /// The current user logged in.
        /// </summary>
        protected string UserId => HttpContext.GetUserId();
    }
}