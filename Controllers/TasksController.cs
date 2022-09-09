using FluentNHibernate.Data;
using JackTrack.Controllers.Base;
using JackTrack.Entities.DataBase;
using JackTrack.Entities.Http;
using JackTrack.Entities.Messages.Missions;
using JackTrack.Entities.Tasks;
using JackTrack.Entities.Users;
using JackTrack.Entities.ViewModels.Missions;
using JackTrack.Extensions;
using JackTrack.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Task = System.Threading.Tasks.Task;

namespace JackTrack.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(Roles = "Admin")]
	public class TasksController : BaseController
	{
		public TasksController(Context context, UserManager<User> userManager,RoleManager<Role> roleManager) : base(context)
		{
		}



		[HttpPost]
		public IActionResult Get([FromBody]GetMissionsMessage message)
		{
			var query = Repository.GetAll<Mission>()
				.Include(q => q.ToUsers)
				.Where(q => q.ProjectId == message.ProjectId);
			
			if (message.Filters != null)
			{
				query = query = Filter(message, query);
	
			}
			
			var queryResult = query.ToList();

			var result = new List<GetMissionViewModel>();
			foreach (var mission in queryResult)
			{
				var model = Copy(mission,new GetMissionViewModel());
				model.ToUsersIds = mission.ToUsers.Select(q => q.Id);
				result.Add(model);
			}

			var response = new ServerResponse(result);

			return Ok(response); 
		}

		[HttpPost("add")]
		public async Task<IActionResult> Add([FromBody]AddMissionViewModel model)
		{
			var entity = new Mission();

			model = PrepareModel(entity,model);
			entity = Copy(model,entity);
			entity.ToUsers = model.ToUsers;
			await Repository.Save(entity);			
			
			var result = Copy(entity,new GetMissionViewModel());

			result.ToUsersIds = model.ToUsers?.Select(q => q.Id);

			var response = new ServerResponse(result);

			return Ok(response);
		}




		private AddMissionViewModel PrepareModel(Mission entity, AddMissionViewModel model)
		{
			
			var users = Repository.GetAll<User>()
				.Where(q => model.ToUsersIds.Contains(q.Id))
				.ToList();

			model.ToUsers = users; 

			return model;
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
