using EmployeeManagement.ApplicationCore.Entities.CompanyAggregate;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.WebApp.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllWithItemsAsync();
    }
}
