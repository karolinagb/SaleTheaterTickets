using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaleTheaterTickets.Models;
using SaleTheaterTickets.Repositories.Interfaces;
using SaleTheaterTickets.Services;
using System;
using System.Collections.Generic;

namespace SaleTheaterTickets.Controllers
{
    public class GeneratedTicketsController : Controller
    {
        private readonly IGeneratedTicketRepository _generatedTicketRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        private readonly GeneratedTicketService _generatedTicketService;

        public GeneratedTicketsController(IGeneratedTicketRepository generatedTicketRepository, ITicketRepository ticketRepository, IMapper mapper, GeneratedTicketService generatedTicketService)
        {
            _generatedTicketRepository = generatedTicketRepository;
            _ticketRepository = ticketRepository;
            _mapper = mapper;
            _generatedTicketService = generatedTicketService;
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
            var dataGenerateSeats = _generatedTicketService.GenerateSeats(ticketId.Value);
            GeneratedTicketViewModel model = dataGenerateSeats.Item1;
            

            if(dataGenerateSeats.Item2.Count == 0)
            {
                TempData["Message"] = "Peça não há mais assentos disponíveis";
                TempData["ColorMessage"] = "danger";

                return RedirectToAction("Index", "Home");
            }

            ViewBag.AvaibleSeats = dataGenerateSeats.Item2;

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

                    _model.Ticket = _ticketRepository.GetById(_model.TicketId);

                    int age = _generatedTicketService.CalculateAge(_model.BirthDate);

                    var dataCalculateDiscount = _generatedTicketService.CalculateDiscount(age, _model.Ticket.Price, _model.NeedyChild);

                    _model.Total = _model.Ticket.Price - dataCalculateDiscount.Item1;
                    _model.Description = dataCalculateDiscount.Item2;

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

                var dataGenerateSeats = _generatedTicketService.GenerateSeats(model.TicketId.Value);
                model = dataGenerateSeats.Item1;
                ViewBag.AvaiableSeats = dataGenerateSeats.Item2;
                
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

            TempData["Message"] = "Compra realizada com sucesso! :)";
            TempData["ColorMessage"] = "success";

            return View(model);
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

        
    }
}
