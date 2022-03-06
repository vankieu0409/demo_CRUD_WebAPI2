namespace DAL;

public interface IService<T>
{
    public List<T> GetList();
    public string Add(T @object);
    public string Edit(T @object);
    public string Delete(T @object);
    public string Save();

}