namespace HumanResource.Repositories.Contracts;

public interface IGenericRepository<TEntity> where TEntity : class
{
    IEnumerable<TEntity> All();
    TEntity GetById(object id);
    void Insert(TEntity entity);
    void Delete(int id);
    void Update(TEntity entity);
}
