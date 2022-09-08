using JackTrack.Controllers.Base;
using JackTrack.Entities.DataBase;
using JackTrack.Entities.Users;
using JackTrack.Entities.ViewModels;
using JackTrack.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

			if (user.PasswordHash == model.Password.Hash())
			{
				await _signInManager.SignInAsync(user,true);
				return Ok("Sucessed!");
			}

			return Ok("Incorrect login or password!");
		} 
	}
}
