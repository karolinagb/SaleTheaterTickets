using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaleTheaterTickets.Models;
using SaleTheaterTickets.Repositories.Interfaces;
using SaleTheaterTickets.Services;
using System;
using System.Collections.Generic;

namespace SaleTheaterTickets.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminTicketsController : Controller
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IPieceRepository _pieceRepository;
        private readonly IMapper _mapper;
        private readonly TicketService _ticketService;

        public AdminTicketsController(ITicketRepository ticketRepository, IPieceRepository pieceRepository, IMapper mapper, TicketService ticketService)
        {
            _ticketRepository = ticketRepository;
            _pieceRepository = pieceRepository;
            _mapper = mapper;
            _ticketService = ticketService;
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
            ICollection<Piece> pieces;

            try
            {
                if (ModelState.IsValid)
                {
                    if (_ticketRepository.GetById(model.Id) != null)
                    {
                        Console.WriteLine("Ingresso já existe!");
                    }

                    var _model = _mapper.Map<Ticket>(model);


                    var count = _ticketRepository.BeUnique(_model);

                    if (count > 0)
                    {
                        ModelState.AddModelError("", "Esse ingresso já existe para essa sala. Verique peça, data e hora");
                        pieces = _pieceRepository.FindAll();
                        model.Pieces = pieces;
                        return View(model);
                    }

                    _ticketRepository.Insert(_model);
                    model.Seats = _ticketService.RegistrationSeats(model.QuantityOfSeats);

                    return RedirectToAction("Index");
                }
                pieces = _pieceRepository.FindAll();

                model.Pieces = pieces;

                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(model);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("Id deve ser fornecido");
                return View("Index");
            }

            var model = _ticketRepository.GetById(id.Value);

            if (model == null)
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
            ICollection<Piece> pieces;

            if (id != model.Id)
            {
                Console.WriteLine("Id diferente!");
                RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var _model = _mapper.Map<Ticket>(model);

                    var count = _ticketRepository.BeUnique(_model);

                    if (count > 0)
                    {
                        ModelState.AddModelError("", "Esse ingresso já existe para essa sala. Verique peça, data e hora");
                        pieces = _pieceRepository.FindAll();
                        model.Pieces = pieces;
                        return View(model);
                    }



                    _ticketRepository.Update(_model);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return View(model);
                }
            }

            pieces = _pieceRepository.FindAll();
            model.Pieces = pieces;

            return View(model);
        }

        public ActionResult Details(TicketViewModel model, int? id)
        {
            if (id == null)
            {
                Console.WriteLine("Id não informado");
                return RedirectToAction("Index");
            }

            if (id != model.Id)
            {
                Console.WriteLine("Id diferente");
                return RedirectToAction("Index");
            }

            var _model = _mapper.Map<Ticket>(model);
            _model = _ticketRepository.GetById(id.Value);

            if (_model == null)
            {
                Console.WriteLine("Ingresso não encontrado");
                return RedirectToAction("Index");
            }

            model = _mapper.Map<TicketViewModel>(_model);

            return View(model);
        }

        public ActionResult Inactivate(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("Id não informado");
                return RedirectToAction("Index");
            }

            var model = _ticketRepository.GetById(id.Value);

            if (model == null)
            {
                Console.WriteLine("Ingresso não encontrado");
                return RedirectToAction("Index");
            }

            var _model = _mapper.Map<TicketViewModel>(model);

            return View(_model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inactivate(TicketViewModel model, int id)
        {
            if (id != model.Id)
            {
                Console.WriteLine("Id diferente!");
                RedirectToAction("Index");
            }

            try
            {
                _ticketRepository.Remove(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
        }
    }
}
