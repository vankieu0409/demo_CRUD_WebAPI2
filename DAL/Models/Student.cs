namespace demo_WebAPI2.DAL.Models;

public class Student
{
    public int IdStudent { get; set; }
    public int IdClass { get; set; }
    public string Name { get; set; }
    public DateTime birth { get; set; }

    public Class Classes { get; set; }
}