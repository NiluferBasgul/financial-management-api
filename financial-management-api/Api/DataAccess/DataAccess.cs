

namespace financial_management_api.Api.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly DbContext _context;

        public DataAccess(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public T GetById<T>(Guid id) where T : class
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _context.Set<T>().ToList();
        }

        public void Create<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete<T>(Guid id) where T : class
        {
            var entity = _context.Set<T>().Find(id);

            if (entity == null)
            {
                return;
            }

            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
