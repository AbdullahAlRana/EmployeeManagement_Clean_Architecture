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
    public class EmployeeService : IEmployeeService
    {
        private readonly IAsyncRepository<Employee> _employeeRepository;

        public EmployeeService(IAsyncRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetAllWithItemsAsync()
        {
            var employees = await _employeeRepository.ListAllAsync();

            return employees;
        }

        public async Task<Employee> GetByIdWithItemsAsync(int id)
        {
            var filterSpecification = new EmployeeSpecification(id);
            var employee = await _employeeRepository.FirstOrDefaultAsync(filterSpecification);

            return employee;
        }

        public async Task AddAsync(Employee model)
        {
            var employee = new Employee(model.CompanyId, model.DepartmentId, model.TransactionId, model.EmpCode, model.Name, model.PhoneNo, model.Address);

            await _employeeRepository.AddAsync(employee);
        }

        public async Task UpdateAsync(Employee model)
        {
            var filterSpecification = new EmployeeSpecification(model.Id);
            var existingEmployee = await _employeeRepository.FirstOrDefaultAsync(filterSpecification);

            existingEmployee.Update(model.CompanyId, model.DepartmentId, model.EmpCode, model.Name, model.PhoneNo, model.Address);

            await _employeeRepository.UpdateAsync(existingEmployee);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var filterSpecification = new EmployeeSpecification(id);
            var existingEmployee = await _employeeRepository.FirstOrDefaultAsync(filterSpecification);

            await _employeeRepository.DeleteAsync(existingEmployee);
        }
    }
}