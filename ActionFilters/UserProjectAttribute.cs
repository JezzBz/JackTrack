using JackTrack.Entities.DataBase;
using JackTrack.Entities.Projects;
using JackTrack.Entities.ViewModels.Missions;
using JackTrack.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NHibernate.Util;
using System.Net;
using System.Text.Json;

namespace JackTrack.ActionFilters
{
	/// <summary>
	/// Reqiure model parameter with ProjectId property
	/// </summary>
	//Display that user can access to project
	public class UserProjectAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (filterContext.HttpContext.User.IsInRole("Admin"))
			{
				return;
			}

			if (!filterContext.ActionArguments.ContainsKey("model")) filterContext.Result = new BadRequestResult();


			var dbContext = filterContext.HttpContext
			.RequestServices
			.GetService(typeof(Context)) as Context;

			var repository = new Repository(dbContext);

			var modelObject = filterContext.ActionArguments["model"];

			if(!modelObject.GetType().HasProperty("ProjectId")) filterContext.Result = new BadRequestResult();

			var userId = filterContext.HttpContext.User.Claims.GetId();


			var requestProjectId = (long)modelObject.GetType().GetProperty("ProjectId").GetValue(modelObject);
			
			var  connected = repository.GetAll<Project>()
				.Where(q => q.Users.Any(q => q.Id == userId))
				.Any(q => q.Id == requestProjectId);


			if (connected) filterContext.Result = new BadRequestResult();
		}
		private interface IHasProjectId
		{
			long ProjectId { get; set; }
		}
	}
}
