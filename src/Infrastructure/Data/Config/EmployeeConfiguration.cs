using EmployeeManagement.ApplicationCore.Entities.CompanyAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Infrastructure.Data.Config
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.Property(b => b.PhoneNo)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
