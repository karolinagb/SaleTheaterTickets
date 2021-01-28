using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaleTheaterTickets.Models;
using SaleTheaterTickets.Models.ViewModels;
using SaleTheaterTickets.Repositories.Interfaces;

namespace SaleTheaterTickets.Controllers
{
    public class PiecesController : Controller
    {
        private readonly IPieceRepository _pieceRepository;
        private readonly IMapper _mapper;

        public PiecesController(IPieceRepository pieceRepository, IMapper mapper)
        {
            _pieceRepository = pieceRepository;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            IEnumerable<Piece> model;
            IEnumerable<PieceViewModel> _model;
            model = _pieceRepository.FindAll();
            _model = _mapper.Map<IEnumerable<PieceViewModel>>(model);
            return View(_model);
        }

        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PieceViewModel _model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if((_pieceRepository.GetById(_model.Id)) != null)
                    {
                        ViewBag.Error = "Peça já existe!";
                    }

                    var model = _mapper.Map<Piece>(_model);
                    _pieceRepository.Insert(model);

                    return RedirectToAction("Index");
                }
                return View(_model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(_model);
            }
        }
    }
}
