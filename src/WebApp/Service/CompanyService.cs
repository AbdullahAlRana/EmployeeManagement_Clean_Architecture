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
    public class CompanyService : ICompanyService
    {
        private readonly IAsyncRepository<Company> _companyRepository;

        public CompanyService(IAsyncRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<Company>> GetAllWithItemsAsync()
        {
            var companies = await _companyRepository.ListAllAsync();

            return companies;
        }
    }
}