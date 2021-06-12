using EmployeeManagement.ApplicationCore.Entities.TransactionAggregate;
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
    public class HomeController : Controller
    {
        private readonly ITransactionService _transactionService;
        public HomeController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<IActionResult> Index()
        {
            var transactions = (await _transactionService.GetAllWithItemsAsync()).Where( b => b.TransactionStatus == TransactionStatus.Submitted).OrderByDescending(t => t.Id);
            return View(transactions);
        }
    }
}
