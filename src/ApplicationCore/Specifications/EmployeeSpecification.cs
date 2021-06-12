using Ardalis.Specification;
using EmployeeManagement.ApplicationCore.Entities.CompanyAggregate;

namespace EmployeeManagement.ApplicationCore.Specifications
{
    public sealed class EmployeeSpecification : Specification<Employee>
    {
        public EmployeeSpecification(int companyId) 
        {
            Query.Where(b => b.Id == companyId);
        }
    }
}
