namespace demo_WebAPI2.DAL.Models;

public class Class
{
    public int IdClass { get; set; }
    public string NameClass { get; set; }
    public string Classroom { get; set; }

    public ICollection<Student> Students { get; set; }
}