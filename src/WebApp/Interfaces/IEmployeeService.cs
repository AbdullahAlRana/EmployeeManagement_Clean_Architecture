using EmployeeManagement.ApplicationCore.Entities.CompanyAggregate;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.WebApp.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllWithItemsAsync();
        Task<Employee> GetByIdWithItemsAsync(int id);
        Task AddAsync(Employee model);
        Task UpdateAsync(Employee model);
        Task DeleteByIdAsync(int id);
    }
}
