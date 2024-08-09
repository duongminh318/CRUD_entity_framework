using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_entity_framework
{
    // DBContext
    public class SchoolContext: DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MAYTINH;Database=StudentDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
