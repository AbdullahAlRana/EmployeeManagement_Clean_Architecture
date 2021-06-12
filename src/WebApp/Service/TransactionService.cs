using EmployeeManagement.ApplicationCore.Interfaces;
using EmployeeManagement.ApplicationCore.Specifications;
using EmployeeManagement.WebApp.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.ApplicationCore.Entities.TransactionAggregate;
using EmployeeManagement.WebApp.Areas.Requestor.ViewModels;

namespace EmployeeManagement.WebApp.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IAsyncRepository<Transaction> _transactionRepository;
        private readonly IEmployeeService _employeeService;

        public TransactionService(IAsyncRepository<Transaction> transactionRepository,
            IEmployeeService employeeService)
        {
            _transactionRepository = transactionRepository;
            _employeeService = employeeService;
        }

        public async Task<IEnumerable<Transaction>> GetAllWithItemsAsync()
        {
            var filterSpecification = new TransactionWithItemsSpecification();
            var transactions = await _transactionRepository.ListAsync(filterSpecification);

            return transactions;
        }

        public async Task<Transaction> GetByIdWithItemsAsync(int id)
        {
            var filterSpecification = new TransactionWithItemsSpecification(id);
            var transaction = await _transactionRepository.FirstOrDefaultAsync(filterSpecification);

            return transaction;
        }

        public async Task<int> AddAsync(TransactionAddEditViewModel viewModel)
        {
            int lastId = _transactionRepository.LastElementId() != null ? _transactionRepository.LastElementId().Value : 0;
            lastId++;
            string newId = lastId.ToString();

            // Generating TransactionId
            string transactionId = "TR";
            for (int i = 0; i < 5 - newId.Length; i++)
                transactionId += "0";
            transactionId += newId;

            var transaction = new Transaction(transactionId, viewModel.CompanyId, viewModel.DepartmentId);

            transaction = await _transactionRepository.AddAsync(transaction);

            foreach(var item in viewModel.Employees.Where( e => e.EmpCode != "Deleted"))
            {
                item.CompanyId = viewModel.CompanyId;
                item.DepartmentId = viewModel.DepartmentId;
                item.TransactionId = transaction.Id;
                await _employeeService.AddAsync(item);
            }

            return transaction.Id;
        }

        public async Task UpdateAsync(Transaction model)
        {
            var filterSpecification = new TransactionWithItemsSpecification(model.Id);
            var existingTransaction = await _transactionRepository.FirstOrDefaultAsync(filterSpecification);

            existingTransaction.Update(model.CompanyId, model.DepartmentId);

            await _transactionRepository.UpdateAsync(existingTransaction);
        }
        
        public async Task UpdateStatusAsync(int id, TransactionStatus transactionStatus)
        {
            var filterSpecification = new TransactionWithItemsSpecification(id);
            var existingTransaction = await _transactionRepository.FirstOrDefaultAsync(filterSpecification);

            existingTransaction.UpdateStatus(transactionStatus);

            await _transactionRepository.UpdateAsync(existingTransaction);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var filterSpecification = new TransactionWithItemsSpecification(id);
            var existingTransaction = await _transactionRepository.FirstOrDefaultAsync(filterSpecification);

            await _transactionRepository.DeleteAsync(existingTransaction);
        }
    }
}