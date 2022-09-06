using JackTrack.Interfaces;

namespace JackTrack.Entities.DataBase
{
	public class Repository:IRepository
	{

		private readonly Context _context;
		public Repository(Context context)
		{
			_context = context;
		}

		public TEntity? Get<TEntity>(long Id) 
			where TEntity : class, IWithId 
			=> _context.Set<TEntity>().FirstOrDefault(q => q.Id == Id);

		public IQueryable<TEntity> GetAll<TEntity>() 
			where TEntity : class 
			=> _context.Set<TEntity>().Select(q => q);
	}
}
