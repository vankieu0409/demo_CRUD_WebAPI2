using System.ComponentModel.DataAnnotations;

namespace demo_WebAPI2.DAL.Models;

public class Class
{
    public int IdClass { get; set; }
    [StringLength(25)]
    public string NameClass { get; set; }
    [StringLength(5)]
    public string? Classroom { get; set; }

    public ICollection<Student> Students { get; set; }
}