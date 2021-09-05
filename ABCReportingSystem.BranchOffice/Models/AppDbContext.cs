using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ABCReportingSystem.BranchOffice.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<BranchOffice> BranchOffices { get; set; }

        public DbSet<Automobile> Automobiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed BranchOffices Table

            modelBuilder.Entity<BranchOffice>().HasData(new BranchOffice
            {
                BranchOfficeId = -1,
                BranchOfficeCountry = "US",
                BranchOfficeState = "California"
            });
            
            modelBuilder.Entity<BranchOffice>().HasData(new BranchOffice
            {
                BranchOfficeId = -2,
                BranchOfficeCountry = "US",
                BranchOfficeState = "New York"
            });
            
            modelBuilder.Entity<BranchOffice>().HasData(new BranchOffice
            {
                BranchOfficeId = -3,
                BranchOfficeCountry = "US",
                BranchOfficeState = "Massachusetts"
            });

            //Seed Employee Table

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = new Guid("fb0f1585-cb42-4f01-a25d-6e441b414f72"),
                FirstName = "Dio",
                LastName = "Brando",
                Username = "diobrando1",
                BranchOfficeId = -1
            }); 
            
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = new Guid("189a302d-1aa7-4110-a43d-833183446a4b"),
                FirstName = "Jolyne",
                LastName = "Cujoh",
                Username = "jolynecujoh",
                BranchOfficeId = -2
            }); 
            
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = new Guid("f3022c0b-d875-45a1-9c36-bec333877595"),
                FirstName = "Gyro",
                LastName = "Zepelli",
                Username = "gzepelli",
                BranchOfficeId = -3
            });

            //Seed Automobile Table 

            modelBuilder.Entity<Automobile>().HasData(new Automobile
            {
                AutomobileId = new Guid("65a1e10e-68ad-4ddc-b92c-32d36cf45cee"),
                Make = "Tesla",
                Model = "Model S",
                Year = 2021,
                BranchOfficeId = -1
            });
            
            modelBuilder.Entity<Automobile>().HasData(new Automobile
            {
                AutomobileId = new Guid("1f8267e5-78f1-49ed-8476-823d4d439352"),
                Make = "Toyota",
                Model = "RAV4",
                Year = 2021,
                BranchOfficeId = -2
            });
            
            modelBuilder.Entity<Automobile>().HasData(new Automobile
            {
                AutomobileId = new Guid("ccd557c5-877f-482f-bca1-722d5198b0a9"),
                Make = "Hyundai",
                Model = "KONA",
                Year = 2021,
                BranchOfficeId = -3
            });
        }
    }
}
