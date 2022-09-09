using FluentNHibernate.Automapping;
using JackTrack.Entities.DataBase;
using JackTrack.Entities.Users;
using JackTrack.Extensions;
using JackTrack.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace JackTrack.Controllers.Base
{
	public  class BaseController : ControllerBase
	{
		protected static ISession Session { get; set; }
		protected IRepository Repository { get; set; }


		public BaseController(Context context)
		{
			Repository = new Repository(context);
		}
		
		


		protected virtual TEntity Copy<TEntity>(object message, TEntity entity) where TEntity : class
		{
			var sourceProperties = message.GetType().GetProperties();

			foreach (var prop in sourceProperties)
			{

				var entityProperty = entity.GetType().GetProperty(prop.Name);
				
				if (entityProperty == null) continue;

				entityProperty.SetValue(entity, prop.GetValue(message));
			}

			return entity;
		}

	
	
	}
}
