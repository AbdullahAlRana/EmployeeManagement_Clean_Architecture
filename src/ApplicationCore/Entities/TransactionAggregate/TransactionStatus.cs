using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.ApplicationCore.Entities.TransactionAggregate
{
    public enum TransactionStatus
    {
        Saved,
        Submitted,
        Approved
    }
}
