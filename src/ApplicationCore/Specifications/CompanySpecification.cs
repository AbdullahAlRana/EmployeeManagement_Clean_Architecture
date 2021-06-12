using Ardalis.Specification;
using EmployeeManagement.ApplicationCore.Entities.CompanyAggregate;

namespace EmployeeManagement.ApplicationCore.Specifications
{
    public sealed class CompanySpecification : Specification<Company>
    {
        public CompanySpecification(int companyId) 
        {
            Query.Where(b => b.Id == companyId);
        }
    }
}
