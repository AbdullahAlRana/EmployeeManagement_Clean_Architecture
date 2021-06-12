using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.ApplicationCore.Entities.TransactionAggregate;
using EmployeeManagement.WebApp.Areas.Requestor.ViewModels;

namespace EmployeeManagement.WebApp.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetAllWithItemsAsync();
        Task<Transaction> GetByIdWithItemsAsync(int id);
        Task<int> AddAsync(TransactionAddEditViewModel viewModel);
        Task UpdateAsync(Transaction model);
        Task UpdateStatusAsync(int id, TransactionStatus transactionStatus);
        Task DeleteByIdAsync(int id);
    }
}
