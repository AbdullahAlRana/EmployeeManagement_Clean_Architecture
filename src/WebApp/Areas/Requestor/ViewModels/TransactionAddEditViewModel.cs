using EmployeeManagement.ApplicationCore.Entities.CompanyAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.WebApp.Areas.Requestor.ViewModels
{
    public class TransactionAddEditViewModel
    {
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
