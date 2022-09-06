using JackTrack.Controllers.Base;
using JackTrack.Entities.DataBase;
using JackTrack.Entities.Tasks;
using JackTrack.Entities.Users;
using JackTrack.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JackTrack.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TasksController : BaseController
	{

		public TasksController(Context context) : base(context)
		{

		}

		[HttpGet]
		public IActionResult Get()
		{
			var a = Repository.GetAll<Mission>().Where(q => q.Id > 0).ToList();


			return Ok(a); 
		}
	}
}
