using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SaleTheaterTickets.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UploadController : Controller
    {
        //Define uma instância de IHostingEnvironment
        private readonly IWebHostEnvironment _hostingEnvironment;

        //Injeta a instância no construtor para poder usar os recursos
        public UploadController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        //Retorna a View Index.cshtml que será o formulário para
        //selecionar os arquivos a serem enviados 
        public ActionResult Index()
        {
            return View();
        }

        //método para enviar os arquivos usando a interface IFormFile
        public async Task<IActionResult> UploadFile(List<IFormFile> files)
        {
            long fileSize = files.Sum(x => x.Length);

            // caminho completo do arquivo na localização temporária
            var filePath = Path.GetTempFileName();

            //verifica se existem arquivos
            if (fileSize == 0)
            {
                //retorna a viewbag com erro
                TempData["Message"] = "Erro : Arquivo(s) não selecionado(s)";
                TempData["ColorMessage"] = "danger";
                return View("Areas/Admin/Views/Upload/Index.cshtml");
            }

            //processa os arquivo enviados
            //percorre a lista de arquivos selecionados
            foreach (var file in files)
            {
                // < define a pasta onde vamos salvar os arquivos >
                string folder = "UserFiles";

                // Define um nome para o arquivo enviado incluindo o sufixo obtido de milesegundos
                string fileName = "FileUser" + DateTime.Now.Millisecond.ToString();

                //verifica qual o tipo de arquivo :
                if (file.FileName.Contains(".xlsx"))
                {
                    fileName += ".xlsx";

                }
                else if (file.FileName.Contains(".xls"))
                {
                    fileName += ".xls";
                }
                else
                {
                    TempData["Message"] = "Formato inválido. Faça upload do(s) arquivo(s) no formato .xlsx ou .xls";
                    TempData["ColorMessage"] = "danger";
                    return View("Areas/Admin/Views/Upload/Index.cshtml");
                }

                //< obtém o caminho físico da pasta wwwroot >
                string path_WwwRoot = _hostingEnvironment.WebRootPath;

                // monta o caminho onde vamos salvar o arquivo : 
                // \wwwroot\Files\UserFiles\
                string fileDestinationPath = path_WwwRoot + "\\Files\\" + folder + "\\";

                // incluir a pasta Recebidos e o nome do arquivo enviado : 
                // \wwwroot\Files\UserFiles\Received\file
                string originalFileDestinationPath = fileDestinationPath + "\\Received\\" + fileName;

                //copia o arquivo para o local de destino original
                using (var stream = new FileStream(originalFileDestinationPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            //monta a ViewBag que será exibida na view como resultado do envio 
            TempData["Message"] = $"{files.Count} arquivos foram enviados ao servidor," +
                $"com tamanho total de : {fileSize} bytes";
            TempData["ColorMessage"] = "success";

            return RedirectToAction("Index", "AdminPieces");
        }
    }
}
