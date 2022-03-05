using DAL;
using DAL.Service;
using demo_WebAPI2.DAL.Models;
using demo_WebAPI2.Sevice.ModelsReturn;

namespace demo_WebAPI2.Sevice;

public class ServiceShow
{
    private IService<Class> clasService;
    IService<Student> studentService;
    private List<Student> _lstStudents;
    private List<Class> _lstClasses;

    public ServiceShow()
    {
        clasService = new ServiceModels<Class>();
        _lstClasses = new List<Class>();
        studentService = new ServiceModels<Student>();
        _lstStudents= new List<Student>();
        GetDataClasses();
        GetDataStudents();
    }

    public List<Class> GetDataClasses()
    {
        _lstClasses = clasService.GetList();
        return _lstClasses;
    }

    public List<Student> GetDataStudents()
    {
        _lstStudents = studentService.GetList();
        return _lstStudents;
    }

    public List<InfoStudent> GetInfoStudents()
    {
        List<InfoStudent> _lstStudentsShow = new List<InfoStudent>();
        var _lstTemp = from std in _lstStudents
            join cls in _lstClasses on std.IdClass equals cls.IdClass 
            select new
            {
                IdSV=std.IdStudent,
                tenSv=std.Name,
                ngaySinh=std.birth,
                lopHoc=cls.NameClass,
                phonghoc=cls.Classroom
            };

        foreach (var x in _lstTemp)
        {
            InfoStudent sv=new InfoStudent(x.IdSV, x.tenSv, x.ngaySinh, x.lopHoc,x.phonghoc);
            _lstStudentsShow.Add(sv);
        }

        return _lstStudentsShow;
    }

    //
    // Them SV
    public List<InfoStudent> AddInfoStudent(InfoStudent s)
    {
        if (_lstClasses.Any(c=>c.NameClass==s.NameClass))
        {
            Student stNew = new Student();
            stNew.IdStudent = s.IdStudent;
            stNew.Name = s.NameStudent;
            stNew.birth = s.Birth;
            stNew.IdClass = _lstClasses.FirstOrDefault(c => c.NameClass == s.NameClass).IdClass;
            studentService.Add(stNew);
        }
        else
        {
            Class cls = new Class();
            cls.NameClass=s.NameClass;
            cls.Classroom = s.Classroom;
            clasService.Add(cls);
            clasService.Save();
            Student std = new Student();
            std.IdStudent = s.IdStudent;
            std.Name = s.NameStudent;
            std.birth = s.Birth;
            std.IdClass = clasService.GetList().FirstOrDefault(c => c.NameClass == s.NameClass).IdClass;
            studentService.Add(std);
        }
        
        studentService.Save();
        GetDataClasses();
        GetDataStudents();
        return GetInfoStudents();
    }

    public List<InfoStudent> EditInfoStudent(InfoStudent s)
    {
        if (_lstClasses.Any(c => c.NameClass == s.NameClass))
        {
            Student stNew = _lstStudents[_lstStudents.FindIndex(c=>c.IdStudent==s.IdStudent)];
            stNew.IdStudent = s.IdStudent;
            stNew.Name = s.NameStudent;
            stNew.birth = s.Birth;
            stNew.IdClass = _lstClasses.FirstOrDefault(c => c.NameClass == s.NameClass).IdClass;
            studentService.Edit(stNew);
        }
        else
        {
            Class cls = new Class();
            cls.NameClass = s.NameClass;
            cls.Classroom = s.Classroom;
            clasService.Add(cls);
            clasService.Save();
            Student std = _lstStudents[_lstStudents.FindIndex(c => c.IdStudent == s.IdStudent)];
            std.IdStudent = s.IdStudent;
            std.Name = s.NameStudent;
            std.birth = s.Birth;
            std.IdClass = clasService.GetList()[clasService.GetList().FindIndex(c=>c.NameClass==s.NameClass)].IdClass;
            studentService.Edit(std);
        }
        studentService.Save();
        GetDataClasses();
        GetDataStudents();
        return GetInfoStudents();
    }

    public List<InfoStudent> DeleteInfoStudent(int s)
    {
        Student std = _lstStudents[_lstStudents.FindIndex(c => c.IdStudent == s)];
        studentService.Delete(std);
        studentService.Save();
        GetDataClasses();
        GetDataStudents();
        return GetInfoStudents();
    }

    public string SaveChange()
    {
        return studentService.Save();
    }
}