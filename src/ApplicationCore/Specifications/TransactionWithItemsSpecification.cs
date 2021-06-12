using Ardalis.Specification;
using EmployeeManagement.ApplicationCore.Entities.TransactionAggregate;

namespace EmployeeManagement.ApplicationCore.Specifications
{
    public sealed class TransactionWithItemsSpecification : Specification<Transaction>
    {
        public TransactionWithItemsSpecification()
        {
            Query.Include(c => c.Company);
            Query.Include(d => d.Department);
            Query.Include(e => e.Employees);
        }

        public TransactionWithItemsSpecification(int transactionId)
        {
            Query.Where(b => b.Id == transactionId);
            Query.Include(c => c.Company);
            Query.Include(d => d.Department);
            Query.Include(e => e.Employees);
        }
    }
}
