using JackTrack.Controllers.Base;
using JackTrack.Entities.DataBase;
using JackTrack.Entities.Http;
using JackTrack.Entities.Users;
using JackTrack.Entities.ViewModels;
using JackTrack.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace JackTrack.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : BaseController
	{
		private SignInManager<User> _signInManager;
		private UserManager<User> _userManager { get; set; }

		private RoleManager<Role> _roleManager;

		public UserController(Context context,UserManager<User> userManager,SignInManager<User> signInManager, RoleManager<Role> roleManager) : base(context)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;	
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody]LoginViewModel model)
		{
			var user = await _userManager.FindByEmailAsync(model.Email);

			

			if (user != null && user.PasswordHash == model.Password.Hash())
			{
				await _signInManager.SignInAsync(user,true);

				UserResultViewModel userResult = Copy(user, new UserResultViewModel());
				
				var response = new ServerResponse(userResult);
				return Ok(response);
			
			}

			return Ok(new ServerResponse(error:"Invalid login or password!"));
		}


		[HttpPost("authorized")]
		[Authorize]
		public async Task<IActionResult> IsAthorized()
		{
			var identity = (ClaimsIdentity)User.Identity;
			IEnumerable<Claim> claims = identity.Claims;

			var email = claims.FirstOrDefault(q => q.Type == ClaimTypes.Email).Value;

			if (email == null) return Ok(new ServerResponse(error:"Server error, try again later!"));

			var user = await _userManager.FindByEmailAsync(email);

			if (user == null) return Ok(new ServerResponse(error: "Failed to authorize!"));

			UserResultViewModel result = Copy(user, new UserResultViewModel());
			var response = new ServerResponse(result);

			return Ok(response);
		}
	}
}
