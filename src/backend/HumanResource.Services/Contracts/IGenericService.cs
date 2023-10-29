namespace HumanResource.Services.Contracts;

public interface IGenericServie<T> where T : class
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Insert(T entity);
    void Delete(int id);
    void Update(T entity);
}
