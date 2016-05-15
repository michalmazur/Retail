using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Retail.Models;
using Retail.ViewModels;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Retail.Controllers.Api
{
    [Route("session")]
    public class AuthController : Controller
    {
        private readonly SignInManager<RetailUser> signInManager;
        private readonly UserManager<RetailUser> userManager;

        public AuthController(SignInManager<RetailUser> signInManager, UserManager<RetailUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody]LoginViewModel vm)
        {
            try {
                if (ModelState.IsValid)
                {
                    var signInResult = await signInManager.PasswordSignInAsync(vm.Username, vm.Password, true, false);
                    if (signInResult.Succeeded)
                    {
                        var user = await userManager.FindByNameAsync("user");
                        return Json(new { id = user.Id, username = user.UserName });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Username or password incorrect");
                        Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        return Json(new {Errors = ModelState });
                    }
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json(new { Errors = ModelState });
                }
            }
            catch
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new EmptyResult();
            }
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> Logout()
        {
            try {
                if (User.Identity.IsAuthenticated)
                {
                    await signInManager.SignOutAsync();
                }
                Response.StatusCode = (int)HttpStatusCode.OK;
                return new EmptyResult();
            }
            catch
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new EmptyResult();
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Profile()
        {
            try
            {
                return Json(new { id = User.GetUserId(), username = User.GetUserName() });
            }
            catch
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new EmptyResult();
            }
        }

    }
}
