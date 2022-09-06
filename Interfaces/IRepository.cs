namespace JackTrack.Interfaces
{
	public interface IRepository
	{
		public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;

		public TEntity? Get<TEntity>(long Id) where TEntity : class, IWithId;
	}
}
