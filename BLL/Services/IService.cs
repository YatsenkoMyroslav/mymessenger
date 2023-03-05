namespace BLL.Services;

public interface IService<T1,T2> 
    where T1: class 
    where T2: class
{
    Task<T2> AddAsync(T2 entity);
    Task<T2> DeleteAsync(int id);
    Task UpdateAsync(T2 entity);
    Task<IEnumerable<T2>> GetAllAsync();
    T2 Get(int id);
    Task<T2> GetAsync(int id);

}