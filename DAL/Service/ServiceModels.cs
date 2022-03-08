using demo_WebAPI2.DAL;

namespace DAL.Service;

public class ServiceModels<T>:IService<T> where T : class
{
    private  DbWebContext _dbContext;

    public ServiceModels()
    {
        _dbContext = new DbWebContext();
    }


    public List<T> GetList()
    {

        try
        {
            
            return _dbContext.Set<T>().ToList();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public string Add(T @object)
    {
        try
        {
            _dbContext.Set<T>().Add(@object);
            return "successful";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string Edit(T @object)
    {
        try
        {
            _dbContext.Set<T>().Update(@object);
            return "successful";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string Delete(T @object)
    {
        try
        {
            _dbContext.Set<T>().Remove(@object);
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
            _dbContext.SaveChanges();
            return "successful";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }
}

