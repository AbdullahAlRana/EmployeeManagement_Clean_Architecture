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

namespace EmployeeManagement.WebApp.Areas.Approver.Controllers
{
    [Area("Approver")]
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
        
        public async Task<IActionResult> Approve(int id)
        {
            await _transactionService.UpdateStatusAsync(id, TransactionStatus.Approved);
            return RedirectToAction("Index", "Home", new { area = "Approver" });
        }
    }
}
