using FluentNHibernate.Data;
using JackTrack.Controllers.Base;
using JackTrack.Entities.DataBase;
using JackTrack.Entities.Messages.Missions;
using JackTrack.Entities.Tasks;
using JackTrack.Entities.Users;
using JackTrack.Entities.ViewModels.Missions;
using JackTrack.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
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
		public IActionResult Get([FromBody]GetMissionsMessage message)
		{
			var query = Repository.GetAll<Mission>()
				.Where(q => q.ProjectId == message.ProjectId);
			
			if (message.Filters != null)
			{
				query = query = Filter(message, query);
	
			}
			
			var result = query.ToList();

			return Ok(query.ToList()); 
		}

		[HttpPost("add")]
		public async Task<IActionResult> Add([FromBody]AddMissionViewModel model)
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

		private IQueryable<Mission> Filter(GetMissionsMessage message, IQueryable<Mission> query)
		{
			if (message.Filters.UserIds != null && message.Filters.UserIds.Any())
			{
				query = query
					.Where(q => q.ToUsers.Any(u => message.Filters.UserIds.ToList().Contains(u.Id))
					|| message.Filters.UserIds.Any(ui => ui == q.FromUserId));
			}
			return query;
		}

	}
}
