using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaleTheaterTickets.Models;
using SaleTheaterTickets.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace SaleTheaterTickets.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IPieceRepository _pieceRepository;
        private readonly IMapper _mapper;

        public TicketsController(ITicketRepository ticketRepository, IMapper mapper, IPieceRepository pieceRepository)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
            _pieceRepository = pieceRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Ticket> model;
            IEnumerable<TicketViewModel> _model;
            model = _ticketRepository.FindAll();
            _model = _mapper.Map<IEnumerable<TicketViewModel>>(model);
            return View(_model);
        }

        public ActionResult Create()
        {
            var pieces = _pieceRepository.FindAll();

            var model = new TicketViewModel();
            model.Pieces = pieces;

            return View(model);
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

                    model.Seats = RegistrationSeats(model.QuantityOfSeats);

                    var _model = _mapper.Map<Ticket>(model);
                    _ticketRepository.Insert(_model);

                    return RedirectToAction("Index");
                }
                var pieces = _pieceRepository.FindAll();

                model.Pieces = pieces;

                return View(model);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(model);
            }
        }

        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                Console.WriteLine("Id deve ser fornecido");
                return View("Index");
            }

            var model = _ticketRepository.GetById(id.Value);

            if(model == null)
            {
                Console.WriteLine("Ingresso não encontrado");
                return View("Index");
            }

            var pieces = _pieceRepository.FindAll();
            var _model = _mapper.Map<TicketViewModel>(model);
            _model.Pieces = pieces;

            return View(_model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TicketViewModel model, int id)
        {
            if(id != model.Id)
            {
                Console.WriteLine("Id diferente!");
                RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var _model = _mapper.Map<Ticket>(model);

                    _ticketRepository.Update(_model);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return View(model);
                }
            }

            var pieces = _pieceRepository.FindAll();
            model.Pieces = pieces;

            return View(model);
        }

        public List<int> RegistrationSeats(int quantityOfSeats)
        {
            List<int> Seats = new List<int>();
            var contador = 1;
            while (contador <= quantityOfSeats)
            {
                Seats.Add(contador);
                contador++;
            }

            return Seats;
        }
    }
}
