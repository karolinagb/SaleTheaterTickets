using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaleTheaterTickets.Models;
using SaleTheaterTickets.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IActionResult Create(int? ticketId)
        {
            Ticket ticket = _ticketRepository.GetById(ticketId.Value);


            var _ticket = _mapper.Map<TicketViewModel>(ticket);

            List<int> avaibleSeats = new List<int>();



            for (var count = 1; count <= _ticket.QuantityOfSeats; count++)
            {
                GeneratedTicket salesByTicketId = _generatedTicketRepository.FindAllByTicketId(ticket.Id, count);

                if (salesByTicketId == null)
                {
                    avaibleSeats.Add(count);
                }
            }

            ViewBag.AvaibleSeats = avaibleSeats;

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

                    if (_model.NeedyChild.ToLower() == "true")
                    {
                        if ((ValidQuestion(_model.NeedyChild, _model.BirthDate)) == true)
                        {

                            _generatedTicketRepository.Insert(_model);

                            model = _mapper.Map<GeneratedTicketViewModel>(_model);

                            return RedirectToAction("Checkout", model);
                        }
                        else
                        {
                            ModelState.AddModelError("NeedyChild", "Resposta inválida: Cliente não é criança");
                        }
                    }
                    else
                    {
                        _generatedTicketRepository.Insert(_model);

                        model = _mapper.Map<GeneratedTicketViewModel>(_model);

                        return RedirectToAction("Checkout", model);
                    }
                }

                model = GenerateSeats(model);

                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(model);
            }
        }
        
        public ActionResult Checkout(GeneratedTicketViewModel model)
        {

            if (model == null)
            {
                Console.WriteLine("Comprovante inválido");
            }

            var _model = _mapper.Map<GeneratedTicket>(model);

            _model = _generatedTicketRepository.GetById(model.Id);

            if (_model == null)
            {
                Console.WriteLine("Comprovante não encontrado");
            }

            model = _mapper.Map<GeneratedTicketViewModel>(_model);

            return View("~/Views/GeneratedTickets/Checkout.cshtml", model);
        }

        public bool ValidQuestion(string answer, DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;
            if ((answer.ToLower()) == "true")
            {
                if (age >= 2 && age <= 12)
                {
                    return true;
                }
            }
            return false;
        }

        private GeneratedTicketViewModel GenerateSeats(GeneratedTicketViewModel model)
        {
            Ticket ticket = _ticketRepository.GetById(model.TicketId.Value);
            List<int> avaibleSeats = new List<int>();

            for (var count = 1; count <= ticket.QuantityOfSeats; count++)
            {
                GeneratedTicket salesByTicketId = _generatedTicketRepository.FindAllByTicketId(ticket.Id, count);

                if (salesByTicketId == null)
                {
                    avaibleSeats.Add(count);
                }
            }

            ViewBag.AvaibleSeats = avaibleSeats;

            GeneratedTicketViewModel generatedTicketViewModel = new GeneratedTicketViewModel();
            generatedTicketViewModel.TicketId = model.TicketId;

            return generatedTicketViewModel;
        }
    }
}
