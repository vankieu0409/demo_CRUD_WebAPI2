using System.ComponentModel.DataAnnotations;

namespace demo_WebAPI2.DAL.Models;

public class Student
{
    public int IdStudent { get; set; }
    public int IdClass { get; set; }
    [StringLength(50)]
    public string Name { get; set; }
    public DateTime birth { get; set; }

    public Class Classes { get; set; }
}