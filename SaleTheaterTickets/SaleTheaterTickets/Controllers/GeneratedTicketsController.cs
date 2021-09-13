using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using SaleTheaterTickets.Data;
using SaleTheaterTickets.Models;
using SaleTheaterTickets.Repositories.Interfaces;
using SaleTheaterTickets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleTheaterTickets.Controllers
{
    public class GeneratedTicketsController : Controller
    {
        private readonly IGeneratedTicketRepository _generatedTicketRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        private readonly SaleTheaterTicketsContext _saleTheaterTicketsContext;
        private readonly GeneratedTicketService _generatedTicketService;

        public GeneratedTicketsController(IGeneratedTicketRepository generatedTicketRepository, ITicketRepository ticketRepository, IMapper mapper, SaleTheaterTicketsContext saleTheaterTicketsContext, GeneratedTicketService generatedTicketService)
        {
            _generatedTicketRepository = generatedTicketRepository;
            _ticketRepository = ticketRepository;
            _mapper = mapper;
            _saleTheaterTicketsContext = saleTheaterTicketsContext;
            _generatedTicketService = generatedTicketService;
        }

        //public ActionResult Index()
        //{
        //    IEnumerable<GeneratedTicket> model;
        //    IEnumerable<GeneratedTicketViewModel> _model;
        //    model = _generatedTicketRepository.FindAll();
        //    _model = _mapper.Map<IEnumerable<GeneratedTicketViewModel>>(model);
        //    return View(_model);
        //}

        //Implementando a paginação
        public async Task<ActionResult> Index(string filter, int pageindex = 1, string sort = "CustomerName")
        {
            var result = _generatedTicketRepository.FindAllToPagination().AsNoTracking().AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(x => x.CustomerName.Contains(filter));
            }

            var model = await PagingList.CreateAsync(result, 5, pageindex, sort, "CustomeName");

            model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            return View(model);
        }

        public IActionResult Create(int ticketId)
        {
            var avaibleSeats = _generatedTicketService.GenerateSeats(ticketId);
            GeneratedTicketViewModel model = new GeneratedTicketViewModel();
            model.TicketId = ticketId;


            if (avaibleSeats.Count == 0)
            {
                TempData["Message"] = "Peça não há mais assentos disponíveis";
                TempData["ColorMessage"] = "danger";

                return RedirectToAction("Index", "Home");
            }

            ViewBag.AvaiableSeats = avaibleSeats;

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

                    if (_model.NeedyChild.ToLower() == "true")
                    {
                        if ((ValidQuestion(_model.NeedyChild, _model.BirthDate)) == true)
                        {
                            _model.Total = _model.Ticket.Price - dataCalculateDiscount.Item1;
                            _model.Description = dataCalculateDiscount.Item2;

                            _model.CreationDate = DateTime.Now;

                            _generatedTicketRepository.Insert(_model);

                            model = _mapper.Map<GeneratedTicketViewModel>(_model);

                            return RedirectToAction("Checkout", model);
                        }
                        ModelState.AddModelError("NeedyChild", "Resposta inválida: Cliente não é criança");
                        model = _mapper.Map<GeneratedTicketViewModel>(_model);

                        var avaibleSeats = _generatedTicketService.GenerateSeats(model.TicketId);

                        ViewBag.AvaiableSeats = avaibleSeats;
                        return View(model);
                    }
                    _model.Total = _model.Ticket.Price - dataCalculateDiscount.Item1;
                    _model.Description = dataCalculateDiscount.Item2;

                    _model.CreationDate = DateTime.Now;

                    _generatedTicketRepository.Insert(_model);

                    model = _mapper.Map<GeneratedTicketViewModel>(_model);

                    return RedirectToAction("Checkout", model);
                }
                else
                {
                    var avaibleSeats = _generatedTicketService.GenerateSeats(model.TicketId);
                    ViewBag.AvaiableSeats = avaibleSeats;

                    return View(model);
                }         
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

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("Id não informado");
                return RedirectToAction("Index");
            }

            //if (id != model.Id)
            //{
            //    Console.WriteLine("Id diferente");
            //    return RedirectToAction("Index");
            //}

            var model = _generatedTicketRepository.GetById(id.Value);

            if (model == null)
            {
                Console.WriteLine("Ingresso não encontrado");
                return RedirectToAction("Index");
            }

            var _model = _mapper.Map<GeneratedTicketViewModel>(model);

            return View(_model);
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
