using demo_WebAPI2.DAL.Models;

using Microsoft.EntityFrameworkCore;

namespace demo_WebAPI2.DAL;

public class DbWebContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-NVB7S6L;Initial Catalog=DemoDPOTECH;Persist Security Info=True;User ID=kieu96;Password=123");
        }
    }

    public DbSet<Class> Classes { get; set; }
    public DbSet<Student> Students { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Class>(entity =>
        {
            entity.ToTable("Class");
            entity.HasKey(p => p.IdClass);
        });
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");
            entity.HasKey(p => p.IdStudent);
            entity.HasOne(p => p.Classes)
                .WithMany(p => p.Students)
                .HasForeignKey(p => p.IdClass)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull);
        });
    }
}