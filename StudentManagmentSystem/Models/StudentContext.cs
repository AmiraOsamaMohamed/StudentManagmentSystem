using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace StudentManagmentSystem.Models
{
    public class StudentContext: DbContext
    {
        public StudentContext():base() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder.UseSqlServer(" Data Source = DESKTOP-7C6N20L\\SQLEXPRESS;Initial Catalog = StudentManagmentSystem; Integrated Security = True; Encrypt=False;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        
        public virtual DbSet<Student> Student { get; set; }

    }

}
