using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaleTheaterTickets.Models;
using SaleTheaterTickets.Repositories.Interfaces;
using SaleTheaterTickets.Services;
using System.Collections.Generic;
using System.Diagnostics;

namespace SaleTheaterTickets.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly ITicketRepository _ticketRepository;
        private readonly GeneratedTicketService _generatedTicketService;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, ITicketRepository ticketRepository, GeneratedTicketService generatedTicketService)
        {
            _logger = logger;
            _mapper = mapper;
            _ticketRepository = ticketRepository;
            _generatedTicketService = generatedTicketService;
        }

        public IActionResult Index()
        {
            IEnumerable<Ticket> model;
            IEnumerable<TicketViewModel> _model;
            model = _ticketRepository.FindAll();

            _model = _mapper.Map<IEnumerable<TicketViewModel>>(model);

            foreach(var m in _model)
            {
                var dataGenerateSeats = _generatedTicketService.GenerateSeats(m.Id);
                m.QuantityAvaibleSeats = dataGenerateSeats.Item2.Count;
            }

            return View (_model);



            //List<object> list = new List<object>();

            //IEnumerable<Ticket> model;
            //IEnumerable<TicketViewModel> _model;
            //model = _ticketRepository.FindAll();

            //foreach (var ticket in model)
            //{
            //    List<object> x = new List<object>();
            //    int quantityAvaibleSeats = 0;
            //    var dataGenerateSeats = _generatedTicketService.GenerateSeats(ticket.Id);
            //    quantityAvaibleSeats = dataGenerateSeats.Item2.Count;
            //    x.Add(ticket);
            //    x.Add(quantityAvaibleSeats);
            //    list.Add(x);
            //}

            //_model = _mapper.Map<IEnumerable<TicketViewModel>(list);
            //return View(_model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
