namespace demo_WebAPI2.Sevice.ModelsReturn;

public class InfoStudent
{
    private int idStudent;
    private string nameStudent;
    private DateTime birth;
    private string nameClass;

    public InfoStudent()
    {

    }

    public InfoStudent(int idStudent, string nameStudent, DateTime birth, string nameClass)
    {
        this.idStudent = idStudent;
        this.nameStudent = nameStudent;
        this.birth = birth;
        this.nameClass = nameClass;
    }

    public int IdStudent
    {
        get => idStudent;
        set => idStudent = value;
    }

    public string NameStudent
    {
        get => nameStudent;
        set => nameStudent = value ?? throw new ArgumentNullException(nameof(value));
    }

    public DateTime Birth
    {
        get => birth;
        set => birth = value;
    }

    public string NameClass
    {
        get => nameClass;
        set => nameClass = value ?? throw new ArgumentNullException(nameof(value));
    }
}