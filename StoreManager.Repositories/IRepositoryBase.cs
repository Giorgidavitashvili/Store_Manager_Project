namespace StoreManager.Repositories;

public interface IRepositoryBase<T>
{
    T? Get(int id);
    IEnumerable<T> Get();
    int Insert(T record);
    void Update(T record);
    void Delete(object id);
}