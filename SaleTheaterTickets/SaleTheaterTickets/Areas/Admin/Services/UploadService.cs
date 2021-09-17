using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SaleTheaterTickets.Areas.Admin.Services
{
    public class UploadService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UploadService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> UploadFile(List<IFormFile> files)
        {
            // caminho completo do arquivo na localização temporária
            var filePath = Path.GetTempFileName();

            string originalFileDestinationPath = string.Empty;

            //processa os arquivo enviados
            //percorre a lista de arquivos selecionados
            foreach (var file in files)
            {
                // < define a pasta onde vamos salvar os arquivos >
                string folder = "UserFiles";

                // Define um nome para o arquivo enviado incluindo o sufixo obtido de milesegundos
                string fileName = "FileUser" + DateTime.Now.Millisecond.ToString();

                //< obtém o caminho físico da pasta wwwroot >
                string path_WwwRoot = _hostingEnvironment.WebRootPath;

                // monta o caminho onde vamos salvar o arquivo : 
                // \wwwroot\Files\UserFiles\
                string fileDestinationPath = path_WwwRoot + "\\Files\\" + folder + "\\";

                // incluir a pasta Recebidos e o nome do arquivo enviado : 
                // \wwwroot\Files\UserFiles\Received\file
                originalFileDestinationPath = fileDestinationPath + "\\Received\\" + fileName;

                //copia o arquivo para o local de destino original
                using (var stream = new FileStream(originalFileDestinationPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            return originalFileDestinationPath;

        }
}
}
