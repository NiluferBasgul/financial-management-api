namespace financial_management_api.Api.DataAccess
{
    public interface IDataAccess
    {
        T GetById<T>(Guid id) where T : class;
        IEnumerable<T> GetAll<T>() where T : class;
        void Create<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(Guid id) where T : class;
    }
}
