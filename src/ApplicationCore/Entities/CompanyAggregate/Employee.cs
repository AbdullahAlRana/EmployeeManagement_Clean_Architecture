using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using EmployeeManagement.ApplicationCore.Entities.TransactionAggregate;
using EmployeeManagement.ApplicationCore.Interfaces;

namespace EmployeeManagement.ApplicationCore.Entities.CompanyAggregate
{
    public class Employee : BaseEntity, IAggregateRoot
    {
        public string EmpCode { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }
        public int? TransactionId { get; set; }
        public Company Company { get; set; }
        public Department Department { get; set; }
        public Transaction Transaction { get; set; }

        public Employee()
        {
            // Required by EF
        }
        public Employee(int companyId, int departmentId, int? transactionId, string empCode, string name, string phoneNo, string address)
        {
            CompanyId = companyId;
            DepartmentId = departmentId;
            TransactionId = transactionId;
            EmpCode = empCode;
            Name = name;
            PhoneNo = phoneNo;
            Address = address;
        }
        
        public void Update(int companyId, int departmentId, string empCode, string name, string phoneNo, string address)
        {
            CompanyId = companyId;
            DepartmentId = departmentId;
            EmpCode = empCode;
            Name = name;
            PhoneNo = phoneNo;
            Address = address;
        }
    }
}
