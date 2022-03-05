namespace DAL;

public interface IService<T>
{
    public List<T> GetList();
    public string Add(T sp);
    public string Edit(T sp);
    public string Delete(T sp);
    public string Save();

}