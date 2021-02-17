﻿using AutoMapper;
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
            return View();
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
    }
}
