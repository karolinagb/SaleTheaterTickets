using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaleTheaterTickets.Models;
using SaleTheaterTickets.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace SaleTheaterTickets.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminPiecesController : Controller
    {
        private readonly IPieceRepository _pieceRepository;

        public AdminPiecesController(IPieceRepository pieceRepository)
        {
            _pieceRepository = pieceRepository;
        }

        public ActionResult Index()
        {
            IEnumerable<Piece> model;
            model = _pieceRepository.FindAll();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Piece model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pieceRepository.Insert(model);

                    return RedirectToAction("Index");
                }
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
                Console.WriteLine("Id deve ser forneciado");
                return View("Index");
            }

            var model = _pieceRepository.GetById(id.Value);

            if (model == null)
            {
                Console.WriteLine("Peça não encontrada!");
                return View("Index");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Piece model, int id)
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

                _pieceRepository.Update(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(model);
            }
        }

        public ActionResult Details(Piece model, int? id)
        {
            if (id == null)
            {
                Console.WriteLine("Id não informado");
                return RedirectToAction("Index");
            }

            if (id != model.Id)
            {
                Console.WriteLine("Id diferente!");
                return RedirectToAction("Index");
            }

            model = _pieceRepository.GetById(id.Value);

            if (model == null)
            {
                Console.WriteLine("Peça não encontrada!");
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Inactivate(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("Id não informado");
                return RedirectToAction("Index");
            }

            var model = _pieceRepository.GetById(id.Value);

            if (model == null)
            {
                Console.WriteLine("Peça não encontrada!");
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Inactivate(Piece model, int id)
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
        }
    }
}
