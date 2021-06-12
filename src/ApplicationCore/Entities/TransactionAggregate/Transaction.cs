using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.ApplicationCore.Entities.CompanyAggregate;
using EmployeeManagement.ApplicationCore.Interfaces;

namespace EmployeeManagement.ApplicationCore.Entities.TransactionAggregate
{
    public class Transaction : BaseEntity, IAggregateRoot
    {
        public string TransactionId { get; set; }
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }
        public TransactionStatus TransactionStatus { get; set; } = TransactionStatus.Saved;
        public Company Company { get; set; }
        public Department Department { get; set; }

        private readonly List<Employee> _employees = new List<Employee>();
        public IReadOnlyCollection<Employee> Employees => _employees.AsReadOnly();

        public Transaction()
        {
            // Required by EF
        }
        public Transaction(string transactionId, int companyId, int departmentId)
        {
            TransactionId = transactionId;
            CompanyId = companyId;
            DepartmentId = departmentId;
        }

        public void Update(int companyId, int departmentId)
        {
            CompanyId = companyId;
            DepartmentId = departmentId;
        }
        public void UpdateStatus(TransactionStatus transactionStatus)
        {
            TransactionStatus = transactionStatus;
        }
    }
}
