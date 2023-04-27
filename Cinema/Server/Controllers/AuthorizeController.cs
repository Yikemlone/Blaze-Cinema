using Cinema.DataAccess.Context;
using Cinema.Models.Models;
using Cinema.Shared;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cinema.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthorizeController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly CinemaDBContext _context;

        public AuthorizeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, CinemaDBContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginParameters parameters)
        {
            var user = await _userManager.FindByNameAsync(parameters.UserName);
            if (user == null) return BadRequest("User does not exist");
            var singInResult = await _signInManager.CheckPasswordSignInAsync(user, parameters.Password, false);
            if (!singInResult.Succeeded) return BadRequest("Invalid password");

            await _signInManager.SignInAsync(user, parameters.RememberMe);

            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterParameters parameters)
        {
            var user = new ApplicationUser();

            user.Id = Guid.NewGuid();
            user.UserName = parameters.UserName;
            user.SecurityStamp = Guid.NewGuid().ToString();
            user.EmailConfirmed = false;
            user.NormalizedUserName = parameters.UserName.ToUpper();

            var result = await _userManager.CreateAsync(user, parameters.Password);

            if (!result.Succeeded ) return BadRequest(result.Errors.FirstOrDefault()?.Description);

            //var adminClaim = new Claim("AdminRole", "admin");
            var customerClaim = new Claim("CustomerRole", "customer");

            var custSucc = await _userManager.AddClaimAsync(user, customerClaim);
            //var claimsSucc = await _userManager.AddClaimAsync(user, adminClaim);

            if (!custSucc.Succeeded) return BadRequest(result.Errors.FirstOrDefault()?.Description);

            return await Login(new LoginParameters
            {
                UserName = parameters.UserName,
                Password = parameters.Password
            });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<UserInfo> UserInfo()
        {
            //var user = await _userManager.GetUserAsync(HttpContext.User);
            return await BuildUserInfo();
        }


        private async Task<UserInfo> BuildUserInfo()
        {
            var UserID = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Guid? guid = null;

            if (UserID != null) 
            {
                guid = UserID.Id;
            }

            return new UserInfo
            {
                IsAuthenticated = User.Identity.IsAuthenticated,
                UserName = User.Identity.Name,
                ExposedClaims = User.Claims
                    //Optionally: filter the claims you want to expose to the client
                    //.Where(c => c.Type == "test-claim")
                    .ToDictionary(c => c.Type, c => c.Value),
                UserID = guid
            };
        }
    }
}
