namespace HumanResource.Services.Contracts;

public interface IGenericService<TEntity> where TEntity : class
{
    IEnumerable<TEntity> GetAll();
    TEntity GetById<T>(T id);
    void Insert(TEntity entity);
    void Delete(int id);
    void Update(TEntity entity);
}
