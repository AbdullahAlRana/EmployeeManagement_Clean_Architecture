using Ardalis.Specification;
using EmployeeManagement.ApplicationCore.Entities.CompanyAggregate;

namespace EmployeeManagement.ApplicationCore.Specifications
{
    public sealed class DepartmentSpecification : Specification<Department>
    {
        public DepartmentSpecification(int departmentId) 
        {
            Query.Where(b => b.Id == departmentId);
        }
    }
}
