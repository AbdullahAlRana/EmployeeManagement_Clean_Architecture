using EmployeeManagement.ApplicationCore.Entities.CompanyAggregate;
using EmployeeManagement.ApplicationCore.Interfaces;
using EmployeeManagement.ApplicationCore.Specifications;
using EmployeeManagement.WebApp.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.WebApp.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IAsyncRepository<Department> _departmentRepository;

        public DepartmentService(IAsyncRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<Department>> GetAllWithItemsAsync()
        {
            var departments = await _departmentRepository.ListAllAsync();

            return departments;
        }
    }
}