using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaleTheaterTickets.Models;
using SaleTheaterTickets.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace SaleTheaterTickets.Controllers
{
    public class GeneratedTicketsController : Controller
    {
        private readonly IGeneratedTicketRepository _generatedTicketRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public GeneratedTicketsController(IGeneratedTicketRepository generatedTicketRepository, ITicketRepository ticketRepository, IMapper mapper)
        {
            _generatedTicketRepository = generatedTicketRepository;
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            IEnumerable<GeneratedTicket> model;
            IEnumerable<GeneratedTicketViewModel> _model;
            model = _generatedTicketRepository.FindAll();
            _model = _mapper.Map<IEnumerable<GeneratedTicketViewModel>>(model);
            return View(_model);
        }

        public IActionResult Create(int? id)
        {
            Ticket ticket = _ticketRepository.GetById(id.Value);

            var _ticket = _mapper.Map<TicketViewModel>(ticket);

            GeneratedTicketViewModel model = new GeneratedTicketViewModel();
            model.TicketId = _ticket.Id;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GeneratedTicketViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _model = _mapper.Map<GeneratedTicket>(model);

                    _generatedTicketRepository.Insert(_model);

                    model = _mapper.Map<GeneratedTicketViewModel>(_model);

                    return RedirectToAction("Checkout", model.Id);
                }
                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(model);
            }
        }

        public ActionResult Checkout(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("Id inválido");
            }

            var model = _generatedTicketRepository.GetById(id.Value);

            if (model == null)
            {
                Console.WriteLine("Comprovante não encontrado");
            }

            return View("~/Views/GeneratedTickets/Checkout.cshtml", model);
        }
    }
}
