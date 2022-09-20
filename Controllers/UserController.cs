using JackTrack.Controllers.Base;
using JackTrack.Entities.DataBase;
using JackTrack.Entities.Http;
using JackTrack.Entities.Users;
using JackTrack.Entities.ViewModels;
using JackTrack.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace JackTrack.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : BaseController
	{
		private SignInManager<User> _signInManager;
		private UserManager<User> _userManager { get; set; }


		public UserController(Context context,UserManager<User> userManager,SignInManager<User> signInManager) : base(context)
		{
			_userManager = userManager;
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
	
			var email = User.Claims.GetEmail();

			if (email == null) return Ok(new ServerResponse(error:"Server error, try again later!"));

			var user = await _userManager.FindByEmailAsync(email);
			
			if (user == null) return Ok(new ServerResponse(error: "Failed to authorize!"));

			UserResultViewModel result = Copy(user, new UserResultViewModel());
			var response = new ServerResponse(result);

			return Ok(response);
		}
	}
}
