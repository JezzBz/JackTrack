using JackTrack.ActionFilters;
using JackTrack.Controllers.Base;
using JackTrack.Entities.DataBase;
using JackTrack.Entities.Projects;
using JackTrack.Entities.ViewModels.Projects;
using JackTrack.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JackTrack.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ProjectsController : BaseController
	{
		public ProjectsController(Context context):base(context)
		{

		}

		[HttpPost("project")]
		[UserProject]
		public IActionResult Get(GetProjectsViewModel model)
		{
			var project = Repository.GetAll<Project>().FirstOrDefault(q => q.Id == model.ProjectId);
			
			return ServerResponse(project);
		}

		[HttpPost]
		public IActionResult GetAll()
		{
			var project = Repository.GetAll<Project>().Where(q => q.Users.Any(u => u.Id == User.Claims.GetId()));
			
			return ServerResponse(project);
		}

	}
}
