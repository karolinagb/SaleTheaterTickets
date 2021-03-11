using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaleTheaterTickets.Models;
using SaleTheaterTickets.Repositories.Interfaces;
using System;
using System.Collections.Generic;

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
                    if((_pieceRepository.GetById(_model.Id) != null))
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

        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                Console.WriteLine("Id deve ser forneciado");
                return View("Index");
            }

            //var _model = _mapper.Map<Piece>(model);
            var model = _pieceRepository.GetById(id.Value);

            if(model == null)
            {
                Console.WriteLine("Peça não encontrada!");
                return View("Index");
            }

            var _model = _mapper.Map<PieceViewModel>(model);

            return View(_model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PieceViewModel model, int id)
        {
            if (!(ModelState.IsValid))
            {
                return View(model);
            }

            if (id != model.Id)
            {
                Console.WriteLine("Id diferente!");
                RedirectToAction("Index");
            }

            try
            {
                var _model = _mapper.Map<Piece>(model);

                _pieceRepository.Update(_model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(model);
            }
        }

        public ActionResult Details(PieceViewModel model, int? id)
        {
            if(id == null)
            {
                Console.WriteLine("Id não informado");
                return RedirectToAction("Index");
            }

            if(id != model.Id)
            {
                Console.WriteLine("Id diferente!");
                return RedirectToAction("Index");
            }

            var _model = _mapper.Map<Piece>(model);
            _model = _pieceRepository.GetById(id.Value);

            if(_model == null)
            {
                Console.WriteLine("Peça não encontrada!");
                return RedirectToAction("Index");
            }

            model = _mapper.Map<PieceViewModel>(_model);

            return View(model);
        }

        public ActionResult Inactivate(int? id)
        {
            if(id == null)
            {
                Console.WriteLine("Id não informado");
                return RedirectToAction("Index");
            }

            var model = _pieceRepository.GetById(id.Value);

            if(model == null)
            {
                Console.WriteLine("Peça não encontrada!");
                return RedirectToAction("Index");
            }

            var _model = _mapper.Map<PieceViewModel>(model);

            return View(_model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Inactivate(PieceViewModel model, int id)
        {
            if (id != model.Id)
            {
                Console.WriteLine("Id diferente!");
                RedirectToAction("Index");
            }

            try
            {
                _pieceRepository.Remove(id);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
        }
    }
}
