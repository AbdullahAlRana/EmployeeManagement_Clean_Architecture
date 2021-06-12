using EmployeeManagement.ApplicationCore.Entities.CompanyAggregate;
using EmployeeManagement.ApplicationCore.Entities.TransactionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Infrastructure.Data.Config
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Transaction.Employees));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
