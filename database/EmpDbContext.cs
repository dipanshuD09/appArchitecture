using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using efcore.Models;
using Microsoft.EntityFrameworkCore;

namespace efcore.database
{
    public class EmpDbContext : DbContext
    {
        // protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        // {
        //     dbContextOptionsBuilder.UseSqlServer("data source=DIPANSHU\\SQLEXPRESS;initial catalog=consoledb;integrated security=true;Trusted_Connection=SSPI;Encrypt=false;trustservercertificate=true;");
        // }

        public EmpDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(x => x.Id);
            modelBuilder.Entity<Department>().HasKey(x => x.Id);
            modelBuilder.Entity<Department>().HasMany(d => d.employees).WithOne(e => e.department).HasForeignKey(e => e.DepartmentId);
        }

        public DbSet<Employee> employee { get; set; }
        public DbSet<Department> department { get; set; }
    }
}