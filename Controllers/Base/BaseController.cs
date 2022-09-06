﻿using FluentNHibernate.Automapping;
using JackTrack.Entities.DataBase;
using JackTrack.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace JackTrack.Controllers.Base
{
	public class BaseController : ControllerBase
	{
		public  BaseController(Context context)
		{
			Repository = new Repository(context);
			
		}
		protected IRepository Repository { get; set; }


		protected virtual TEntity Copy<TEntity>(object message, TEntity entity) where TEntity : class
		{
			var sourceProperties = message.GetType().GetProperties();

			foreach (var prop in sourceProperties)
			{

				var entityProperty = entity.GetType().GetProperty(prop.Name);

				if (entityProperty?.GetValue(entity) != null) continue;
				
				if (entityProperty == null) continue;

				entityProperty.SetValue(entity, prop.GetValue(message));
			}

			return entity;
		}

	
	}
}
