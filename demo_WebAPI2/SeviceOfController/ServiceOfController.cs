using DAL;
using DAL.Service;

using demo_WebAPI2.DAL.Models;
using demo_WebAPI2.Sevice.ModelsReturn;

namespace demo_WebAPI2.Sevice;

public class ServiceOfController
{
    private IService<Class> _classModel;
    private IService<Student> _studentModels;
    private List<Student> _lstStudents;
    private List<Class> _lstClasses;

    public ServiceOfController()
    {
        _classModel = new ServiceModels<Class>();
        _lstClasses = new List<Class>();
        _studentModels = new ServiceModels<Student>();
        _lstStudents = new List<Student>();
        GetDataClasses();
        GetDataStudents();
    }

    public List<Class> GetDataClasses()
    {
        _lstClasses = _classModel.GetList();
        return _lstClasses;
    }

    public List<Student> GetDataStudents()
    {
        _lstStudents = _studentModels.GetList();
        return _lstStudents;
    }

    public List<InfoStudent> GetInfoStudents()
    {
        List<InfoStudent> _lstStudentsShow = new List<InfoStudent>();
        var _lstTemp = from std in _lstStudents
                       join cls in _lstClasses on std.IdClass equals cls.IdClass
                       select new
                       {
                           IdSV = std.IdStudent,
                           tenSv = std.Name,
                           ngaySinh = std.birth,
                           lopHoc = cls.NameClass,
                           phonghoc = cls.Classroom
                       };

        foreach (var x in _lstTemp)
        {
            InfoStudent sv = new InfoStudent(x.IdSV, x.tenSv, x.ngaySinh, x.lopHoc, x.phonghoc);
            _lstStudentsShow.Add(sv);
        }

        return _lstStudentsShow;
    }

    //
    // Them SV
    public List<InfoStudent> AddInfoStudent(InfoStudent _infoStudent)
    {
        if (_lstClasses.Any(c => c.NameClass == _infoStudent.NameClass))
        {
            Student stNew = new Student();
            stNew.IdStudent = _infoStudent.IdStudent;
            stNew.Name = _infoStudent.NameStudent;
            stNew.birth = _infoStudent.Birth;
            stNew.IdClass = _lstClasses.FirstOrDefault(c => c.NameClass == _infoStudent.NameClass).IdClass;
            _studentModels.Add(stNew);
        }
        else
        {
            Class cls = new Class();
            cls.NameClass = _infoStudent.NameClass;
            cls.Classroom = _infoStudent.Classroom;
            _classModel.Add(cls);
            _classModel.Save();
            Student std = new Student();
            std.IdStudent = _infoStudent.IdStudent;
            std.Name = _infoStudent.NameStudent;
            std.birth = _infoStudent.Birth;
            std.IdClass = _classModel.GetList().FirstOrDefault(c => c.NameClass == _infoStudent.NameClass).IdClass;
            _studentModels.Add(std);
        }

        _studentModels.Save();
        GetDataClasses();
        GetDataStudents();
        return GetInfoStudents();
    }

    public List<InfoStudent> EditInfoStudent(InfoStudent _infoStudent)
    {
        if (_lstClasses.Any(c => c.NameClass == _infoStudent.NameClass))
        {
            Student stNew = _lstStudents[_lstStudents.FindIndex(c => c.IdStudent == _infoStudent.IdStudent)];
            stNew.IdStudent = _infoStudent.IdStudent;
            stNew.Name = _infoStudent.NameStudent;
            stNew.birth = _infoStudent.Birth;
            stNew.IdClass = _lstClasses.FirstOrDefault(c => c.NameClass == _infoStudent.NameClass).IdClass;
            _studentModels.Edit(stNew);
        }
        else
        {
            Class cls = new Class();
            cls.NameClass = _infoStudent.NameClass;
            cls.Classroom = _infoStudent.Classroom;
            _classModel.Add(cls);
            _classModel.Save();
            Student std = _lstStudents[_lstStudents.FindIndex(c => c.IdStudent == _infoStudent.IdStudent)];
            std.IdStudent = _infoStudent.IdStudent;
            std.Name = _infoStudent.NameStudent;
            std.birth = _infoStudent.Birth;
            std.IdClass = _classModel.GetList()[_classModel.GetList().FindIndex(c => c.NameClass == _infoStudent.NameClass)].IdClass;
            _studentModels.Edit(std);
        }
        _studentModels.Save();
        GetDataClasses();
        GetDataStudents();
        return GetInfoStudents();
    }

    public List<InfoStudent> DeleteInfoStudent(int idStudent)
    {
        Student std = _lstStudents[_lstStudents.FindIndex(c => c.IdStudent == idStudent)];
        _studentModels.Delete(std);
        _studentModels.Save();
        GetDataClasses();
        GetDataStudents();
        return GetInfoStudents();
    }

    public string SaveChange()
    {
        return _studentModels.Save();
    }
}