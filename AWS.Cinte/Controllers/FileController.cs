using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AWS.Cinte.Application.Contracts.Services;
using AWS.Cinte.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AWS.Cinte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private IFileService _fileService;
        public FileController(IFileService rouletteService)
        {
            this._fileService = rouletteService;
        }
        [HttpPost]
        public async Task<IActionResult> ConvertExcelFileToTextFile([FromBody] FilePathDto filePath)
        {
            try
            {
                await _fileService.ConvertExcelFileToTextFile(filePath);
                return Ok("The text file has been created.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(404, e.Message.ToString());
            }
        }
    }
}
