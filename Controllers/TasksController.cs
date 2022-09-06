using FluentNHibernate.Data;
using JackTrack.Controllers.Base;
using JackTrack.Entities.DataBase;
using JackTrack.Entities.Tasks;
using JackTrack.Entities.Users;
using JackTrack.Entities.ViewModels;
using JackTrack.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task = System.Threading.Tasks.Task;

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
			var missions = Repository.GetAll<Mission>().Where(q => q.Id > 0).ToList();

			AddMissionViewModel model = Copy<AddMissionViewModel>(missions[0], new AddMissionViewModel());
			return Ok( model); 
		}

		[HttpPost("add")]
		public async Task<IActionResult> Add([FromBody] AddMissionViewModel model)
		{
			var entity = new Mission();

			entity = PrepareEntity(entity,model);
			entity = Copy(model,entity);


			await Repository.Save(entity);			
			
			return Ok(entity);
		}

		private Mission PrepareEntity(Mission entity,AddMissionViewModel model)
		{
			
			entity.ToUsers = model.ToUsersIds?.Select(q => new User() { Id = q });

			var users = Repository.GetAll<User>()
				.Where(q => model.ToUsersIds.Contains(q.Id))
				.ToList();

			entity.FromUserId = model.FromUserId;
			entity.ToUsers = users; 

			return entity;
		}


	}
}
