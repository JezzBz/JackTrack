using JackTrack.Entities.DataBase;
using JackTrack.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JackTrack.Controllers.Base
{
	public class BaseController : ControllerBase
	{
		public  BaseController(Context context)
		{
			Repository = new Repository(context);
		}
		protected IRepository Repository { get; set; }
	}
}
