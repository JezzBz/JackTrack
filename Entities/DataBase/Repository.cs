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

		public async Task Add<TEntity>(TEntity entity)
			where TEntity : class
			=> await  _context.AddAsync(entity);

		public async Task Save<TEntity>(TEntity entity)
			where TEntity : class
		{
			await Add(entity);
			await _context.SaveChangesAsync();
		}
		
		public async Task Save() => await  _context.SaveChangesAsync();

		public  void Attach<TEntity>(TEntity entity) where TEntity : class  => _context.Set<TEntity>().Attach(entity);

		public  void Attach<TEntity>(IEnumerable<TEntity> entity) where TEntity : class => _context.Set<TEntity>().AttachRange(entity);
	}
}
