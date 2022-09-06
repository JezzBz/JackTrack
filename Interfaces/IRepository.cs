namespace JackTrack.Interfaces
{
	public interface IRepository
	{
		public IQueryable<TEntity> GetAll<TEntity>()
			where TEntity : class;

		public TEntity? Get<TEntity>(long Id) 
			where TEntity : class, IWithId;
		public Task Add<TEntity>(TEntity entity) 
			where TEntity : class;

		public  Task Save<TEntity>(TEntity entity)
			where TEntity : class;

		public  Task Save();

		public void Attach<TEntity>(TEntity entity) 
			where TEntity : class;

		public void Attach<TEntity>(IEnumerable<TEntity> entity)
			where TEntity : class;
	}
}
