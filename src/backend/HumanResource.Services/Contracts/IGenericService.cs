namespace HumanResource.Services.Contracts;

public interface IGenericService<T> where T : class
{
    IEnumerable<T> GetAll();
    T GetById(object id);
    void Insert(T entity);
    void Delete(int id);
    void Update(T entity);
}
