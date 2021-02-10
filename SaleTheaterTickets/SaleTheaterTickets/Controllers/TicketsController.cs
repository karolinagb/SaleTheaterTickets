using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaleTheaterTickets.Models;
using SaleTheaterTickets.Models.ViewModels;
using SaleTheaterTickets.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleTheaterTickets.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public TicketsController(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TicketViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(_ticketRepository.GetById(model.Id) != null)
                    {
                        Console.WriteLine("Ingresso já existe!");
                    }

                    var _model = _mapper.Map<Ticket>(model);
                    _ticketRepository.Insert(_model);

                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(model);
            }
        }
    }
}
