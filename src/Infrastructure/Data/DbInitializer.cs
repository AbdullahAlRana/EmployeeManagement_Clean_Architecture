using EmployeeManagement.ApplicationCore.Entities.CompanyAggregate;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Infrastructure.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                await context.Database.EnsureCreatedAsync();

                if (!context.Companies.Any())
                {
                    var companies = new Company[]
                    {
                    new Company("Birichina"),
                    new Company("SQ Group"),
                    new Company("Walton"),
                    new Company("Pran")
                    };

                    foreach (var item in companies)
                    {
                        context.Companies.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                
                if (!context.Departments.Any())
                {
                    var departments = new Department[]
                    {
                    new Department("Admin"),
                    new Department("Software Development"),
                    new Department("Human Resource"),
                    new Department("Business")
                    };

                    foreach (var item in departments)
                    {
                        context.Departments.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<DbInitializer>();
                    log.LogError(ex.Message);
                    await Initialize(context, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }
    }
}
