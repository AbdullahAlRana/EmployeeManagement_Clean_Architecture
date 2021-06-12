using Ardalis.GuardClauses;
using EmployeeManagement.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.ApplicationCore.Entities.CompanyAggregate
{
    public class Company : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }

        private readonly List<Employee> _employees = new List<Employee>();
        public IReadOnlyCollection<Employee> Employees => _employees.AsReadOnly();

        private Company()
        {
            // Required by EF
        }

        public Company(string name)
        {
            Name = name;
        }
    }
}
