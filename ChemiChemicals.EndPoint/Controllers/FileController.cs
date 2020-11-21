using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChemiChemicals.EndPoint.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChemiChemicals.EndPoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly ILogger<FileController> _logger;
        public FileController(ILogger<FileController> logger)
        {
            _logger = logger;
        }

        [Route("[action]/{id}")]
        public async Task<IActionResult> DownloadFile(string filename = null)
        {
            try
            {
                Guid id = Guid.Parse(RouteData.Values["id"].ToString());
                var product = await new DALHandler().GetProductById(id);
                string base64String = product.BinaryContent;
                base64String = FileConverter.DecodeBase64(base64String);
                //get the byte out of base64 from here https://stackoverflow.com/questions/52287029/response-pdf-download-from-base64string-c-sharp
                var fileBytes = Convert.FromBase64String(base64String);
                var content = new System.IO.MemoryStream(fileBytes);
                var contentType = "APPLICATION/octet-stream";
                var extension = FileConverter.GetExtensionTypeFromBase64(base64String);
                return File(content, contentType, $"{filename ?? Guid.NewGuid().ToString()}.{extension}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
