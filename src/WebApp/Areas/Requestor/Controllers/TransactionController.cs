using EmployeeManagement.ApplicationCore.Entities.TransactionAggregate;
using EmployeeManagement.WebApp.Areas.Requestor.ViewModels;
using EmployeeManagement.WebApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace EmployeeManagement.WebApp.Areas.Requestor.Controllers
{
    [Area("Requestor")]
    public class TransactionController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IDepartmentService _departmentService;
        private readonly ITransactionService _transactionService;
        public TransactionController(ICompanyService companyService, IDepartmentService departmentService,
            ITransactionService transactionService)
        {
            _companyService = companyService;
            _departmentService = departmentService;
            _transactionService = transactionService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _transactionService.GetAllWithItemsAsync());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Companies = (await _companyService.GetAllWithItemsAsync()).ToList();
            ViewBag.Departments = (await _departmentService.GetAllWithItemsAsync()).ToList();

            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(TransactionAddEditViewModel viewModel)
        {
            int transactionId = await _transactionService.AddAsync(viewModel);

            return RedirectToAction(nameof(Submit), new { id = transactionId });
        }

        public async Task<IActionResult> Submit(int id)
        {
            return View(await _transactionService.GetByIdWithItemsAsync(id));
        }
        
        public async Task<IActionResult> SubmitConfirm(int id)
        {
            await _transactionService.UpdateStatusAsync(id, TransactionStatus.Submitted);

            return RedirectToAction(nameof(Index));
        }
    }
}
