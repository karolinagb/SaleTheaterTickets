using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleTheaterTickets.Areas.Admin.Services;
using SaleTheaterTickets.Models;
using SaleTheaterTickets.Models.ViewModelValidators;
using SaleTheaterTickets.Repositories.Interfaces;
using SaleTheaterTickets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        private readonly UploadService _uploadService;

        public AdminTicketsController(ITicketRepository ticketRepository, IPieceRepository pieceRepository, IMapper mapper, TicketService ticketService, UploadService uploadService)
        {
            _ticketRepository = ticketRepository;
            _pieceRepository = pieceRepository;
            _mapper = mapper;
            _ticketService = ticketService;
            _uploadService = uploadService;
        }

        public IActionResult Index(List<string> importLogs)
        {
            if(importLogs.Count != 0)
            {
                ViewBag.ImportLogs = importLogs;
            }

            IEnumerable<Ticket> model;
            IEnumerable<TicketViewModel> _model;
            model = _ticketRepository.FindAll();
            _model = _mapper.Map<IEnumerable<TicketViewModel>>(model);
            return View("Areas/Admin/Views/AdminTickets/Index.cshtml", _model);
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

            List<TicketViewModel> tickets = new List<TicketViewModel>();

            try
            {
                List<string> importLogs = new List<string>();
                var inserted = 0;
                var errors = 0;

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

                    var resultReadCsvData = _ticketService.ReadCSVData(path);

                    tickets = resultReadCsvData.Item1;
                    var logs = resultReadCsvData.Item2;

                    foreach(var log in logs)
                    {
                        importLogs.Add(log);
                    }
                }

                foreach (var ticket in tickets)
                {
                    Ticket t = _mapper.Map<Ticket>(ticket);

                    TicketViewModelValidator validations = new TicketViewModelValidator();
                    ValidationResult result = validations.Validate(ticket);

                    if (!result.IsValid || importLogs != null)
                    {
                        foreach (var e in result.Errors.ToList())
                        {
                            var message = $"Registro da linha {ticket.Line} - {e.PropertyName} : {e.ErrorMessage}";
                            importLogs.Add(message);
                        }
                        errors++;
                    }
                    else
                    {
                        _ticketRepository.Insert(t);
                        inserted++;
                    }
                }

                if (importLogs == null)
                {
                    TempData["Message"] = "Registro(s) criado(s) com sucesso!";
                    TempData["ColorMessage"] = "success";

                    return RedirectToAction("Index");
                }

                if (errors == 0)
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
            catch (Exception)
            {
                TempData["Message"] = $"Ocorreu um erro ao fazer upload do(s) arquivo(s)";
                TempData["ColorMessage"] = "danger";

                return View();
            }

            
        }
    }
}
