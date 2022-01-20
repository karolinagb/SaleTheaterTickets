using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SaleTheaterTickets.Areas.Admin.Services;
using SaleTheaterTickets.Models;
using SaleTheaterTickets.Models.Services;
using SaleTheaterTickets.Models.ViewModels;
using SaleTheaterTickets.Models.ViewModelValidators;
using SaleTheaterTickets.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleTheaterTickets.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminPiecesController : Controller
    {
        private readonly IPieceRepository _pieceRepository;
        private readonly UploadService _uploadService;
        private readonly PieceService _pieceService;

        public AdminPiecesController(IPieceRepository pieceRepository, UploadService uploadService, PieceService pieceService)
        {
            _pieceRepository = pieceRepository;
            _uploadService = uploadService;
            _pieceService = pieceService;
        }

        public ActionResult Index(List<string> importLogs)
        {
            if (importLogs.Count != 0)
            {
                ViewBag.ImportLogs = importLogs;
            }

            IEnumerable<Piece> model;
            model = _pieceRepository.FindAll();
            return View("Areas/Admin/Views/AdminPieces/Index.cshtml", model);
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

                    TempData["Message"] = "Registro(s) adicionado(s) com sucesso";
                    TempData["ColorMessage"] = "success";

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

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        //método para enviar os arquivos usando a interface IFormFile
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            long fileSize = files.Sum(x => x.Length);

            //verifica se existem arquivos
            if (fileSize == 0)
            {
                //retorna a viewbag com erro
                TempData["Message"] = "Erro : Arquivo(s) não selecionado(s)";
                TempData["ColorMessage"] = "danger";
                return View();
            }

            List<PieceViewModel> pieces = new List<PieceViewModel>();

            foreach (var file in files)
            {
                if (!file.FileName.Contains(".csv"))
                {
                    //monta a ViewBag que será exibida na view como resultado do envio 
                    TempData["Message"] = "Formato inválido. Faça upload do(s) arquivo(s) no formato .xlsx ou .xls";
                    TempData["ColorMessage"] = "danger";
                    return View();

                }
                string path = await _uploadService.UploadFile(file);

                pieces = _pieceService.ReadCSVData(path);
            }

            List<string> importLogs = new List<string>();
            var inserted = 0;
            var errors = 0;

            foreach (var piece in pieces)
            {
                Piece p = new Piece
                {
                    Name = piece.Name
                };

                PieceViewModelValidator validations = new PieceViewModelValidator(_pieceService);
                ValidationResult result = validations.Validate(p);

                if (result.IsValid || importLogs == null)
                {
                    _pieceRepository.Insert(p);
                    inserted++;
                }
                else
                {
                    foreach (var e in result.Errors.ToList())
                    {
                        var message = $"Registro da linha {piece.Line} - {e.PropertyName} : {e.ErrorMessage}";
                        importLogs.Add(message);
                    }
                    errors++;
                }
            }

            if (importLogs == null)
            {
                TempData["Message"] = "Registro(s) criado(s) com sucesso!";
                TempData["ColorMessage"] = "success";

                return RedirectToAction("Index");
            }

            if(errors == 0)
            {
                TempData["Message"] = $"{inserted} foram inseridos com sucesso - {errors} registros falharam";
                TempData["ColorMessage"] = "success";
            }
            else
            {
                TempData["Message"] = $"{inserted} foram inseridos com sucesso - {errors} registros falharam";
                TempData["ColorMessage"] = "warning";
            }

            return Index(importLogs); 
        }
    }
}
