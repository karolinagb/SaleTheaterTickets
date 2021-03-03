using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaleTheaterTickets.Models;
using SaleTheaterTickets.Repositories.Interfaces;
using System.Collections.Generic;

namespace SaleTheaterTickets.Controllers
{
    public class GeneratedTicketsController : Controller
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public GeneratedTicketsController(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Checkout(int? id)
        {
            GeneratedTicketViewModel model = new GeneratedTicketViewModel();

            model.Ticket = _ticketRepository.GetById(id.Value);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(GeneratedTicketViewModel model, int id)
        {
            if (ModelState.IsValid)
            {
                var _model = _mapper.Map<GeneratedTicket>(model);
                return View("~/Views/GeneratedTickets/CompletCheckout.cshtml", _model); ;
            }
            return View(model);
        }
    }
}
