using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaleTheaterTickets.Areas.Admin.Services;
using System;

namespace SaleTheaterTickets.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminSalesTicketsReportController : Controller
    {
        private readonly TicketSalesReportService _ticketSalesReportService;

        public AdminSalesTicketsReportController(TicketSalesReportService ticketSalesReportService)
        {
            _ticketSalesReportService = ticketSalesReportService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult TicketSalesReport(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = _ticketSalesReportService.FindByDateAsync(minDate.Value, maxDate.Value);

            return View(result);
        }
    }
}
