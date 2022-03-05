using demo_WebAPI2.DAL;

namespace DAL.Service;

public class ServiceModels<T>:IService<T> where T : class
{
    private DbWebContext _dnContext;

    public ServiceModels()
    {
        _dnContext = new DbWebContext();
    }


    public List<T> GetList()
    {

        try
        {
            
            return _dnContext.Set<T>().ToList();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public string Add(T sp)
    {
        try
        {
            _dnContext.Set<T>().Add(sp);
            return "successful";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string Edit(T sp)
    {
        try
        {
            _dnContext.Set<T>().Update(sp);
            return "successful";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string Delete(T sp)
    {
        try
        {
            _dnContext.Set<T>().Remove(sp);
            return "successful";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string Save()
    {
        try
        {
            _dnContext.SaveChanges();
            return "successful";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }
}

