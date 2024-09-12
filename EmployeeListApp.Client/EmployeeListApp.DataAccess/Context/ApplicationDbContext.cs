using EmployeeListApp.Domain.Entities;
using EmployeeListApp.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace EmployeeListApp.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
        }
        public DbSet<Employee> Employees {  get; set; }

        // Seed data or initial value for testing

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Joshua",
                    LastName = "Canapi",
                    MiddleName = "Fernandez",
                    Email = "josh09@gmail.com",
                    Address = "Santa Maria, Bulacan",
                    PhoneNumber = 09503334244,
                    Gender = EmployeeGender.Male,
                    Status = EmployeeStatus.Active
                },
                 new Employee
                 {
                     EmployeeId = 2,
                     FirstName = "James",
                     LastName = "Canapi",
                     MiddleName = "Fernandez",
                     Email = "james09@gmail.com",
                     Address = "Santa Maria, Bulacan",
                     PhoneNumber = 095055635412,
                     Gender = EmployeeGender.Male,
                     Status = EmployeeStatus.Active
                 },
                 new Employee
                    {
                        EmployeeId = 3,
                        FirstName = "Mich",
                        LastName = "Canapi",
                        MiddleName = "Fernandez",
                        Email = "mich09@gmail.com",
                        Address = "Santa Maria, Bulacan",
                        PhoneNumber = 09505433362,
                        Gender = EmployeeGender.Female,
                        Status = EmployeeStatus.InActive
                    }

                );
        }
    }
}
